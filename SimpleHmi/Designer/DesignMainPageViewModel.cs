using SimpleHmi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHmi.Designer
{
    class DesignMainPageViewModel : MainPageViewModel 
    {
        [Obsolete]
        public DesignMainPageViewModel() : base(new DesignPlcService())
        {

        }
    }
}
