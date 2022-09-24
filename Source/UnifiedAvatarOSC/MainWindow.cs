using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace UnifiedAvatarOSC
{
    public partial class MainWindow : Form
    {

        UnifiedAvatarSharpOSC avatarOsc = null;
        ProviderManager providerManager = new ProviderManager();
        LogManager logManager;
        string currentAvatar = "";
        bool shown = false;

        public MainWindow()
        {
            InitializeComponent();
            logManager = new LogManager(logTextBox);
            avatarOsc = new UnifiedAvatarSharpOSC("127.0.0.1", 9000,9001, "/avatar/parameters/UnifiedOSC/");
            avatarOsc.OnAvatarChanged += Server_OnAvatarChanged;
            avatarOsc.OnOscMessage += AvatarOsc_OnOscMessage;
            providerManager.LoadProviders();
            providerManager.AvatarChanged("",avatarOsc);

            updateInterval.Value = Properties.Settings.Default.minimumUpdateInterval;
            providerUpdater.Interval = Properties.Settings.Default.minimumUpdateInterval;

            hideOnStartup.Checked = Properties.Settings.Default.hideOnStartup;
            shown = !hideOnStartup.Checked;

            buildAndTestLoadsAll.Checked = Properties.Settings.Default.buildAndTestLoadsAll;


            UpdateLoadedModules();
        }

        private void AvatarOsc_OnOscMessage(string address, IList<object> args)
        {
            providerManager.PushMessage(address, args);
        }

        private void Server_OnAvatarChanged(string avatarId)
        {
            currentAvatar = avatarId;
            providerManager.AvatarChanged(avatarId,avatarOsc);
        }

        private void secondUpdater_Tick(object sender, EventArgs e)
        {
            providerManager.Update(avatarOsc);
            if (AvatarDefinitionLoader.Instance.CurrentAvatarDescriptor != null)
            {
                this.Text = AvatarDefinitionLoader.Instance.CurrentAvatarDescriptor.Name;
            }
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            shown = true;
            Show();
        }

        bool preventExit = true;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preventExit = false;
            Application.Exit();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = preventExit;
            if(preventExit)
                shown = false;
            Hide();
        }

        void UpdateLoadedModules()
        {
            providerManager.AllProviders.ForEach(p =>
            {
                loadedModules.Items.Add(p.OSCProvider.ProviderName);
            });
        }

        private void uiUpdater_Tick(object sender, EventArgs e)
        {
            logManager.Dequeue();

            loadedModules.Refresh();
            logTextBox.Text.Trim();
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
            
            if(shown == false)
                Hide(); 
        }

        private void buildAndTestLoadsAll_CheckedChanged(object sender, EventArgs e)
        {
            providerManager.LoadsAllIfNull = buildAndTestLoadsAll.Checked;
            providerManager.AvatarChanged(currentAvatar,avatarOsc);
            Properties.Settings.Default.buildAndTestLoadsAll = buildAndTestLoadsAll.Checked;
            Properties.Settings.Default.Save();
        }

        private void loadedModules_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            if (e.Index == -1)
            {
                g.FillRectangle(new SolidBrush(Color.DimGray), e.Bounds);
                return;
            }

            e.DrawBackground();

            ListBox lb = (ListBox)sender;
            if (providerManager.AllProviders.Where(p => p.OSCProvider.ProviderName == lb.Items[e.Index].ToString() && p.IsActive).Any())
            {
                g.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.DarkGray), e.Bounds);
            }

            g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            logTextBox.Text = "";
        }

        private void loadAllModulesBtn_Click(object sender, EventArgs e)
        {
            buildAndTestLoadsAll.Checked = true;
            providerManager.LoadsAllIfNull = buildAndTestLoadsAll.Checked;
            providerManager.AvatarChanged("", avatarOsc);
        }

        private void hideOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hideOnStartup = hideOnStartup.Checked;
            Properties.Settings.Default.Save();
        }

        private void updateInterval_ValueChanged(object sender, EventArgs e)
        {
            providerUpdater.Interval = ((int)updateInterval.Value);
            Properties.Settings.Default.minimumUpdateInterval = providerUpdater.Interval;
            Properties.Settings.Default.Save();
        }

        private void OpenModulesFolderBtn_Click(object sender, EventArgs e)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory() + "/Modules");
            Process.Start(directory.FullName);
        }
    }
}
