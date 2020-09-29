﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        private bool inManual = false;

        private int[] startMark = { 1 };
        private int[] endMark = { 10 };
        private int[] middleMark = { 5 };

        public Form1()
        {
            InitializeComponent();
            SetFormDefaults();
        }

        private void SetFormDefaults()
        {
            logFilePath = @".\Logs\" + DateTime.Now.ToString(datetimeFormat) + ".txt";
            theLogger = new SimpleLogger(logFilePath);

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_MouseClick(object sender, MouseEventArgs e)
        {
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

                for (int i = 0; i <= numPulses; i++)
                {
                    // Jostle these around to change order.
                    FireEvent(middleMark);
                    Thread.Sleep(timeBetweenPulses);
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
            Console.WriteLine(manualTrigger);
        }

        private void lslCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.useLSL = !this.useLSL;
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
                totalRunTime = pulseLen * numPulses * timeBetweenPulses;

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
    }
}