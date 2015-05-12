﻿using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace BatteryNotifier
{
    public partial class SettingsForm : Form
    {
        private RegistryKey startupKey;

        public SettingsForm()
        {
            InitializeComponent();

            startupKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (startupKey.GetValue("BatteryNotifier") != null)
                startupCheckBox.Checked = true;

            // TODO: fill up low and high battery percent boxes correctly
            lowBatteryPercentBox.Text = Program.lowBatteryLevel.ToString();
            highBatteryPercentBox.Text = Program.highBatteryLevel.ToString();
            batteryLowSoundPathTextBox.Text = Program.batteryLowSoundPath;
            batteryHighSoundPathTextBox.Text = Program.batteryHighSoundPath;
            lowBatteryCheckBox.Checked = Program.alertOnLowBattery;
            highBatteryCheckBox.Checked = Program.alertOnHighBattery;
        }

        private void batteryLowSoundPathBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Program.batteryLowSoundPath);
            openFileDialog.FileName = Path.GetFileName(Program.batteryLowSoundPath);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                batteryLowSoundPathTextBox.Text = openFileDialog.FileName;
        }

        private void batteryHighSoundPathBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Program.batteryHighSoundPath);
            openFileDialog.FileName = Path.GetFileName(Program.batteryHighSoundPath);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                batteryHighSoundPathTextBox.Text = openFileDialog.FileName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (batteryLowSoundPathTextBox.Text != null)
                Program.batteryLowSoundPath = batteryLowSoundPathTextBox.Text;
            if (batteryHighSoundPathTextBox.Text != null)
                Program.batteryHighSoundPath = batteryHighSoundPathTextBox.Text;
            Program.alertOnLowBattery = lowBatteryCheckBox.Checked;
            Program.alertOnHighBattery = highBatteryCheckBox.Checked;
            // TODO: put low and high battery percent boxes into Program

            if (startupCheckBox.Checked)
                startupKey.SetValue("BatteryNotifier", Assembly.GetExecutingAssembly().Location);
            else if (startupKey.GetValue("BatteryNotifier") != null)
                startupKey.DeleteValue("BatteryNotifier");

            RegistryKey SoundPathKey = Registry.CurrentUser.OpenSubKey("Software", true);

            if (Program.batteryHighSoundPath != @"c:\Windows\Media\chimes.wav")
            {
                SoundPathKey = SoundPathKey.CreateSubKey("BatteryNotifier");
                SoundPathKey.SetValue("batteryHighSoundPath", Program.batteryHighSoundPath);
            }
            else
            {
                SoundPathKey = SoundPathKey.OpenSubKey("BatteryNotifier");
                if (SoundPathKey != null)
                {
                    SoundPathKey.DeleteValue("batteryHighSoundPath");
                }
            }
            // TODO: save other variables
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // TODO: maybe add a stop button/checkbox
            Close();
        }
    }
}