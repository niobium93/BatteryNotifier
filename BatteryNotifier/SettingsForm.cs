using System;
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

            lowBatteryPercentBox.Value = (int)(Program.lowBatteryLevel*100);
            highBatteryPercentBox.Value = (int)(Program.highBatteryLevel*100);
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
            openFileDialog.Dispose();
        }

        private void batteryHighSoundPathBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Program.batteryHighSoundPath);
            openFileDialog.FileName = Path.GetFileName(Program.batteryHighSoundPath);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                batteryHighSoundPathTextBox.Text = openFileDialog.FileName;
            openFileDialog.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (batteryLowSoundPathTextBox.Text != null)
                Program.batteryLowSoundPath = batteryLowSoundPathTextBox.Text;
            if (batteryHighSoundPathTextBox.Text != null)
                Program.batteryHighSoundPath = batteryHighSoundPathTextBox.Text;
            Program.alertOnLowBattery = lowBatteryCheckBox.Checked;
            Program.alertOnHighBattery = highBatteryCheckBox.Checked;
            Program.highBatteryLevel = (float)highBatteryPercentBox.Value/100;
            Program.lowBatteryLevel = (float)lowBatteryPercentBox.Value/100;

            if (startupCheckBox.Checked)
                startupKey.SetValue("BatteryNotifier", Assembly.GetExecutingAssembly().Location);
            else if (startupKey.GetValue("BatteryNotifier") != null)
                startupKey.DeleteValue("BatteryNotifier");
            startupKey.Dispose();

            RegistryKey BatteryNotifierKey = Registry.CurrentUser.OpenSubKey("Software", true);
            BatteryNotifierKey = BatteryNotifierKey.CreateSubKey("BatteryNotifier");

            if (Program.batteryLowSoundPath != @"c:\Windows\Media\notify.wav")
                BatteryNotifierKey.SetValue("batteryLowSoundPath", Program.batteryLowSoundPath, RegistryValueKind.String);
            else if (BatteryNotifierKey.GetValue("batteryLowSoundPath") != null)
                BatteryNotifierKey.DeleteValue("batteryLowSoundPath");

            if (Program.batteryHighSoundPath != @"c:\Windows\Media\chimes.wav")
                BatteryNotifierKey.SetValue("batteryHighSoundPath", Program.batteryHighSoundPath, RegistryValueKind.String);
            else if (BatteryNotifierKey.GetValue("batteryHighSoundPath") != null)
                    BatteryNotifierKey.DeleteValue("batteryHighSoundPath");

            if (Program.alertOnLowBattery != true)
                BatteryNotifierKey.SetValue("alertOnLowBattery", Program.alertOnLowBattery, RegistryValueKind.Unknown);
            else if (BatteryNotifierKey.GetValue("alertOnLowBattery") != null)
                BatteryNotifierKey.DeleteValue("alertOnLowBattery");

            if (Program.alertOnHighBattery != false)
                BatteryNotifierKey.SetValue("alertOnHighBattery", Program.alertOnHighBattery, RegistryValueKind.Unknown);
            else if (BatteryNotifierKey.GetValue("alertOnHighBattery") != null)
                BatteryNotifierKey.DeleteValue("alertOnHighBattery");

            if (Program.highBatteryLevel != 0.85f)
                BatteryNotifierKey.SetValue("highBatteryLevel", Program.highBatteryLevel*100, RegistryValueKind.DWord);
            else if (BatteryNotifierKey.GetValue("highBatteryLevel") != null)
                BatteryNotifierKey.DeleteValue("highBatteryLevel");

            if (Program.lowBatteryLevel != 0.15f)
                BatteryNotifierKey.SetValue("lowBatteryLevel", Program.lowBatteryLevel*100, RegistryValueKind.DWord);
            else if (BatteryNotifierKey.GetValue("lowBatteryLevel") != null)
                BatteryNotifierKey.DeleteValue("lowBatteryLevel");

            if (stopProgramCheckBox.Checked) Program.isRunning = false;
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (stopProgramCheckBox.Checked) Program.isRunning = false;
            startupKey.Dispose();
            Close();
        }
    }

    public class CustomNumericUpDown : NumericUpDown
    {
        /*protected override void UpdateEditText()
        {
            Text = Value.ToString() + "%";

        }*/

        /*protected override void ValidateEditText()
        {
            // TODO: How do I make this not result in an infinite loop?
            if (Text.EndsWith("%") && Value != Convert.ToInt32(Text.Split('%')[0]))
                Value = Convert.ToInt32(Text.Split('%')[0]);
            else
            {
                Value = Convert.ToInt32(Text);
                Text = Value.ToString() + "%";
            }
            UpdateEditText();
        }*/
    }
}
