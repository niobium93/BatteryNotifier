﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Media;
using System.IO;
using Microsoft.Win32;

// TODO: look into converting this into a windows service

namespace BatteryNotifier
{
    static class Program
    {
        static public bool isRunning = true;
        static Process currentProcess = Process.GetCurrentProcess();


        static public bool alertOnLowBattery = true;
        static public bool alertOnHighBattery = false;
        static public float lowBatteryLevel = 0.15f;
        static public float highBatteryLevel = 0.85f;
        static public string batteryLowSoundPath = @"c:\Windows\Media\notify.wav";
        static public string batteryHighSoundPath = @"c:\Windows\Media\chimes.wav";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Kill other instances of the same program here.
            // TODO: Maybe instead of killing by name I should kill by some unique id.
            // TODO: Instead of just killing the process maybe I should send commands to it like open settings or quit.
            Process[] processes = Process.GetProcessesByName(Assembly.GetExecutingAssembly().GetName().Name);
            foreach (Process process in processes)
            {
                if (process.Id != currentProcess.Id)
                    process.Kill();
                currentProcess.Dispose();
            }

            if (args.Length != 0 && args[0] == "/stop")
                isRunning = false;
            else if (args.Length != 0 && args[0] == "/settings")
            {
                ReadSoundPathsFromRegistry();
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog();
                settingsForm.Dispose();
            }
            else if (args.Length != 0)
            {
                MessageBox.Show("Unknown argument: " + args[0], "Battery Notifier");
                ReadSoundPathsFromRegistry();
            }
            ReadSoundPathsFromRegistry();

            // TODO: Lower the volume of other sounds playing on the computer to make sure the user hears the notification.
            SoundPlayer BatteryHighSoundPlayer = new SoundPlayer(batteryHighSoundPath);
            SoundPlayer BatteryLowSoundPlayer = new SoundPlayer(batteryLowSoundPath);
            while (isRunning)
            {
                if (alertOnHighBattery &&
                    SystemInformation.PowerStatus.BatteryLifePercent > highBatteryLevel &&
                    SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
                {
                    BatteryHighSoundPlayer.Play(); //Done charging; Deploy ear rape.
                    while (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
                    {
                        BatteryHighSoundPlayer.Play(); //Remind every 15sec.
                        Thread.Sleep(15000); //Wait until the power line is disconnected.
                    }
                }
                else if (alertOnLowBattery &&
                         SystemInformation.PowerStatus.BatteryLifePercent < lowBatteryLevel &&
                         SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
                {
                    BatteryLowSoundPlayer.Play(); //Battery low; Deploy ear rape.
                    while (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
                    {
                        BatteryLowSoundPlayer.Play(); //Remind every 15sec.
                        Thread.Sleep(15000); //Wait until power line is connected.
                    }
                }
                Thread.Sleep(15000); //Check for changes in battery status once per 15 seconds.
            }

            BatteryHighSoundPlayer.Dispose();
            BatteryLowSoundPlayer.Dispose();
        }

        static private void ReadSoundPathsFromRegistry()
        {
            RegistryKey BatteryNotifierKey = Registry.CurrentUser.OpenSubKey("Software\\BatteryNotifier", true);
            if (BatteryNotifierKey != null)
            {
                if (BatteryNotifierKey.GetValue("batteryLowSoundPath") != null)
                {
                    string path = BatteryNotifierKey.GetValue("batteryLowSoundPath").ToString();
                    if (File.Exists(path))
                    {
                        batteryLowSoundPath = @path;
                    }
                }

                if (BatteryNotifierKey.GetValue("batteryHighSoundPath") != null)
                {
                    string path = BatteryNotifierKey.GetValue("batteryHighSoundPath").ToString();
                    if (File.Exists(path))
                    {
                        batteryHighSoundPath = @path;
                    }
                }

                if (BatteryNotifierKey.GetValue("lowBatteryLevel") != null)
                {
                    lowBatteryLevel = (float)BatteryNotifierKey.GetValue("lowBatteryLevel")/100;
                }

                if (BatteryNotifierKey.GetValue("highBatteryLevel") != null)
                {
                    highBatteryLevel = (float)BatteryNotifierKey.GetValue("highBatteryLevel")/100;
                }

                if (BatteryNotifierKey.GetValue("alertOnLowBattery") != null)
                {
                    if ((string)BatteryNotifierKey.GetValue("alertOnLowBattery") == "True")
                        alertOnLowBattery = true;
                    else
                        alertOnLowBattery = false;
                }

                if (BatteryNotifierKey.GetValue("alertOnHighBattery") != null)
                {
                    if ((string)BatteryNotifierKey.GetValue("alertOnHighBattery") == "True")
                        alertOnHighBattery = true;
                    else
                        alertOnHighBattery = false;
                }
            }
        }
    }
}
