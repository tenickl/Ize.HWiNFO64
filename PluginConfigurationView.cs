﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using HWiNFO64_Plugin;
using Ize.HWiNFO64_Plugin;
using SuchByte.MacroDeck.Plugins;

namespace HWiNFO64_Plugin
{
    public partial class PluginConfigurationView : Form
    {
        float angle = 0;
        float rotSpeed = 5;
        Point origin = new Point(51, 237);  // your origin
        int distance = 50;                  // your distance

        public PluginConfigurationView()
        {
            InitializeComponent();
        }

        private void PluginConfigurationView_Shown(object sender, EventArgs e)
        {
            sensorsCountLabel.Text = "" + HWiNFO64Plugin.sensors;

            var RefreshTime = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(HWiNFO64Plugin.Instance, "refreshTime");
            if (RefreshTime != "")
            {
                refreshTimeInput.Value = int.Parse(RefreshTime);
            }
            else
            {
                refreshTimeInput.Value = 2000; //default
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "https://www.hwinfo.com");
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(HWiNFO64Plugin.Instance, "refreshTime", refreshTimeInput.Value.ToString());
            MessageBox.Show("Settings Saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void lameTimer_Tick(object sender, EventArgs e)
        {
            angle += rotSpeed;
            int x = (int)(origin.X + distance * Math.Sin(angle / 2 * Math.PI / 180f));
            int y = (int)(origin.Y + distance * Math.Cos(angle * 2 * Math.PI / 180f));
            izeLogo.Location = new Point(x, y);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "https://github.com/Ize83/Ize.HWiNFO64");
        }
    }
}
