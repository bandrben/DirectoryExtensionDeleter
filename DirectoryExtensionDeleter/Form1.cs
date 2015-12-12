using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectoryExtensionDeleter.classes;
using DirectoryExtensionDeleter.classes.CustObjs;
using System.IO;

namespace DirectoryExtensionDeleter
{
    public partial class Form1 : Form
    {

        BackgroundWorker bg1;
        FolderBrowserDialog folderBrowserDialog1;
        string path;
        string exts; // ex. ext1|ext2|ext3
        string msg;
        AboutBox1 aboutBox1;

        /// <summary>
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            folderBrowserDialog1 = new FolderBrowserDialog();
            path = "";
            msg = "";

            btnOpenFolder.Enabled = true;
            btnDeleteFiles.Enabled = false;

            pbLogoNormal.Visible = true;
            pbLogoWait.Visible = false;

            tbSelFolder.TextChanged += tbSelFolder_TextChanged;

            this.FormClosing += Form1_FormClosing;

            if (!RegistryHelper.GetRegStuff(out path, out exts, out msg))
            {
                cout("ERROR: " + msg);
            }

            tbSelFolder.Text = path;
        }

        /// <summary>
        /// </summary>
        void tbSelFolder_TextChanged(object sender, EventArgs e)
        {
            path = tbSelFolder.Text;
        }

        /// <summary>
        /// </summary>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var lstCheckedExts = new List<string>();
            foreach (var item in cblExtensions.CheckedItems)
            {
                lstCheckedExts.Add(item.ToString());
            }
            exts = string.Join("|", lstCheckedExts.ToArray());

            if (!RegistryHelper.SaveRegStuff(path, exts, out msg))
            {
                cout("ERROR: " + msg);
            }

            if (aboutBox1 != null)
            {
                aboutBox1.Close();
            }
        }

        /// <summary>
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetFileExtensionsFromFolder(path);
        }

        /// <summary>
        /// </summary>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (!GenUtil.IsNull(path))
            {
                folderBrowserDialog1.SelectedPath = path;
            }

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                tbSelFolder.Text = path;
                GetFileExtensionsFromFolder(path);
            }
        }

        /// <summary>
        /// </summary>
        void GetFileExtensionsFromFolder(string path)
        {
            if (GenUtil.IsNull(path))
            {
                cout("Path not found.");
                return;
            }

            cout("Getting file extensions from path: " + path);

            bg1 = new BackgroundWorker();
            bg1.DoWork += bg1_DoWork_GetFileExtensions;
            bg1.RunWorkerCompleted += bg1_RunWorkerCompleted_GetFileExtensions;
            bg1.RunWorkerAsync(new BgPassObject_GetFileExtensions() { path = path });

            btnOpenFolder.Enabled = false;
            btnDeleteFiles.Enabled = false;

            pbLogoNormal.Visible = false;
            pbLogoWait.Visible = true;

            cblExtensions.Items.Clear();
        }

        /// <summary>
        /// </summary>
        void bg1_DoWork_GetFileExtensions(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(250);

            var obj = (BgPassObject_GetFileExtensions)e.Argument;

            try
            {
                // get all files (and extensions) from directory (recursive search)
                var di = new DirectoryInfo(obj.path);
                var lstFileExtensions = new List<string>();

                foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    if (!GenUtil.IsNull(fi.Extension) && !lstFileExtensions.Contains(fi.Extension.ToUpper().TrimStart(new char[] { '.' })))
                    {
                        lstFileExtensions.Add(fi.Extension.ToUpper().TrimStart(new char[] { '.' }));
                    }
                }

                // sort extensions
                lstFileExtensions = lstFileExtensions.OrderBy(x => x).ToList();

                e.Result = new BgResultObject_GetFileExtensions() { lstFileExtensions = lstFileExtensions, msg = "" };

            }
            catch (Exception ex)
            {
                e.Result = new BgResultObject_GetFileExtensions() { lstFileExtensions = null, msg = ex.Message };
            }
        }

        /// <summary>
        /// </summary>
        void bg1_RunWorkerCompleted_GetFileExtensions(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOpenFolder.Enabled = true;

            pbLogoNormal.Visible = true;
            pbLogoWait.Visible = false;

            var obj = (BgResultObject_GetFileExtensions)e.Result;

            if (!GenUtil.IsNull(obj.msg))
            {
                cout("ERROR: " + obj.msg);
                return; 
            }

            cout(string.Format("Found {0} extension(s).", obj.lstFileExtensions.Count));

            // get saved extensions
            var lstSavedExtensions = new List<string>();
            exts = GenUtil.SafeTrim(exts);
            foreach (string s in exts.Split(new char[] { '|' }))
            {
                lstSavedExtensions.Add(GenUtil.SafeTrim(s).ToUpper());
            }

            var sb = new StringBuilder();

            // add extensions to checkboxlist (and preselect them)
            cblExtensions.Items.Clear();
            foreach (string ext in obj.lstFileExtensions)
            {
                cblExtensions.Items.Add(ext, lstSavedExtensions.Contains(ext));
                sb.Append(string.Format("*.{0};", GenUtil.SafeTrim(ext).ToUpper()));
            }

            btnDeleteFiles.Enabled = obj.lstFileExtensions.Any();

            cout("Extensions dump:");
            cout(sb.ToString());

            cout("READY.");
        }

        /// <summary>
        /// </summary>
        private void btnDeleteFiles_Click(object sender, EventArgs e)
        {
            var lstCheckedExts = new List<string>();
            foreach (var item in cblExtensions.CheckedItems)
            {
                lstCheckedExts.Add(item.ToString());
            }

            if (!lstCheckedExts.Any())
            {
                cout("No extensions selected, nothing deleted.");
                return;
            }

            if (GenUtil.IsNull(path))
            {
                cout("Path not found.");
                return;
            }

            bg1 = new BackgroundWorker();
            bg1.DoWork += bg1_DoWork_DeleteFiles;
            bg1.RunWorkerCompleted += bg1_RunWorkerCompleted_DeleteFiles;
            bg1.RunWorkerAsync(new BgPassObject_DeleteFiles() { path = path, lstCheckedExts = lstCheckedExts, deleteEmptyDirs = cbDelEmptyDirs.Checked });

            btnDeleteFiles.Enabled = false;
            btnOpenFolder.Enabled = false;

            pbLogoNormal.Visible = false;
            pbLogoWait.Visible = true;
        }

        /// <summary>
        /// </summary>
        void bg1_DoWork_DeleteFiles(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(250);
            var obj = (BgPassObject_DeleteFiles)e.Argument;

            var lstFilesBeingDeleted = new List<string>();
            var lstDirsBeingDeleted = new List<string>();

            try
            {
                // load directory
                var di = new DirectoryInfo(obj.path);

                if (!di.Exists)
                {
                    throw new Exception("Directory not found, does not exist.");
                }

                // delete files with matching extensions
                foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    if (!GenUtil.IsNull(fi.Extension) && obj.lstCheckedExts.Contains(fi.Extension.ToUpper().TrimStart(new char[] { '.' })))
                    {
                        lstFilesBeingDeleted.Add(fi.FullName);
                        fi.Delete();
                    }
                }

                // delete empty directories
                if (obj.deleteEmptyDirs)
                {
                    bool loopAgain;
                    do
                    {
                        loopAgain = false;
                        foreach (var dir in di.GetDirectories("*", SearchOption.AllDirectories))
                        {
                            var dirCount = dir.GetDirectories().Count();
                            var fileCount = dir.GetFiles().Count();

                            if (dirCount == 0 && fileCount == 0)
                            {
                                lstDirsBeingDeleted.Add(dir.FullName);
                                dir.Delete();
                                loopAgain = true;
                            }
                        }

                    } while (loopAgain);
                }

                e.Result = new BgResultObject_DeleteFiles() { lstFilesBeingDeleted = lstFilesBeingDeleted, lstDirsBeingDeleted = lstDirsBeingDeleted, lstCheckedExts = obj.lstCheckedExts, msg = "" };
            }
            catch (Exception ex)
            {
                e.Result = new BgResultObject_DeleteFiles() { msg = ex.Message };
            }
        }

        /// <summary>
        /// </summary>
        void bg1_RunWorkerCompleted_DeleteFiles(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDeleteFiles.Enabled = true;
            btnOpenFolder.Enabled = true;

            pbLogoNormal.Visible = true;
            pbLogoWait.Visible = false;

            var obj = (BgResultObject_DeleteFiles)e.Result;

            if (!GenUtil.IsNull(obj.msg))
            {
                cout("ERROR: " + obj.msg);
                return;
            }

            cout("Files that were deleted:");

            int i = 0;
            foreach (var file in obj.lstFilesBeingDeleted)
            {
                i++;
                cout(string.Format("{0}. {1}", i, file));
            }

            if (cbDelEmptyDirs.Checked)
            {
                if (obj.lstDirsBeingDeleted.Any())
                {
                    cout("Directories that were deleted:");

                    int k = 0;
                    foreach (var dir in obj.lstDirsBeingDeleted)
                    {
                        k++;
                        cout(string.Format("{0}. {1}", k, dir));
                    }
                }
                else
                {
                    cout("No directories deleted.");
                }
            }

            foreach (var ext in obj.lstCheckedExts)
            {
                cblExtensions.Items.Remove(ext);
            }

            cout("DONE.");
        }

        /// <summary>
        /// </summary>
        private void lbCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool anyChecked = cblExtensions.CheckedItems.Count > 0;

            if (cblExtensions.CheckedItems.Count == cblExtensions.Items.Count)
                anyChecked = !anyChecked;

            if (cblExtensions.CheckedItems.Count == 0)
                anyChecked = !anyChecked;

            for (int i = 0; i < cblExtensions.Items.Count; i++)
            {
                cblExtensions.SetItemChecked(i, anyChecked);
            }
        }

        /// <summary>
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutBox1 != null)
                aboutBox1.Close();

            aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        /// <summary>
        /// </summary>
        private void pbLogoNormal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bandrsolutions.com/?utm_source=DirectoryExtensionDeleter&utm_medium=application&utm_campaign=DirectoryExtensionDeleter");
        }

        /// <summary>
        /// With datetime prepended.
        /// </summary>
        void cout(string str)
        {
            tbStatus.Text = string.Format("{2}: {3}{1}{0}",
                tbStatus.Text,
                GenUtil.IsNull(tbStatus.Text) ? "" : Environment.NewLine,
                DateTime.Now.ToLongTimeString(),
                str);
        }

    }
}
