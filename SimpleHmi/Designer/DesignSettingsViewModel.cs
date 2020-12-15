using SimpleHmi.ViewModels;

namespace SimpleHmi.Designer
{
    class DesignSettingsViewModel : SettingsViewModel
    {
        public DesignSettingsViewModel() : base(new DesignPlcService())
        {

        }
    }
}
