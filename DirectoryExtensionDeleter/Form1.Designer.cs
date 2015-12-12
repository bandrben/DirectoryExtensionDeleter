namespace DirectoryExtensionDeleter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.btnDeleteFiles = new System.Windows.Forms.Button();
            this.cblExtensions = new System.Windows.Forms.CheckedListBox();
            this.tbSelFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDelEmptyDirs = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbCheckAll = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLogoNormal = new System.Windows.Forms.PictureBox();
            this.pbLogoWait = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoWait)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(12, 30);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatus.BackColor = System.Drawing.SystemColors.Info;
            this.tbStatus.Location = new System.Drawing.Point(12, 412);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(468, 216);
            this.tbStatus.TabIndex = 1;
            this.tbStatus.WordWrap = false;
            // 
            // btnDeleteFiles
            // 
            this.btnDeleteFiles.Location = new System.Drawing.Point(12, 356);
            this.btnDeleteFiles.Name = "btnDeleteFiles";
            this.btnDeleteFiles.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFiles.TabIndex = 2;
            this.btnDeleteFiles.Text = "Delete Files";
            this.btnDeleteFiles.UseVisualStyleBackColor = true;
            this.btnDeleteFiles.Click += new System.EventHandler(this.btnDeleteFiles_Click);
            // 
            // cblExtensions
            // 
            this.cblExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblExtensions.FormattingEnabled = true;
            this.cblExtensions.Location = new System.Drawing.Point(12, 62);
            this.cblExtensions.Name = "cblExtensions";
            this.cblExtensions.Size = new System.Drawing.Size(410, 259);
            this.cblExtensions.TabIndex = 3;
            // 
            // tbSelFolder
            // 
            this.tbSelFolder.Location = new System.Drawing.Point(176, 33);
            this.tbSelFolder.Name = "tbSelFolder";
            this.tbSelFolder.Size = new System.Drawing.Size(246, 20);
            this.tbSelFolder.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status:";
            // 
            // cbDelEmptyDirs
            // 
            this.cbDelEmptyDirs.AutoSize = true;
            this.cbDelEmptyDirs.Location = new System.Drawing.Point(93, 360);
            this.cbDelEmptyDirs.Name = "cbDelEmptyDirs";
            this.cbDelEmptyDirs.Size = new System.Drawing.Size(142, 17);
            this.cbDelEmptyDirs.TabIndex = 7;
            this.cbDelEmptyDirs.Text = "Delete empty directories.";
            this.cbDelEmptyDirs.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 327);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbCheckAll
            // 
            this.lbCheckAll.AutoSize = true;
            this.lbCheckAll.Location = new System.Drawing.Point(321, 327);
            this.lbCheckAll.Name = "lbCheckAll";
            this.lbCheckAll.Size = new System.Drawing.Size(101, 13);
            this.lbCheckAll.TabIndex = 9;
            this.lbCheckAll.TabStop = true;
            this.lbCheckAll.Text = "Check/Uncheck All";
            this.lbCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCheckAll_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pbLogoNormal
            // 
            this.pbLogoNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogoNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogoNormal.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoNormal.Image")));
            this.pbLogoNormal.Location = new System.Drawing.Point(432, 33);
            this.pbLogoNormal.Name = "pbLogoNormal";
            this.pbLogoNormal.Size = new System.Drawing.Size(52, 70);
            this.pbLogoNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogoNormal.TabIndex = 11;
            this.pbLogoNormal.TabStop = false;
            this.pbLogoNormal.Click += new System.EventHandler(this.pbLogoNormal_Click);
            // 
            // pbLogoWait
            // 
            this.pbLogoWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogoWait.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoWait.Image")));
            this.pbLogoWait.Location = new System.Drawing.Point(432, 33);
            this.pbLogoWait.Name = "pbLogoWait";
            this.pbLogoWait.Size = new System.Drawing.Size(52, 70);
            this.pbLogoWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogoWait.TabIndex = 12;
            this.pbLogoWait.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(492, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 662);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbLogoNormal);
            this.Controls.Add(this.lbCheckAll);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbDelEmptyDirs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSelFolder);
            this.Controls.Add(this.cblExtensions);
            this.Controls.Add(this.btnDeleteFiles);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pbLogoWait);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(508, 700);
            this.Name = "Form1";
            this.Text = "Directory Extension Deleter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnDeleteFiles;
        private System.Windows.Forms.CheckedListBox cblExtensions;
        private System.Windows.Forms.TextBox tbSelFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbDelEmptyDirs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel lbCheckAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbLogoNormal;
        private System.Windows.Forms.PictureBox pbLogoWait;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

