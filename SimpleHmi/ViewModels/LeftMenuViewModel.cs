using Prism.Commands;
using Prism.Regions;
using SimpleHmi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleHmi.ViewModels
{
    class LeftMenuViewModel
    {
        private readonly IRegionManager _regionManager;

        // commands declaration from prism framework
        public ICommand NavigateToMainPageCommand { get; private set; }

        public ICommand NavigateToSettingsCommand { get; private set; }

        // navigate to regions with prism
        public LeftMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateToMainPageCommand = new DelegateCommand(() => NavigateTo("MainPage"));
            NavigateToSettingsCommand = new DelegateCommand(() => NavigateTo("Settings"));
        }

        private void NavigateTo(string url)
        {
            _regionManager.RequestNavigate(Regions.ContentRegion, url);
        }
    }
}
