using SimpleHmi.PlcService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpleHmi.HmiControls
{
    /// <summary>
    /// Logika interakcji dla klasy MotorControl.xaml
    /// </summary>
    public partial class MotorControl : UserControl
    {

        bool toggleLight = true;
        public DispatcherTimer dt = new DispatcherTimer();

        public MotorControl()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;


            dt.Start();


        }

        private void dtTicker(object sender, EventArgs e)
        {

            if (toggleLight)
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(50, 205, 50, 0);
                EllipseMotor.Fill = mySolidColorBrush;
                toggleLight = false;

            }
            else
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(211, 211, 211, 0);
                EllipseMotor.Fill = mySolidColorBrush;
                toggleLight = true;
            }
        }

        /*  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {
              bool? state = value as bool?;

              if (state == null)
                  return Brushes.Red;

              if (state == true) 
              {
                  dt.Start();
                  return Brushes.LightGreen;
              }


              return Brushes.Red;
          }

          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
              throw new NotImplementedException();
          }
        */


    }
}
