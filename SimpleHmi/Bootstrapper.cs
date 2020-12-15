using Autofac;
using Prism.Autofac;
using SimpleHmi.PlcService;
using SimpleHmi.Views;
using System.Windows;

namespace SimpleHmi
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        //registration of the objects in the container using prism.autofac package
        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);
            //builder.RegisterType<S7PlcService>().As<IPlcService>().SingleInstance();
            builder.RegisterType<PlcInstance>().As<IPlcService>().SingleInstance();
            builder.RegisterTypeForNavigation<MainPage>("MainPage");
            builder.RegisterTypeForNavigation<LeftMenu>("LeftMenu");
            builder.RegisterTypeForNavigation<StatusBar>("StatusBar");
            builder.RegisterTypeForNavigation<Settings>("Settings");
        }
    }
}
