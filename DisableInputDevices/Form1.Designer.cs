namespace DisableInputDevices
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ProgramDataGridView = new System.Windows.Forms.DataGridView();
            this.deviceDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageButton = new System.Windows.Forms.Button();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.addDeviceButton = new System.Windows.Forms.Button();
            this.removeDeviceButton = new System.Windows.Forms.Button();
            this.disableButton = new System.Windows.Forms.Button();
            this.enableButton = new System.Windows.Forms.Button();
            this.disableCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceDataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramDataGridView
            // 
            this.ProgramDataGridView.AllowUserToAddRows = false;
            this.ProgramDataGridView.AllowUserToDeleteRows = false;
            this.ProgramDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProgramDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProgramDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ProgramDataGridView.Name = "ProgramDataGridView";
            this.ProgramDataGridView.RowHeadersVisible = false;
            this.ProgramDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProgramDataGridView.Size = new System.Drawing.Size(322, 150);
            this.ProgramDataGridView.TabIndex = 0;
            // 
            // deviceDataGridView
            // 
            this.deviceDataGridView.AllowUserToAddRows = false;
            this.deviceDataGridView.AllowUserToDeleteRows = false;
            this.deviceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceDataGridView.Location = new System.Drawing.Point(340, 12);
            this.deviceDataGridView.Name = "deviceDataGridView";
            this.deviceDataGridView.RowHeadersVisible = false;
            this.deviceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deviceDataGridView.Size = new System.Drawing.Size(391, 150);
            this.deviceDataGridView.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 252);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(94, 251);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(655, 251);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Minimized Text";
            this.notifyIcon1.BalloonTipTitle = "Minimized Title";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Device Disabler";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStrip});
            this.contextMenuStrip.Name = "contextMenuStrip_Exit";
            this.contextMenuStrip.Size = new System.Drawing.Size(93, 26);
            this.contextMenuStrip.Text = "Exit";
            // 
            // exitToolStrip
            // 
            this.exitToolStrip.Name = "exitToolStrip";
            this.exitToolStrip.Size = new System.Drawing.Size(92, 22);
            this.exitToolStrip.Text = "Exit";
            this.exitToolStrip.Click += new System.EventHandler(this.exitToolStrip_Click);
            // 
            // addImageButton
            // 
            this.addImageButton.Location = new System.Drawing.Point(12, 169);
            this.addImageButton.Name = "addImageButton";
            this.addImageButton.Size = new System.Drawing.Size(75, 23);
            this.addImageButton.TabIndex = 5;
            this.addImageButton.Text = "Add";
            this.addImageButton.UseVisualStyleBackColor = true;
            this.addImageButton.Click += new System.EventHandler(this.addImageButton_Click);
            // 
            // removeImageButton
            // 
            this.removeImageButton.Location = new System.Drawing.Point(94, 169);
            this.removeImageButton.Name = "removeImageButton";
            this.removeImageButton.Size = new System.Drawing.Size(75, 23);
            this.removeImageButton.TabIndex = 6;
            this.removeImageButton.Text = "Remove";
            this.removeImageButton.UseVisualStyleBackColor = true;
            this.removeImageButton.Click += new System.EventHandler(this.removeImageButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // addDeviceButton
            // 
            this.addDeviceButton.Location = new System.Drawing.Point(340, 169);
            this.addDeviceButton.Name = "addDeviceButton";
            this.addDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.addDeviceButton.TabIndex = 7;
            this.addDeviceButton.Text = "Add Device";
            this.addDeviceButton.UseVisualStyleBackColor = true;
            this.addDeviceButton.Click += new System.EventHandler(this.addDeviceButton_Click);
            // 
            // removeDeviceButton
            // 
            this.removeDeviceButton.Location = new System.Drawing.Point(422, 169);
            this.removeDeviceButton.Name = "removeDeviceButton";
            this.removeDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.removeDeviceButton.TabIndex = 8;
            this.removeDeviceButton.Text = "Remove";
            this.removeDeviceButton.UseVisualStyleBackColor = true;
            this.removeDeviceButton.Click += new System.EventHandler(this.removeDeviceButton_Click);
            // 
            // disableButton
            // 
            this.disableButton.Location = new System.Drawing.Point(267, 251);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(75, 23);
            this.disableButton.TabIndex = 9;
            this.disableButton.Text = "Disable";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.Click += new System.EventHandler(this.disableButton_Click);
            // 
            // enableButton
            // 
            this.enableButton.Location = new System.Drawing.Point(349, 251);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(75, 23);
            this.enableButton.TabIndex = 10;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
            // 
            // disableCountLabel
            // 
            this.disableCountLabel.AutoSize = true;
            this.disableCountLabel.Location = new System.Drawing.Point(95, 211);
            this.disableCountLabel.Name = "disableCountLabel";
            this.disableCountLabel.Size = new System.Drawing.Size(13, 13);
            this.disableCountLabel.TabIndex = 11;
            this.disableCountLabel.Text = "0";
            this.disableCountLabel.Click += new System.EventHandler(this.disableCountLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Disable Count:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disableCountLabel);
            this.Controls.Add(this.enableButton);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.removeDeviceButton);
            this.Controls.Add(this.addDeviceButton);
            this.Controls.Add(this.removeImageButton);
            this.Controls.Add(this.addImageButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deviceDataGridView);
            this.Controls.Add(this.ProgramDataGridView);
            this.Name = "Form1";
            this.Text = "Device Disabler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ProgramDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceDataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProgramDataGridView;
        private System.Windows.Forms.DataGridView deviceDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStrip;
        private System.Windows.Forms.Button addImageButton;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button addDeviceButton;
        private System.Windows.Forms.Button removeDeviceButton;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Label disableCountLabel;
        private System.Windows.Forms.Label label1;
    }
}

