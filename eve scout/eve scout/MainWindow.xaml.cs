using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;
using Xceed.Wpf.Toolkit;
using System.IO;

namespace eve_scout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

        private IntPtr handle { get; set; }
        private System.Windows.Forms.FolderBrowserDialog folderBrowser { get; set; }
        private Variables vars { get; set; }
        private int tSec { get; set; }
        private Timer updateTimer { get; set; }

        public delegate void RefreshList();

        public MainWindow()
        {
            InitializeComponent();

            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            
            this.vars = new Variables();
            this.vars.refreshList = refreshList;

            this.vars.RaiseAlarmEvent += handleAlarm;
            this.acEveFolder.ItemsSource = this.vars.possibleEveFolders;
            if (this.vars.currentEveFolder == null)
            {
                for(int i=0;i<this.vars.possibleEveFolders.Count;i++)
                    if (Directory.Exists(this.vars.possibleEveFolders[i]))
                    {
                        this.acEveFolder.Text = this.vars.possibleEveFolders[i];
                        break;
                    }
            }
            else
                this.acEveFolder.Text = this.vars.currentEveFolder;
            this.Title = "eve scout (" + this.vars.assemblyVersion + ")";

            this.cbAutoLog.IsChecked = this.vars.autoStartLog;
            this.cbAutoEve.IsChecked = this.vars.autoStartEve;
            this.cbAutoSave.IsChecked = this.vars.autoSave;
            this.cbHotlist.IsChecked = this.vars.hotlistOnly;
            this.cbPlaySound.IsChecked = this.vars.playAlarm;
            this.miOptions.IsChecked = this.vars.viewOptions;
            this.miSystem.IsChecked = this.vars.viewLocal;
            this.miXML.IsChecked = this.vars.viewXML;
            this.miHotlist.IsChecked = this.vars.viewHotlist;
            this.udLocal.Value = this.vars.updateLocal;
            
            if ((bool)this.cbAutoLog.IsChecked)
                this.startLogServer();
            if ((bool)this.cbAutoEve.IsChecked)
                this.startEve();

            this.dgMonitor.ItemsSource = this.vars.players;
            this.tSec = 1;

            TimerCallback timerCallback = this.updateLocal;
            updateTimer = new System.Threading.Timer(timerCallback, null, 0, 1000);

            this.adjustWindowSize();

            this.tbHotlist.Text = this.vars.GetHotlist();
        }

        private void refreshList()
        {
            this.dgMonitor.Items.Refresh();
        }

        private void startLogServer()
        {
            try
            {
                ProcessStartInfo ProcessInfo;
                Process process;
                ProcessInfo = new ProcessStartInfo(this.vars.currentEveFolder + "\\LogServer.exe");//"C:\\Program Files (x86)\\CCP\\EVE\\LogServer.exe"

                ProcessInfo.UseShellExecute = false;
                ProcessInfo.CreateNoWindow = true;

                process = new Process();
                process.StartInfo = ProcessInfo;
                process.Start();

                Thread.Sleep(2500);

                handle = FindWindow("TCCPLogServer", null);
                PostMessage(handle, 0x0111, 0x0003, 0x0);//new workspace
            }
            catch { this.sbInfo.Content = "Error starting logServer."; }
        }

        private void startEve()
        {
            try
            {
                ProcessStartInfo ProcessInfo;
                Process process;
                ProcessInfo = new ProcessStartInfo("C:\\Program Files (x86)\\CCP\\EVE\\Bin\\ExeFile.exe");//"C:\\Program Files (x86)\\CCP\\EVE\\LogServer.exe"

                ProcessInfo.UseShellExecute = false;
                ProcessInfo.CreateNoWindow = true;

                process = new Process();
                process.StartInfo = ProcessInfo;
                process.Start();
            }
            catch { this.sbInfo.Content = "Error staring eve."; }
        }

        private void saveLog()
        {
            PostMessage(handle, 0x0111, 0x002F, 0x0);//server save
            //PostMessage(handle, 0x0111, 0x0026, 0x0);//clear all logs
        }

        private string findLog()
        {
            try
            {
                string[] files = Directory.GetFiles(this.vars.currentEveFolder, "*.lbw");
                if (files == null || files.Length <= 0)
                    return null;

                return files[0];
            }
            catch { return ""; }
        }

        private void adjustWindowSize()
        {
            if (this.miHotlist == null || this.colHotlist == null)
                return;

            try
            {
                double winsize = this.miHotlist.IsChecked ? this.colHotlist.Width.Value : 0;
                winsize += this.miXML.IsChecked ? this.colXML.Width.Value : 0;
                winsize += this.miSystem.IsChecked ? this.colSystem.Width.Value : 0;
                winsize += this.miOptions.IsChecked ? this.colOptions.Width.Value : 0;

                this.Width = winsize + 75;
            }
            catch { }
        }

        private void updateLocal(object stateInfo)
        {
            if (tSec++ % this.vars.updateLocal != 0)
                return;

            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                    {
                        this.saveLog();
                        Thread.Sleep(50);
                        this.vars.ParseLogFile(findLog());
                        this.tbXML.Text = this.vars.writeLocalXML();
                        this.tbXML.UpdateLayout();

                        this.dgMonitor.ItemsSource = null;
                        this.vars.players.Sort(delegate(PlayerInfo a, PlayerInfo b) { return a.player__name.CompareTo(b.player__name); });
                        this.dgMonitor.ItemsSource = this.vars.players;

                        Thread.Sleep(50);
                        this.dgMonitor.Items.Refresh();
                        this.dgMonitor.UpdateLayout();
                    }));

                string[] lbws = Directory.GetFiles(this.vars.currentEveFolder, "*.lbw");
                foreach (string file in lbws)
                    if (File.Exists(file))
                        File.Delete(file);
            }
            catch {  }
        }

        private void playAlarm()
        {
            SoundPlayer soundAlarm = new SoundPlayer(Properties.Resources.alarm);
            soundAlarm.Play();
        }

        private void handleAlarm(object sender, AlarmEventArgs e)
        {
            if (this.cbPlaySound.IsChecked == null)
                return;

            if ((bool)this.cbHotlist.IsChecked && !e.InHotlist)
                return;

            myNotify.ShowBalloonTip("System change.", e.Message, BalloonIcon.Warning);
            if ((bool)this.cbPlaySound.IsChecked)
                playAlarm();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miTest_Click(object sender, RoutedEventArgs e)
        {
            //myNotify.ShowBalloonTip("System change.", "max entered the system", BalloonIcon.Warning);

            //colOptions.Visible = !colOptions.Visible;
            //gsOne.Visibility = gsOne.Visibility != System.Windows.Visibility.Hidden ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;

            //playAlarm();

            //this.saveLog();

            /*string[] lbws = Directory.GetFiles(this.vars.currentEveFolder, "*.lbw");
            foreach (string file in lbws)
                if (File.Exists(file))
                    File.Delete(file);*/

            this.vars.ParseLogFile("C:/Users/critic/Desktop/eve scout/#CYBERCRITIC.2013.02.21.08.34.24.lbw");
            this.tbXML.Text = this.vars.writeLocalXML();
            this.tbXML.UpdateLayout();
            this.dgMonitor.Items.Refresh();
        }

        private void btEveFolder_Click(object sender, RoutedEventArgs e)
        {
            if (this.folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.acEveFolder.Text = this.folderBrowser.SelectedPath;
            }
        }

        private void miOptions_Checked(object sender, RoutedEventArgs e)
        {
            if (this.colOptions != null)
                this.colOptions.Visible = true;

            this.adjustWindowSize();
        }

        private void miOptions_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.colOptions != null)
                this.colOptions.Visible = false;

            this.adjustWindowSize();
        }

        private void miSystem_Checked(object sender, RoutedEventArgs e)
        {
            if (this.colSystem != null)
                this.colSystem.Visible = true;

            this.adjustWindowSize();
        }

        private void miSystem_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.colSystem != null)
                this.colSystem.Visible = false;

            this.adjustWindowSize();
        }

        private void miXML_Checked(object sender, RoutedEventArgs e)
        {
            if (this.colXML != null)
                this.colXML.Visible = true;

            this.adjustWindowSize();
        }

        private void miXML_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.colXML != null)
                this.colXML.Visible = false;

            this.adjustWindowSize();
        }

        private void miHotlist_Checked(object sender, RoutedEventArgs e)
        {
            if (this.colHotlist != null)
                this.colHotlist.Visible = true;

            this.adjustWindowSize();
        }

        private void miHotlist_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.colHotlist != null)
                this.colHotlist.Visible = false;

            this.adjustWindowSize();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.vars.currentEveFolder = this.acEveFolder.Text;
            this.vars.autoStartLog = (bool)this.cbAutoLog.IsChecked;
            //this.vars.autoStartEve = (bool)this.cbAutoEve.IsChecked;
            this.vars.autoSave = (bool)this.cbAutoSave.IsChecked;
            this.vars.viewOptions = (bool)this.miOptions.IsChecked;
            this.vars.viewLocal = (bool)this.miSystem.IsChecked;
            this.vars.viewXML = (bool)this.miXML.IsChecked;
            this.vars.viewHotlist = (bool)this.miHotlist.IsChecked;
            this.vars.updateLocal = (int)this.udLocal.Value;
            this.vars.playAlarm = (bool)this.cbPlaySound.IsChecked;
            this.vars.hotlistOnly = (bool)this.cbHotlist.IsChecked;

            this.vars.writeSettingsXML();
            this.vars.SaveHotlist();

            this.myNotify.Visibility = System.Windows.Visibility.Hidden;
            this.myNotify.Dispose();
        }

        private void dgMonitor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "join_leave" || e.PropertyName == "systemID" || 
                e.PropertyName == "playerID" || e.PropertyName == "userID" ||
                e.PropertyName == "corpID" || e.PropertyName == "allianceID")
                e.Cancel = true;
        }

        private void tbHotlist_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.vars.SetHotlist(this.tbHotlist.Text);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height - 195 > 0)
            {
                this.dgMonitor.MaxHeight = e.NewSize.Height - 195;
                this.tbXML.MaxHeight = e.NewSize.Height - 141;
                this.tbHotlist.MaxHeight = e.NewSize.Height - 188;
            }
        }

        private void miClearSystem_Click(object sender, RoutedEventArgs e)
        {
            this.vars.players.Clear();
            this.dgMonitor.Items.Refresh();
            this.dgMonitor.UpdateLayout();
        }

        private void miStartLog_Click(object sender, RoutedEventArgs e)
        {
            this.startLogServer();
        }

        private void miStartEve_Click(object sender, RoutedEventArgs e)
        {
            this.startEve();
        }

        private void udLocal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (udLocal != null && this.vars != null)
                this.vars.updateLocal = (int)this.udLocal.Value;
        }
    }
}


                
/*<tb:TaskbarIcon.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="First Menu Item" />
                    <MenuItem Header="Second Menu Item" />
                </ContextMenu>
            </tb:TaskbarIcon.ContextMenu>*/