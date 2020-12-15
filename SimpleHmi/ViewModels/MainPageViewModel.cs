using Prism.Commands;
using Prism.Mvvm;
using SimpleHmi.PlcService;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace SimpleHmi.ViewModels
{
    class MainPageViewModel : BindableBase
    {
        IPlcService _plcService;

        //property declaration with prism
        private string _ipAddress;
        public string IpAddress
        {
            get { return _ipAddress; }
            set { SetProperty(ref _ipAddress, value); }
        }

        private bool _pumpState;
        public bool PumpState
        {
            get { return _pumpState; }
            set { SetProperty(ref _pumpState, value); }
        }

        private int _tankLevel;
        public int TankLevel
        {
            get { return _tankLevel; }
            set { SetProperty(ref _tankLevel, value); }
        }

        private bool _highLimit;
        public bool HighLimit
        {
            get { return _highLimit; }
            set { SetProperty(ref _highLimit, value); }
        }

        private bool _lowLimit;
        public bool LowLimit
        {
            get { return _lowLimit; }
            set { SetProperty(ref _lowLimit, value); }
        }


        //commands declaration in the prism framework
        public ICommand ConnectCommand { get; private set; }

        public ICommand DisconnectCommand { get; private set; }

        public ICommand StartCommand { get; private set; }

        public ICommand StopCommand { get; private set; }


        public DateTime timer;

        [Obsolete]
        public DateTime Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                this.OnPropertyChanged("Timer");
            }
        }

        //declaration of the constructor for setting properties
        [Obsolete]
        public MainPageViewModel(IPlcService s7PlcService)
        {
            _plcService = s7PlcService;
            ConnectCommand = new DelegateCommand(Connect);
            DisconnectCommand = new DelegateCommand(Disconnect);
            StartCommand = new DelegateCommand(async () => { await Start(); });
            StopCommand = new DelegateCommand(async () => { await Stop(); });

            IpAddress = "192.168.1.0";

            OnPlcServiceValuesRefreshed(null, null);
            _plcService.ValuesRefreshed += OnPlcServiceValuesRefreshed;

            //actual time timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(TimerEventHandler);
            timer.Start();
           
            TimerEventHandler(null, null);
        }

        [Obsolete]
        private void TimerEventHandler(Object sender, EventArgs args)
        {
            Timer = DateTime.Now;

        }

        // refreshing the pump states values
        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {            
            PumpState = _plcService.PumpState;
            HighLimit = _plcService.HighLimit;
            LowLimit = _plcService.LowLimit;
            TankLevel = _plcService.TankLevel;            
        }

        private void Connect()
        {
            _plcService.Connect(IpAddress, 0, 1);
        }

        private void Disconnect()
        {
            _plcService.Disconnect();
        }

        private async Task Start()
        {
            await _plcService.WriteStart();
        }

        private async Task Stop()
        {
            await _plcService.WriteStop();
        }
    }
}
