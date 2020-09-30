using System;
using System.Threading;
using System.Diagnostics;
using System.Timers;
using System.IO;
using System.Windows.Forms;

namespace TriggerLogger
{
    public partial class Form1 : Form
    {
        private LSLTrigger lslTrigger = new LSLTrigger();
        private SimpleLogger theLogger;

        private string datetimeFormat = "yyyy-MM-dd HH-mm-ss";
        private static string logFilePath;

        private PortAccess hardwareTrig = new PortAccess();
        private string hexAddr = "3FF8";
        private int decAddr;

        private int pulseLen;
        private int numPulses;
        private int timeBetweenPulses;

        private int totalRunTime;

        private bool useLSL;
        private bool manualTrigger;
        private bool useTimer;
        private bool useStopWatch;
        private bool inManual = false;

        private int[] startMark = { 1 };
        private int[] endMark = { 10 };
        private int[] middleMark = { 5 };

        private string logFname;
        private string[] dirFiles;


        // Different pausing methods.
        private System.Timers.Timer betweenPulseTimer = new System.Timers.Timer();
        private Stopwatch bewteenPulseStopwatch = new Stopwatch();
        private bool canFire = true;


        public Form1()
        {
            InitializeComponent();
            SetFormDefaults();
            SetTimerParams();
        }

        private void SetFormDefaults()
        {
            this.pulseLen = 5;
            this.numPulses = 1000;
            this.timeBetweenPulses = 10;
            this.useLSL = false;
            this.manualTrigger = false;

            this.pulseLengthEntry.Text = pulseLen.ToString();
            this.numPulseEntey.Text = numPulses.ToString();
            this.timeBetweenEntry.Text = timeBetweenPulses.ToString();
            this.lslCheck.Checked = useLSL;
            this.manualCheckBox.Checked = manualTrigger;

            // Change address from hex to dec.
            this.decAddr = int.Parse(hexAddr, System.Globalization.NumberStyles.HexNumber);
        }

        private void SetTimerParams()
        {
            betweenPulseTimer.Interval = timeBetweenPulses + pulseLen;
            betweenPulseTimer.AutoReset = false;
            betweenPulseTimer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PauseMethod()
        {
            if (!useTimer && !useStopWatch)
            {
                Thread.Sleep(timeBetweenPulses + pulseLen);
            }
            else if (useTimer && !useStopWatch)
            {
                betweenPulseTimer.Start();
                canFire = false;
                while (!canFire)
                {
                    continue;
                }
                Console.WriteLine("Broke!");
            }
            else
            {
                bewteenPulseStopwatch.Start();
                while (bewteenPulseStopwatch.Elapsed.Milliseconds < timeBetweenPulses + pulseLen)
                {
                    continue;
                }
                Console.WriteLine(bewteenPulseStopwatch.Elapsed.Milliseconds.ToString());
                bewteenPulseStopwatch.Stop();
                bewteenPulseStopwatch.Reset();
                Console.WriteLine("Broke");
            }
        }


        private void submitButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (logFname == null)
            {
                logFilePath = @".\Logs\" + DateTime.Now.ToString(datetimeFormat) + ".txt";
            }
            else
            {
                logFilePath = @".\Logs\" + logFname + DateTime.Now.ToString(datetimeFormat) + ".txt";
            }

            theLogger = new SimpleLogger(logFilePath);
            hardwareTrig.SetPulseLength(pulseLen);
            SetTimerParams();

            // If you're in manual mode and click button return to normal form.
            if (inManual)
            {
                FireEvent(endMark);
                FlipWindow(false);
                inManual = false;
                // Disables Key Handling.
                this.KeyPreview = true;
                return;
            }

            if (manualTrigger)
            {
                FireEvent(startMark);
                FlipToManualWindow(true);
                inManual = true;
                // Enables Key Handling.
                this.KeyPreview = true;
            }
            else
            {
                FlipWindow(true);
                FireEvent(startMark);
                Thread.Sleep(timeBetweenPulses + pulseLen);

                for (int i = 0; i <= numPulses; i++)
                {
                    // Jostle these around to change order.
                    FireEvent(middleMark);
                    PauseMethod();
                }

                FireEvent(endMark);
                FlipWindow(false);
            }
        }

        private void FireEvent(int[] eventMark)
        {
            hardwareTrig.StartPulse(decAddr, eventMark[0]);
            if (useLSL)
            {
                lslTrigger.SendMark(eventMark);
            }
            theLogger.Info("Mark: " + eventMark[0].ToString() + " sent!");
        }

        private void manualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.manualTrigger = !this.manualTrigger;
            if (this.manualTrigger)
            {
                this.numPulseEntey.Enabled = false;
            }
            else
            {
                this.numPulseEntey.Enabled = true;
            }
        }

        private void lslCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.useLSL = !this.useLSL;
        }

        private void useTimerCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.useTimer = !this.useTimer;
            this.useStopWatch = false;
            stopWatchCheck.Checked = false;
        }

        private void stopWatchCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.useStopWatch = !this.useStopWatch;
            this.useTimer = false;
            useTimerCheck.Checked = false;
        }

        private void FlipToManualWindow(bool running)
        {
            if (running)
            {
                this.insturctionsLabel.Text = "The Program is now running in manual mode. Press the space key to fire a marker. When you wish to finish. Click the 'End Manual Mode' button.";
                this.insturctionsLabel.Update();
                this.pulseLengthEntry.Hide();
                this.numPulseEntey.Hide();
                this.timeBetweenEntry.Hide();
                this.lslCheck.Hide();
                this.manualCheckBox.Hide();
                this.submitButton.Text = "End Manual Mode";
                this.pulseLabel.Hide();
                this.numPulsesLabel.Hide();
                this.timeBetweenLabel.Hide();
            }
            else
            {
                FlipWindow(false);
            }
        }

        private void FlipWindow(bool running)
        {
            if (running)
            {
                totalRunTime = (pulseLen + timeBetweenPulses) * numPulses;

                this.insturctionsLabel.Text = "The Program is now running. Based on your parameters it should take " + totalRunTime.ToString() + "ms (" + (totalRunTime / 1000).ToString() + "s) to complete.";
                this.insturctionsLabel.Update();
                this.pulseLengthEntry.Hide();
                this.numPulseEntey.Hide();
                this.timeBetweenEntry.Hide();
                this.lslCheck.Hide();
                this.manualCheckBox.Hide();
                this.submitButton.Hide();
                this.pulseLabel.Hide();
                this.numPulsesLabel.Hide();
                this.timeBetweenLabel.Hide();
                this.useTimerCheck.Hide();
                this.stopWatchCheck.Hide();
                this.textBox1.Hide();
                this.textBox1.Text = "";
                this.fileNameLabel.Hide();
            }
            else
            {
                this.insturctionsLabel.Text = "Please input the following parameters.Once you are satisfied with the parameters" +
    ", press submit and the application will begin.";
                this.insturctionsLabel.Update();
                this.pulseLengthEntry.Show();
                this.numPulseEntey.Show();
                this.timeBetweenEntry.Show();
                this.lslCheck.Show();
                this.manualCheckBox.Show();
                this.submitButton.Show();
                this.pulseLabel.Show();
                this.numPulsesLabel.Show();
                this.timeBetweenLabel.Show();
                this.useTimerCheck.Show();
                this.stopWatchCheck.Show();
                this.textBox1.Show();
                this.fileNameLabel.Show();
            }
        }

        private void pulseLengthEntry_TextChanged(object sender, EventArgs e)
        {
            try { this.pulseLen = int.Parse(pulseLengthEntry.Text); }
            catch (System.FormatException) { return; }
        }

        private void numPulseEntey_TextChanged(object sender, EventArgs e)
        {
            try { this.numPulses = int.Parse(numPulseEntey.Text); }
            catch (System.FormatException) { return; }
        }

        private void timeBetweenEntry_TextChanged(object sender, EventArgs e)
        {
            try { this.timeBetweenPulses = int.Parse(timeBetweenEntry.Text); }
            catch (System.FormatException) { return; }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (inManual)
            {
                FireEvent(middleMark);
            }
        }

        // Timer methods
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            betweenPulseTimer.Stop();
            canFire = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.logFname = textBox1.Text;
        }
    }
}
