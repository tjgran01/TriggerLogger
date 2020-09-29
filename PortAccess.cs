using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace TriggerLogger
{
    //Put this class and calls somewhere useful, Probably with other trigger code

    public class PortAccess
    {
        private int _address;
        private int lastTriggerVal = 0;
        private Timer trigWait = new Timer();
        private int pulseTime = 5;

        bool waitPulse = false;
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int address, int value);

        public PortAccess()
        {
            trigWait.Interval = pulseTime;
            trigWait.AutoReset = false;
            trigWait.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        //'address' needs to be the address of the port IN DECIMAL - Note windows may well feed it to you in Hex, so will need to be converted before being coded up
        // The (first) address (in a range) of LPT1 in hex is 0x00003FF8 = 16376 in decimal

        //Will need a start and stop action on the pulse, I'd start it, run the other triggers and tehn stop it, but thats just me. 

        public void SetPulseLength(int pulseLen)
        {
            this.pulseTime = pulseLen;
            trigWait.Interval = pulseTime;
        }

        public void StartPulse(int address, int triggerVal)
        {
            if (!waitPulse || (triggerVal == 12 && lastTriggerVal == 7))
            {
                waitPulse = true;
                this.lastTriggerVal = triggerVal;
                Output(address, 255);
                this._address = address;
                trigWait.Start();
                Console.WriteLine(waitPulse);
            }
            else
            {
                Console.WriteLine("Trig Wait Active -- mark not sent");
            }
        }

        public void ResetPulse(int address)
        {
            Output(address, 0);
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            trigWait.Stop();
            ResetPulse(_address);
            waitPulse = false;
        }
    }

}
