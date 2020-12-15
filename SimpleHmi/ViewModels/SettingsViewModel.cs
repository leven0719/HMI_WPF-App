using Prism.Mvvm;
using Prism.Regions;
using SimpleHmi.PlcService;
using System.ComponentModel;

namespace SimpleHmi.ViewModels
{
    class SettingsViewModel :BindableBase, INavigationAware
    {
        /// <summary>
        /// Implementation of the settings page when we can change the inlet/outlet pump speed.
        /// In this case we are using INaviagationAware interface to navigate from Prism.
        /// </summary>
        
        private readonly IPlcService _s7PlcService;

        private int _inletPumpSpeed;
        public int InletPumpSpeed
        {
            get { return _inletPumpSpeed; }
            set { SetProperty(ref _inletPumpSpeed, value); }
        }

        private int _outletPumpSpeed;
        public int OutletPumpSpeed
        {
            get { return _outletPumpSpeed; }
            set { SetProperty(ref _outletPumpSpeed, value); }
        }


        public SettingsViewModel(IPlcService s7PlcService)
        {
            _s7PlcService = s7PlcService;
            this.PropertyChanged += OnPropertyChanged;
        }

        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OutletPumpSpeed))
            {
                await _s7PlcService.WriteSpeedOutletPump((short)OutletPumpSpeed);
            }
            else if (e.PropertyName == nameof(InletPumpSpeed))
            {
                await _s7PlcService.WriteSpeedInletPump((short)InletPumpSpeed);
            }
        }

        // Definition of the INavigationAware interface methods
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            InletPumpSpeed = _s7PlcService.InletPumpSpeed;
            OutletPumpSpeed = _s7PlcService.OutletPumpSpeed;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
