using Microsoft.Win32;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace OpenLAV
{
    public partial class MainWindow : Form
    {
        String AppsName = "OpenLAV";
        String Version = "Build: 01012024 Verison: 1.0";

        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public MainWindow()
        {
            InitializeComponent();
            RealTimeProtection.Checked = false;
            CopyrightText.ReadOnly = true;
            ScanButton.Enabled = false;
            ScanFile.Enabled = false;

            AutoStart.Checked = Properties.Settings.Default.AutoStart;
            AutoDelete.Checked = Properties.Settings.Default.AutoDelete;
            AutoSave.Checked = Properties.Settings.Default.AutoSave;
            RealTimeProtection.Checked = Properties.Settings.Default.RTP;

            if (AutoStart.Checked)
                rk.SetValue(AppsName, Assembly.GetExecutingAssembly().Location);
            else
            {
                if (rk.GetValue(AppsName) != null)
                {
                    rk.DeleteValue(AppsName, false);
                }
            }

            UpdateRTP();
        }

        public static string LoadMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        public static string LoadSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }

        }

        public string[] GetAccessibleFiles(string path)
        {
            List<string> result = new List<string>();

            try
            {
                result.AddRange(Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly));
                foreach (var directory in Directory.GetDirectories(path))
                {
                    result.AddRange(GetAccessibleFiles(directory));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // SKIP //
            }

            return result.ToArray();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (RealTimeProtection.Checked)
                this.Visible = false;
            else Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Black;
            CloseButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.White;
            CloseButton.ForeColor = Color.Black;
        }

        // PROCESSING

        public void VirusFoundWarning(string filePath)
        {
            if (AutoDelete.Checked)
            {
                VirusDeletedAuto(filePath);
            }
            else
            {
                string message = $"The file at {filePath} is detected as a virus. Do you want to remove it?";
                string caption = "Virus Warning";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(filePath);
                        MessageBox.Show("File removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while trying to delete the file: {ex.Message}");
                    }
                }
                else
                {
                    // NULL
                }
            }
        }

        public void VirusDeletedAuto(string filePath)
        {
            string message;
            string caption;
            try
            {
                File.Delete(filePath);
                message = $"The virus file at {filePath} has been deleted.";
                caption = "File Deleted";
            }
            catch (Exception ex)
            {
                message = $"The Anti Virus was unable to delete the virus file at {filePath}.";
                caption = "Deletion Failed";
            }


            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void SaveLogFile(ListBox console)
        {
            if (AutoSave.Checked)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Output";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (var item in console.Items)
                            {
                                sw.WriteLine(item.ToString());
                            }
                        }
                        MessageBox.Show("Output saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while trying to save the file: {ex.Message}");
                    }
                }
            }
            else
            {
                string message = "Do you want to save the output to a file?";
                string caption = "Save Output";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Save Output";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                            {
                                foreach (var item in console.Items)
                                {
                                    sw.WriteLine(item.ToString());
                                }
                            }
                            MessageBox.Show("Output saved successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while trying to save the file: {ex.Message}");
                        }
                    }
                }
            }
        }

        public void ShowScanResults(int virusNumber, int safeNumber)
        {
            string message = $"Scan completed.\n\nViruses found: {virusNumber}\nSafe files: {safeNumber}";
            string caption = "Scan Results";

            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // FOLDER/DISK

        string[] files = { "" };
        string[] viruses = { "" };

        private void ChooseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = GetAccessibleFiles(fbd.SelectedPath);
                    PathLabel.Text = "Current Path: " + fbd.SelectedPath;
                    ScanButton.Enabled = true;
                }
            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            ScanButton.Enabled = false;
            ChooseFolder.Enabled = false;
            Console.Items.Clear();

            int PROCESSING = 0;
            int VIRUSNUMBER = 0;
            int SAFENUMBER = 0;
            string ScaningFile1;
            string ScaningFile2;

            progressBar.Maximum = files.Length - 1;
            progressBar.Minimum = 0;

            progressBar.Value = (files.Length - 1) / 2;
            var md5signatures = File.ReadAllLines("Viruslist.md5");
            var sha256signatures = File.ReadAllLines("Viruslist.sha256");
            Console.Items.Add("Loaded Virus List.");
            var OpenLAVScanner = new AntiVirus.Scanner();
            Console.Items.Add("Loaded OpenLAV Scanner.");
            progressBar.Value = files.Length - 1;

            progressBar.Value = 0;

            for (PROCESSING = 0; PROCESSING < files.Length; PROCESSING++)
            {
                ScaningFile1 = LoadMD5(files[PROCESSING]);
                ScaningFile2 = LoadSHA256(files[PROCESSING]);
                var isVirusByOpenLAV = OpenLAVScanner.ScanAndClean(files[PROCESSING]);
                if (sha256signatures.Contains(ScaningFile2) || md5signatures.Contains(ScaningFile1) || isVirusByOpenLAV.ToString() != "VirusNotFound")
                {
                    Console.Items.Add("Virus: " + files[PROCESSING]);
                    Console.Refresh();

                    VIRUSNUMBER++;
                    VirusFoundWarning(files[PROCESSING]);
                }
                else
                {
                    Console.Items.Add("Safe: " + files[PROCESSING]);
                    Console.Refresh();

                    SAFENUMBER++;
                }

                progressBar.Value = PROCESSING;
            }

            ShowScanResults(VIRUSNUMBER, SAFENUMBER);
            Console.Items.Add("Viruses found: " + VIRUSNUMBER);
            Console.Items.Add("Safe files: " + SAFENUMBER);
            SaveLogFile(Console);

            ScanButton.Enabled = true;
            ChooseFolder.Enabled = true;
        }

        // FILE

        String MD5Data = "NULL";
        string SHA256Data = "NULL";
        String RawPath = "NULL";

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MD5Data = LoadMD5(ofd.FileName);
                SHA256Data = LoadSHA256(ofd.FileName);
            }
            RawPath = ofd.FileName;
            FilePathLable.Text += ofd.FileName;
            MD5Lable.Text += MD5Data;
            SHA256Lable.Text += SHA256Data;
            ScanFile.Enabled = true;
        }

        private void ScanFile_Click(object sender, EventArgs e)
        {
            ScanFile.Enabled = false;
            ChooseFileButton.Enabled = false;
            var md5signatures = File.ReadAllLines("Viruslist.md5");
            var sha256signatures = File.ReadAllLines("Viruslist.sha256");
            if (sha256signatures.Contains(SHA256Data) || md5signatures.Contains(MD5Data))
            {
                StatusFile.Text = "Status: Virus!";
                StatusFile.ForeColor = Color.Red;

                VirusFoundWarning(RawPath);
            }

            else
            {
                StatusFile.Text = "Status: Safe!";
                StatusFile.ForeColor = Color.Green;
            }

            ScanFile.Enabled = true;
            ChooseFileButton.Enabled = true;
        }

        private void AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoStart.Checked)
                rk.SetValue(AppsName, Assembly.GetExecutingAssembly().Location);
            else
            {
                if (rk.GetValue(AppsName) != null)
                {
                    rk.DeleteValue(AppsName, false);
                }
            }
        }

        // REAL TIME

        String directory = Properties.Settings.Default.RTPPath;
        private static String[] md5signaturesRealTime = { "" };
        private static String[] sha256signaturesRealTime = { "" };
        private static FileSystemWatcher watcher;

        private void UpdateRTP()
        {
            RTPPATHLABEL.Text = "Current Path: " + directory;
            if (directory == "")
            {
                RealTimeProtection.Checked = false;
                RealTimeProtection.Enabled = false;
            }

            if (RealTimeProtection.Checked)
            {
                RealTimeProtection.Checked = true;
            }
        }

        private void ChoosePathForRTP_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directory = new DirectoryInfo(fbd.SelectedPath).ToString();
                    RealTimeProtection.Enabled = true;
                }
            }
            RTPPATHLABEL.Text = "Current Path: " + directory;
        }

        // DOING REAL TIME

        static bool AutoDeleteStatic = Properties.Settings.Default.AutoDelete;

        static void RealTimeWatcher(String RealTimeDir)
        {
            watcher = new FileSystemWatcher(RealTimeDir)
            {
                NotifyFilter = NotifyFilters.LastWrite
                             | NotifyFilters.FileName
            };

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static ConcurrentDictionary<string, byte> processingFiles = new ConcurrentDictionary<string, byte>();

        private static async void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!processingFiles.TryAdd(e.FullPath, 0))
            {
                return;
            }
            try
            {
                if (File.Exists(e.FullPath) == false) { return; }

                string MD5Data = null;
                string SHA256Data = null;
                var OpenLAVScanner = new AntiVirus.Scanner();
                for (int i = 0; i < 3; ++i)
                {
                    try
                    {
                        MD5Data = LoadMD5(e.FullPath);
                        SHA256Data = LoadSHA256(e.FullPath);
                        break;
                    }
                    catch (IOException)
                    {
                        await Task.Delay(1000);
                    }
                }

                if (MD5Data == null)
                {
                    return;
                }

                var isVirusByOpenLAV = OpenLAVScanner.ScanAndClean(e.FullPath);

                if (sha256signaturesRealTime.Contains(SHA256Data) || md5signaturesRealTime.Contains(MD5Data) || isVirusByOpenLAV.ToString() != "VirusNotFound")
                {
                    AutoDeleteStatic = Properties.Settings.Default.AutoDelete;
                    if (AutoDeleteStatic == false)
                    {
                        string message = $"The file at {e.FullPath} is detected as a virus. Do you want to remove it?";
                        string caption = "Virus Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                File.Delete(e.FullPath);
                                MessageBox.Show("File removed successfully.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while trying to delete the file: {ex.Message}");
                            }
                        }
                        else
                        {
                            // NULL
                        }
                    }
                    else
                    {
                        string message;
                        string caption;
                        try
                        {
                            File.Delete(e.FullPath);
                            message = $"The virus file at {e.FullPath} has been deleted.";
                            caption = "File Deleted";
                        }
                        catch (Exception ex)
                        {
                            message = $"The Anti Virus was unable to delete the virus file at {e.FullPath}.";
                            caption = "Deletion Failed";
                        }

                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            finally
            {
                byte removed;
                processingFiles.TryRemove(e.FullPath, out removed);
            }
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = AutoStart.Checked;
            Properties.Settings.Default.AutoDelete = AutoDelete.Checked;
            Properties.Settings.Default.AutoSave = AutoSave.Checked;
            Properties.Settings.Default.RTP = RealTimeProtection.Checked;
            Properties.Settings.Default.RTPPath = directory;

            Properties.Settings.Default.Save();
        }

        private void RealTimeProtection_CheckedChanged(object sender, EventArgs e)
        {
            if (RealTimeProtection.Checked)
            {
                md5signaturesRealTime = File.ReadAllLines("Viruslist.md5");
                sha256signaturesRealTime = File.ReadAllLines("Viruslist.sha256");
                RealTimeWatcher(directory);
            }
            else
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        private void PathOpen_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = RawPath,
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }

        private void MD5Copy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(MD5Data);
        }

        private void SHA256Copy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SHA256Data);
        }
    }
}
