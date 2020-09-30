namespace TriggerLogger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.submitButton = new System.Windows.Forms.Button();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.numPulsesLabel = new System.Windows.Forms.Label();
            this.timeBetweenLabel = new System.Windows.Forms.Label();
            this.insturctionsLabel = new System.Windows.Forms.Label();
            this.pulseLengthEntry = new System.Windows.Forms.TextBox();
            this.numPulseEntey = new System.Windows.Forms.TextBox();
            this.timeBetweenEntry = new System.Windows.Forms.TextBox();
            this.lslCheck = new System.Windows.Forms.CheckBox();
            this.manualCheckBox = new System.Windows.Forms.CheckBox();
            this.useTimerCheck = new System.Windows.Forms.CheckBox();
            this.stopWatchCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(339, 380);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(153, 52);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit and Run";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.submitButton_MouseClick);
            // 
            // pulseLabel
            // 
            this.pulseLabel.CausesValidation = false;
            this.pulseLabel.Location = new System.Drawing.Point(40, 78);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(99, 16);
            this.pulseLabel.TabIndex = 1;
            this.pulseLabel.Text = "Pulse Length (ms)";
            // 
            // numPulsesLabel
            // 
            this.numPulsesLabel.CausesValidation = false;
            this.numPulsesLabel.Location = new System.Drawing.Point(40, 137);
            this.numPulsesLabel.Name = "numPulsesLabel";
            this.numPulsesLabel.Size = new System.Drawing.Size(99, 28);
            this.numPulsesLabel.TabIndex = 2;
            this.numPulsesLabel.Text = "Number of Pulses (Iterations)";
            // 
            // timeBetweenLabel
            // 
            this.timeBetweenLabel.CausesValidation = false;
            this.timeBetweenLabel.Location = new System.Drawing.Point(40, 212);
            this.timeBetweenLabel.Name = "timeBetweenLabel";
            this.timeBetweenLabel.Size = new System.Drawing.Size(99, 28);
            this.timeBetweenLabel.TabIndex = 3;
            this.timeBetweenLabel.Text = "Time Between Pulses (ms)";
            // 
            // insturctionsLabel
            // 
            this.insturctionsLabel.CausesValidation = false;
            this.insturctionsLabel.Location = new System.Drawing.Point(40, 9);
            this.insturctionsLabel.Name = "insturctionsLabel";
            this.insturctionsLabel.Size = new System.Drawing.Size(412, 50);
            this.insturctionsLabel.TabIndex = 4;
            this.insturctionsLabel.Text = "Please input the following parameters. Once you are satisfied with the parameters" +
    ", press submit and the application will begin.";
            // 
            // pulseLengthEntry
            // 
            this.pulseLengthEntry.Location = new System.Drawing.Point(179, 73);
            this.pulseLengthEntry.Name = "pulseLengthEntry";
            this.pulseLengthEntry.Size = new System.Drawing.Size(273, 20);
            this.pulseLengthEntry.TabIndex = 5;
            this.pulseLengthEntry.TextChanged += new System.EventHandler(this.pulseLengthEntry_TextChanged);
            // 
            // numPulseEntey
            // 
            this.numPulseEntey.Location = new System.Drawing.Point(179, 145);
            this.numPulseEntey.Name = "numPulseEntey";
            this.numPulseEntey.Size = new System.Drawing.Size(273, 20);
            this.numPulseEntey.TabIndex = 6;
            this.numPulseEntey.TextChanged += new System.EventHandler(this.numPulseEntey_TextChanged);
            // 
            // timeBetweenEntry
            // 
            this.timeBetweenEntry.Location = new System.Drawing.Point(179, 220);
            this.timeBetweenEntry.Name = "timeBetweenEntry";
            this.timeBetweenEntry.Size = new System.Drawing.Size(273, 20);
            this.timeBetweenEntry.TabIndex = 7;
            this.timeBetweenEntry.TextChanged += new System.EventHandler(this.timeBetweenEntry_TextChanged);
            // 
            // lslCheck
            // 
            this.lslCheck.AutoSize = true;
            this.lslCheck.Location = new System.Drawing.Point(43, 274);
            this.lslCheck.Name = "lslCheck";
            this.lslCheck.Size = new System.Drawing.Size(87, 17);
            this.lslCheck.TabIndex = 9;
            this.lslCheck.Text = "LSL Enabled";
            this.lslCheck.UseVisualStyleBackColor = true;
            this.lslCheck.CheckedChanged += new System.EventHandler(this.lslCheck_CheckedChanged);
            // 
            // manualCheckBox
            // 
            this.manualCheckBox.AutoSize = true;
            this.manualCheckBox.Location = new System.Drawing.Point(43, 320);
            this.manualCheckBox.Name = "manualCheckBox";
            this.manualCheckBox.Size = new System.Drawing.Size(88, 17);
            this.manualCheckBox.TabIndex = 10;
            this.manualCheckBox.Text = "Fire Manually";
            this.manualCheckBox.UseVisualStyleBackColor = true;
            this.manualCheckBox.CheckedChanged += new System.EventHandler(this.manualCheckBox_CheckedChanged);
            // 
            // useTimerCheck
            // 
            this.useTimerCheck.AutoSize = true;
            this.useTimerCheck.Location = new System.Drawing.Point(42, 362);
            this.useTimerCheck.Name = "useTimerCheck";
            this.useTimerCheck.Size = new System.Drawing.Size(74, 17);
            this.useTimerCheck.TabIndex = 11;
            this.useTimerCheck.Text = "Use Timer";
            this.useTimerCheck.UseVisualStyleBackColor = true;
            this.useTimerCheck.CheckedChanged += new System.EventHandler(this.useTimerCheck_CheckedChanged);
            // 
            // stopWatchCheck
            // 
            this.stopWatchCheck.AutoSize = true;
            this.stopWatchCheck.Location = new System.Drawing.Point(42, 399);
            this.stopWatchCheck.Name = "stopWatchCheck";
            this.stopWatchCheck.Size = new System.Drawing.Size(99, 17);
            this.stopWatchCheck.TabIndex = 12;
            this.stopWatchCheck.Text = "Use Stopwatch";
            this.stopWatchCheck.UseVisualStyleBackColor = true;
            this.stopWatchCheck.CheckedChanged += new System.EventHandler(this.stopWatchCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(503, 449);
            this.Controls.Add(this.stopWatchCheck);
            this.Controls.Add(this.useTimerCheck);
            this.Controls.Add(this.manualCheckBox);
            this.Controls.Add(this.lslCheck);
            this.Controls.Add(this.timeBetweenEntry);
            this.Controls.Add(this.numPulseEntey);
            this.Controls.Add(this.pulseLengthEntry);
            this.Controls.Add(this.insturctionsLabel);
            this.Controls.Add(this.timeBetweenLabel);
            this.Controls.Add(this.numPulsesLabel);
            this.Controls.Add(this.pulseLabel);
            this.Controls.Add(this.submitButton);
            this.Name = "Form1";
            this.Text = "Trigger Logger Main Window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.Label numPulsesLabel;
        private System.Windows.Forms.Label timeBetweenLabel;
        private System.Windows.Forms.Label insturctionsLabel;
        private System.Windows.Forms.TextBox pulseLengthEntry;
        private System.Windows.Forms.TextBox numPulseEntey;
        private System.Windows.Forms.TextBox timeBetweenEntry;
        private System.Windows.Forms.CheckBox lslCheck;
        private System.Windows.Forms.CheckBox manualCheckBox;
        private System.Windows.Forms.CheckBox useTimerCheck;
        private System.Windows.Forms.CheckBox stopWatchCheck;
    }
}

