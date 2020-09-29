using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace TriggerLogger
{
    //Put this class and calls somewhere useful, Probably with other trigger code

    public class PortAccess
    {
        private int _address;
        bool waitPulse = false;
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int address, int value);

        //'address' needs to be the address of the port IN DECIMAL - Note windows may well feed it to you in Hex, so will need to be converted before being coded up
        // The (first) address (in a range) of LPT1 in hex is 0x00003FF8 = 16376 in decimal

        //Will need a start and stop action on the pulse, I'd start it, run the other triggers and tehn stop it, but thats just me. 

        public void StartPulse(int address, int triggerVal)
        {
            if (!waitPulse)
            {
                Output(address, triggerVal);
                waitPulse = true;
                this._address = address;
                Timer trigWait = new Timer();
                trigWait.Interval = 5;
                trigWait.AutoReset = false;
                trigWait.Elapsed += new ElapsedEventHandler(TimerElapsed);
                trigWait.Start();
            }
        }

        public void ResetPulse(int address)
        {
            Output(address, 0);
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ResetPulse(_address);
            waitPulse = false;
        }
    }

}
