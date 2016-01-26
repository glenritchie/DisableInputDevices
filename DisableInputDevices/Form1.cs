using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Management;

namespace DisableInputDevices
{
    public partial class Form1 : Form
    {            
        String outputLog = "output.log";

        private readonly object syncLock = new object();
        int disableCount = 0;
        BindingSource imageBindingSource;
        BindingList<ProgramImage> imageBindingList;

        BindingSource deviceBindingSource;
        BindingList<DeviceID> deviceBindingList;
        ManagementEventWatcher CreateWatcher;
        ManagementEventWatcher StoppedWatcher;

        public Form1()
        {
            InitializeComponent();
        }
        private void log(String data)
        {
            String time = DateTime.Now.ToString();
            File.AppendAllText(outputLog, time + ":" + data);
        }
        private void ProcessCreatedWmiEventHandler(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject x = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value);
            String path = (String)x["ExecutablePath"];
            bool inList = imageBindingList.Any((pi) => pi.path.Equals(path));
            if (inList)
            {
                log("Doing disable due to process " + path + "\n");
                doDisable();
               
            }
        }

        private void ProcessStoppedWmiEventHandler(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject x = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value);
            String path = (String)x["ExecutablePath"];
            bool inList = imageBindingList.Any((pi) => pi.path.Equals(path));
            if (inList)
            {
                log("Doing enable due to process " + path);
                doEnable();
               
            }
        }
        private void doDevCon(String cmd, String args)
        {
            // Execute disable command line
            Process p = new Process();
            p.StartInfo.FileName = "devcon_amd64.exe";
            p.StartInfo.Arguments = cmd + " "  + args;
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.Verb = "runas"; // make it popup UAC
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit();
            String data = p.StandardOutput.ReadToEnd();


            log(data);
        }
        private void doDisable()
        {
            lock (syncLock)
            {
                // only disable if our disable count is 0
                if (disableCount == 0)
                {
                    String[] ids = deviceBindingList.Select(i => i.id).ToArray();
                    String args = String.Join(" ", ids);
                    doDevCon("disable", args);
                }
                disableCount++;
                disableCountLabel.Text = "" + disableCount;
            }
        }
        
        private void doEnable()
        {
            lock (syncLock)
            {
                // can't enable if we have never disabled
                if (disableCount == 0)
                    return;

                // only enable if we are on the last disable
                if (disableCount == 1)
                {
                    String[] ids = deviceBindingList.Select(i => i.id).ToArray();
                    String args = String.Join(" ", ids);
                    doDevCon("enable", args);
                }
                disableCount--;
                disableCountLabel.Text = "" + disableCount;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageBindingList = new BindingList<ProgramImage>();
            imageBindingSource = new BindingSource();
            imageBindingSource.DataSource = imageBindingList;
            ProgramDataGridView.DataSource = imageBindingSource;

            deviceBindingList = new BindingList<DeviceID>();
            deviceBindingSource = new BindingSource();
            deviceBindingSource.DataSource = deviceBindingList;
            deviceDataGridView.DataSource = deviceBindingSource;

            setupWMIWatcher();
            load();
        }

        private void setupWMIWatcher()
        {
            string ComputerName = "localhost";
            string WmiQuery;
            
            ManagementScope Scope;

            Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
            Scope.Connect();

            WmiQuery = "Select * From __InstanceCreationEvent Within 1 " +
            "Where TargetInstance ISA 'Win32_Process' ";
            CreateWatcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
            CreateWatcher.EventArrived += new EventArrivedEventHandler(this.ProcessCreatedWmiEventHandler);
            CreateWatcher.Start();

            WmiQuery = "Select * From __InstanceDeletionEvent Within 1 " +
    "Where TargetInstance ISA 'Win32_Process' ";
            StoppedWatcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
            StoppedWatcher.EventArrived += new EventArrivedEventHandler(this.ProcessStoppedWmiEventHandler);
            StoppedWatcher.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.images = imageBindingList.ToList();
            data.deviceIDs = deviceBindingList.ToList();
            XmlSerializer s = new XmlSerializer(typeof(Data));
            using (FileStream fs = File.Open("save.xml", FileMode.Truncate))
            {
                s.Serialize(fs, data);
            }

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            XmlSerializer s = new XmlSerializer(typeof(Data));
            using (FileStream fs = File.OpenRead("save.xml"))
            {
                Data data = (Data)s.Deserialize(fs);
                imageBindingList.Clear();
                data.images.ForEach((i) => imageBindingList.Add(i));

                deviceBindingList.Clear();
                data.deviceIDs.ForEach((i) => deviceBindingList.Add(i));

            }
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openF1 = new OpenFileDialog();

            openF1.InitialDirectory = @"C:\";
            openF1.Title = "Browse for .exe...";
            openF1.CheckFileExists = true;
            openF1.CheckPathExists = true;
            openF1.DefaultExt = "exe";
            openF1.FileName = "";
            openF1.Filter = "(*.exe)|*.exe|All Files(*.*)|*.*";
            openF1.FilterIndex = 1;
            openF1.RestoreDirectory = true;
            openF1.ReadOnlyChecked = true;
            openF1.ShowReadOnly = true;

            if (openF1.ShowDialog() == DialogResult.OK)
            {
                imageBindingList.Add(new ProgramImage(openF1.FileName));
            }

            
        }

        private void removeImageButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ProgramDataGridView.SelectedRows)
            {
                ProgramDataGridView.Rows.Remove(row);
            }
        }

        private void addDeviceButton_Click(object sender, EventArgs e)
        {
            String id = "USB\\VID_1532&PID_0113&MI_01&JS_12";
            DialogResult res = ShowInputDialog(ref id);
            if (res == DialogResult.OK)
                deviceBindingList.Add(new DeviceID(id));
        }

        private void removeDeviceButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in deviceDataGridView.SelectedRows)
            {
                deviceDataGridView.Rows.Remove(row);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            CreateWatcher.Stop();
            StoppedWatcher.Stop();
        }

        private void disableButton_Click(object sender, EventArgs e)
        {
            doDisable();
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            doEnable();
        }


        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void disableCountLabel_Click(object sender, EventArgs e)
        {

        }
     
    }
}
