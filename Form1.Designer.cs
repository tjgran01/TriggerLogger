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
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(508, 505);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(230, 80);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit and Run";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.submitButton_MouseClick);
            // 
            // pulseLabel
            // 
            this.pulseLabel.CausesValidation = false;
            this.pulseLabel.Location = new System.Drawing.Point(60, 120);
            this.pulseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(148, 25);
            this.pulseLabel.TabIndex = 1;
            this.pulseLabel.Text = "Pulse Length (ms)";
            // 
            // numPulsesLabel
            // 
            this.numPulsesLabel.CausesValidation = false;
            this.numPulsesLabel.Location = new System.Drawing.Point(60, 211);
            this.numPulsesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numPulsesLabel.Name = "numPulsesLabel";
            this.numPulsesLabel.Size = new System.Drawing.Size(148, 43);
            this.numPulsesLabel.TabIndex = 2;
            this.numPulsesLabel.Text = "Number of Pulses (Iterations)";
            // 
            // timeBetweenLabel
            // 
            this.timeBetweenLabel.CausesValidation = false;
            this.timeBetweenLabel.Location = new System.Drawing.Point(60, 326);
            this.timeBetweenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeBetweenLabel.Name = "timeBetweenLabel";
            this.timeBetweenLabel.Size = new System.Drawing.Size(148, 43);
            this.timeBetweenLabel.TabIndex = 3;
            this.timeBetweenLabel.Text = "Time Between Pulses (ms)";
            // 
            // insturctionsLabel
            // 
            this.insturctionsLabel.CausesValidation = false;
            this.insturctionsLabel.Location = new System.Drawing.Point(60, 14);
            this.insturctionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.insturctionsLabel.Name = "insturctionsLabel";
            this.insturctionsLabel.Size = new System.Drawing.Size(618, 77);
            this.insturctionsLabel.TabIndex = 4;
            this.insturctionsLabel.Text = "Please input the following parameters. Once you are satisfied with the parameters" +
    ", press submit and the application will begin.";
            // 
            // pulseLengthEntry
            // 
            this.pulseLengthEntry.Location = new System.Drawing.Point(268, 112);
            this.pulseLengthEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseLengthEntry.Name = "pulseLengthEntry";
            this.pulseLengthEntry.Size = new System.Drawing.Size(408, 26);
            this.pulseLengthEntry.TabIndex = 5;
            this.pulseLengthEntry.TextChanged += new System.EventHandler(this.pulseLengthEntry_TextChanged);
            // 
            // numPulseEntey
            // 
            this.numPulseEntey.Location = new System.Drawing.Point(268, 223);
            this.numPulseEntey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPulseEntey.Name = "numPulseEntey";
            this.numPulseEntey.Size = new System.Drawing.Size(408, 26);
            this.numPulseEntey.TabIndex = 6;
            this.numPulseEntey.TextChanged += new System.EventHandler(this.numPulseEntey_TextChanged);
            // 
            // timeBetweenEntry
            // 
            this.timeBetweenEntry.Location = new System.Drawing.Point(268, 338);
            this.timeBetweenEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeBetweenEntry.Name = "timeBetweenEntry";
            this.timeBetweenEntry.Size = new System.Drawing.Size(408, 26);
            this.timeBetweenEntry.TabIndex = 7;
            this.timeBetweenEntry.TextChanged += new System.EventHandler(this.timeBetweenEntry_TextChanged);
            // 
            // lslCheck
            // 
            this.lslCheck.AutoSize = true;
            this.lslCheck.Location = new System.Drawing.Point(64, 422);
            this.lslCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lslCheck.Name = "lslCheck";
            this.lslCheck.Size = new System.Drawing.Size(120, 24);
            this.lslCheck.TabIndex = 9;
            this.lslCheck.Text = "LSL Enabled";
            this.lslCheck.UseVisualStyleBackColor = true;
            this.lslCheck.CheckedChanged += new System.EventHandler(this.lslCheck_CheckedChanged);
            // 
            // manualCheckBox
            // 
            this.manualCheckBox.AutoSize = true;
            this.manualCheckBox.Location = new System.Drawing.Point(64, 492);
            this.manualCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.manualCheckBox.Name = "manualCheckBox";
            this.manualCheckBox.Size = new System.Drawing.Size(121, 24);
            this.manualCheckBox.TabIndex = 10;
            this.manualCheckBox.Text = "Fire Manually";
            this.manualCheckBox.UseVisualStyleBackColor = true;
            this.manualCheckBox.CheckedChanged += new System.EventHandler(this.manualCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 611);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

