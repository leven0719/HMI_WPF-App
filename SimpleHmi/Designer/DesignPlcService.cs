using SimpleHmi.PlcService;
using System;
using System.Threading.Tasks;

namespace SimpleHmi.Designer
{
    //design of the Plc service in which we set all starting values and declare functions
    class DesignPlcService : IPlcService
    {
        public ConnectionStates ConnectionState
        {
            get
            {
                return ConnectionStates.Online;
            }
        }

        public bool PumpState
        {
            get { return true; }
        }

        public int TankLevel
        {
            get { return 0; }
        }

        public bool HighLimit
        {
            get { return false; }
        }

        public int InletPumpSpeed
        {
            get { return 1; }
        }

        public bool LowLimit
        {
            get { return true; }
        }

        public int OutletPumpSpeed
        {
            get { return 2; }
        }

        public TimeSpan ScanTime
        {
            get
            {
                return TimeSpan.FromMilliseconds(2550);
            }
        }

        // avoid warning CS0067
        public event EventHandler ValuesRefreshed { add { } remove { } } 

        public void Connect(string ipAddress, int rack, int slot)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task WriteStart()
        {
            throw new NotImplementedException();
        }

        public Task WriteStop()
        {
            throw new NotImplementedException();
        }
        public Task WriteSpeedInletPump(short speed)
        {
            throw new NotImplementedException();
        }

        public Task WriteSpeedOutletPump(short speed)
        {
            throw new NotImplementedException();
        }

    }
}
