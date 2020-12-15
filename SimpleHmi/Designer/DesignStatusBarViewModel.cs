using SimpleHmi.ViewModels;

namespace SimpleHmi.Designer
{
    class DesignStatusBarViewModel : StatusBarViewModel
    {
        public DesignStatusBarViewModel() : base(new DesignPlcService())
        {
                
        }
    }
}
