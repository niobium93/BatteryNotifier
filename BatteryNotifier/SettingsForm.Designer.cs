namespace BatteryNotifier
{
    partial class SettingsForm
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
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.lowBatteryCheckBox = new System.Windows.Forms.CheckBox();
            this.highBatteryCheckBox = new System.Windows.Forms.CheckBox();
            this.batteryLowSoundPathTextBox = new System.Windows.Forms.TextBox();
            this.batteryHighSoundPathTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.batteryLowSoundPathBrowseButton = new System.Windows.Forms.Button();
            this.batteryHighSoundPathBrowseButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lowBatteryPercentBox = new CustomNumericUpDown();
            this.highBatteryPercentBox = new CustomNumericUpDown();
            this.stopProgramCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lowBatteryPercentBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBatteryPercentBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(12, 12);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(96, 17);
            this.startupCheckBox.TabIndex = 0;
            this.startupCheckBox.Text = "Run on startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // lowBatteryCheckBox
            // 
            this.lowBatteryCheckBox.AutoSize = true;
            this.lowBatteryCheckBox.Location = new System.Drawing.Point(12, 35);
            this.lowBatteryCheckBox.Name = "lowBatteryCheckBox";
            this.lowBatteryCheckBox.Size = new System.Drawing.Size(116, 17);
            this.lowBatteryCheckBox.TabIndex = 1;
            this.lowBatteryCheckBox.Text = "Alert on low battery";
            this.lowBatteryCheckBox.UseVisualStyleBackColor = true;
            // 
            // highBatteryCheckBox
            // 
            this.highBatteryCheckBox.AutoSize = true;
            this.highBatteryCheckBox.Location = new System.Drawing.Point(12, 58);
            this.highBatteryCheckBox.Name = "highBatteryCheckBox";
            this.highBatteryCheckBox.Size = new System.Drawing.Size(120, 17);
            this.highBatteryCheckBox.TabIndex = 3;
            this.highBatteryCheckBox.Text = "Alert on high battery";
            this.highBatteryCheckBox.UseVisualStyleBackColor = true;
            // 
            // batteryLowSoundPathTextBox
            // 
            this.batteryLowSoundPathTextBox.Location = new System.Drawing.Point(12, 81);
            this.batteryLowSoundPathTextBox.Name = "batteryLowSoundPathTextBox";
            this.batteryLowSoundPathTextBox.Size = new System.Drawing.Size(300, 20);
            this.batteryLowSoundPathTextBox.TabIndex = 5;
            // 
            // batteryHighSoundPathTextBox
            // 
            this.batteryHighSoundPathTextBox.Location = new System.Drawing.Point(12, 107);
            this.batteryHighSoundPathTextBox.Name = "batteryHighSoundPathTextBox";
            this.batteryHighSoundPathTextBox.Size = new System.Drawing.Size(300, 20);
            this.batteryHighSoundPathTextBox.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(318, 132);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(237, 133);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // batteryLowSoundPathBrowseButton
            // 
            this.batteryLowSoundPathBrowseButton.Location = new System.Drawing.Point(318, 81);
            this.batteryLowSoundPathBrowseButton.Name = "batteryLowSoundPathBrowseButton";
            this.batteryLowSoundPathBrowseButton.Size = new System.Drawing.Size(75, 20);
            this.batteryLowSoundPathBrowseButton.TabIndex = 6;
            this.batteryLowSoundPathBrowseButton.Text = "Browse...";
            this.batteryLowSoundPathBrowseButton.UseVisualStyleBackColor = true;
            this.batteryLowSoundPathBrowseButton.Click += new System.EventHandler(this.batteryLowSoundPathBrowseButton_Click);
            // 
            // batteryHighSoundPathBrowseButton
            // 
            this.batteryHighSoundPathBrowseButton.Location = new System.Drawing.Point(318, 106);
            this.batteryHighSoundPathBrowseButton.Name = "batteryHighSoundPathBrowseButton";
            this.batteryHighSoundPathBrowseButton.Size = new System.Drawing.Size(75, 20);
            this.batteryHighSoundPathBrowseButton.TabIndex = 8;
            this.batteryHighSoundPathBrowseButton.Text = "Browse...";
            this.batteryHighSoundPathBrowseButton.UseVisualStyleBackColor = true;
            this.batteryHighSoundPathBrowseButton.Click += new System.EventHandler(this.batteryHighSoundPathBrowseButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // lowBatteryPercentBox
            // 
            this.lowBatteryPercentBox.Location = new System.Drawing.Point(138, 32);
            this.lowBatteryPercentBox.Name = "lowBatteryPercentBox";
            this.lowBatteryPercentBox.Size = new System.Drawing.Size(45, 20);
            this.lowBatteryPercentBox.TabIndex = 2;
            // 
            // highBatteryPercentBox
            // 
            this.highBatteryPercentBox.Location = new System.Drawing.Point(138, 55);
            this.highBatteryPercentBox.Name = "highBatteryPercentBox";
            this.highBatteryPercentBox.Size = new System.Drawing.Size(45, 20);
            this.highBatteryPercentBox.TabIndex = 4;
            // 
            // stopProgramCheckBox
            // 
            this.stopProgramCheckBox.AutoSize = true;
            this.stopProgramCheckBox.Location = new System.Drawing.Point(12, 133);
            this.stopProgramCheckBox.Name = "stopProgramCheckBox";
            this.stopProgramCheckBox.Size = new System.Drawing.Size(112, 17);
            this.stopProgramCheckBox.TabIndex = 11;
            this.stopProgramCheckBox.Text = "Stop program now";
            this.stopProgramCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(401, 179);
            this.Controls.Add(this.stopProgramCheckBox);
            this.Controls.Add(this.highBatteryPercentBox);
            this.Controls.Add(this.lowBatteryPercentBox);
            this.Controls.Add(this.batteryHighSoundPathBrowseButton);
            this.Controls.Add(this.batteryLowSoundPathBrowseButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.batteryHighSoundPathTextBox);
            this.Controls.Add(this.batteryLowSoundPathTextBox);
            this.Controls.Add(this.highBatteryCheckBox);
            this.Controls.Add(this.lowBatteryCheckBox);
            this.Controls.Add(this.startupCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(417, 218);
            this.Name = "SettingsForm";
            this.Text = "Battery Notifier Settings";
            ((System.ComponentModel.ISupportInitialize)(this.lowBatteryPercentBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highBatteryPercentBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.CheckBox lowBatteryCheckBox;
        private System.Windows.Forms.CheckBox highBatteryCheckBox;
        private System.Windows.Forms.TextBox batteryLowSoundPathTextBox;
        private System.Windows.Forms.TextBox batteryHighSoundPathTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button batteryLowSoundPathBrowseButton;
        private System.Windows.Forms.Button batteryHighSoundPathBrowseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private CustomNumericUpDown lowBatteryPercentBox;
        private CustomNumericUpDown highBatteryPercentBox;
        private System.Windows.Forms.CheckBox stopProgramCheckBox;
    }
}