using System;
using System.Threading.Tasks;


namespace SimpleHmi.PlcService
{
    //we use PlcInstance to imitate the work of the real PLC, just in case we want to check if our app works properly
    //unfortunately PlcInstance functionality is limited
    public class PlcInstance : IPlcService
    {
        //declaration of all the functions in the application
        public ConnectionStates ConnectionState { get; private set; }

        public bool HighLimit { get; private set; }

        public int InletPumpSpeed { get; private set; }

        public bool LowLimit { get; private set; }

        public int OutletPumpSpeed { get; private set; }

        public bool PumpState { get; private set; }

        public TimeSpan ScanTime { get; private set; }

        public int TankLevel { get; private set; }

        public event EventHandler ValuesRefreshed;

        private System.Timers.Timer _timer;
        private DateTime _lastScanTime;

        public PlcInstance()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 100;
            InletPumpSpeed = 2;
            OutletPumpSpeed = 1;
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();


            TankLevel -= OutletPumpSpeed;
            TankLevel = Math.Max(TankLevel, 0);


            if (PumpState)
            {
                TankLevel += InletPumpSpeed;
                TankLevel = Math.Min(TankLevel, 100);
            }
            LowLimit = TankLevel < 10;
            HighLimit = TankLevel > 90;
            ScanTime = DateTime.Now - _lastScanTime;
            OnValuesRefreshed();
            _timer.Start();
            _lastScanTime = DateTime.Now;
        }

        public void Connect(string ipAddress, int rack, int slot)
        {
            ConnectionState = ConnectionStates.Connecting;
            OnValuesRefreshed();
            ConnectionState = ConnectionStates.Online;
            _timer.Start();
        }

        public void Disconnect()
        {
            ConnectionState = ConnectionStates.Offline;
            OnValuesRefreshed();
            _timer.Stop();
        }

        public Task WriteStart()
        {
            return Task.Run(() => {
                PumpState = true;
            });
        }

        public Task WriteStop()
        {
            return Task.Run(() => {
                PumpState = false;
            });
        }

        public Task WriteSpeedInletPump(short speed)
        {
            return Task.Run(() => { InletPumpSpeed = speed; });
        }

        public Task WriteSpeedOutletPump(short speed)
        {
            return Task.Run(() => { OutletPumpSpeed = speed; });
        }

        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }
    }
}
