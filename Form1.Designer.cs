namespace OpenLAV
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            CloseButton = new Label();
            tabPage4 = new TabPage();
            CopyrightText = new RichTextBox();
            tabPage1 = new TabPage();
            PathLabel = new Label();
            Console = new ListBox();
            ChooseFolder = new Button();
            progressBar = new ProgressBar();
            ScanButton = new Button();
            tabControl = new TabControl();
            tabPage2 = new TabPage();
            SHA256Copy = new Button();
            SHA256Lable = new Label();
            MD5Copy = new Button();
            PathOpen = new Button();
            MD5Lable = new Label();
            FilePathLable = new Label();
            StatusFile = new Label();
            ScanFile = new Button();
            ChooseFileButton = new Button();
            tabPage3 = new TabPage();
            RTPPATHLABEL = new Label();
            SaveConfigButton = new Button();
            ChoosePathForRTP = new Button();
            RealTimeProtection = new CheckBox();
            AutoSave = new CheckBox();
            AutoDelete = new CheckBox();
            AutoStart = new CheckBox();
            tabPage4.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.AutoSize = true;
            CloseButton.BackColor = Color.White;
            CloseButton.ForeColor = Color.Black;
            CloseButton.Location = new Point(770, 9);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(18, 20);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "X";
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(CopyrightText);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(768, 396);
            tabPage4.TabIndex = 2;
            tabPage4.Text = "About";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // CopyrightText
            // 
            CopyrightText.Location = new Point(6, 6);
            CopyrightText.Name = "CopyrightText";
            CopyrightText.Size = new Size(756, 384);
            CopyrightText.TabIndex = 0;
            CopyrightText.Text = resources.GetString("CopyrightText.Text");
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(PathLabel);
            tabPage1.Controls.Add(Console);
            tabPage1.Controls.Add(ChooseFolder);
            tabPage1.Controls.Add(progressBar);
            tabPage1.Controls.Add(ScanButton);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 396);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Folder/Disk";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // PathLabel
            // 
            PathLabel.AutoSize = true;
            PathLabel.Location = new Point(6, 38);
            PathLabel.Name = "PathLabel";
            PathLabel.Size = new Size(96, 20);
            PathLabel.TabIndex = 5;
            PathLabel.Text = "Current Path: ";
            // 
            // Console
            // 
            Console.BackColor = SystemColors.HighlightText;
            Console.ForeColor = SystemColors.InfoText;
            Console.FormattingEnabled = true;
            Console.Location = new Point(6, 96);
            Console.Name = "Console";
            Console.Size = new Size(753, 284);
            Console.TabIndex = 4;
            // 
            // ChooseFolder
            // 
            ChooseFolder.Location = new Point(6, 6);
            ChooseFolder.Name = "ChooseFolder";
            ChooseFolder.Size = new Size(756, 29);
            ChooseFolder.TabIndex = 3;
            ChooseFolder.Text = "Choose Folder To Scan";
            ChooseFolder.UseVisualStyleBackColor = true;
            ChooseFolder.Click += ChooseFolder_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 61);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(656, 29);
            progressBar.TabIndex = 1;
            // 
            // ScanButton
            // 
            ScanButton.Location = new Point(665, 61);
            ScanButton.Name = "ScanButton";
            ScanButton.Size = new Size(94, 29);
            ScanButton.TabIndex = 0;
            ScanButton.Text = "Scan";
            ScanButton.UseVisualStyleBackColor = true;
            ScanButton.Click += ScanButton_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage4);
            tabControl.Location = new Point(12, 9);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 429);
            tabControl.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(SHA256Copy);
            tabPage2.Controls.Add(SHA256Lable);
            tabPage2.Controls.Add(MD5Copy);
            tabPage2.Controls.Add(PathOpen);
            tabPage2.Controls.Add(MD5Lable);
            tabPage2.Controls.Add(FilePathLable);
            tabPage2.Controls.Add(StatusFile);
            tabPage2.Controls.Add(ScanFile);
            tabPage2.Controls.Add(ChooseFileButton);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 396);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "File";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SHA256Copy
            // 
            SHA256Copy.Location = new Point(6, 171);
            SHA256Copy.Name = "SHA256Copy";
            SHA256Copy.Size = new Size(110, 29);
            SHA256Copy.TabIndex = 8;
            SHA256Copy.Text = "Copy SHA256";
            SHA256Copy.UseVisualStyleBackColor = true;
            SHA256Copy.Click += SHA256Copy_Click;
            // 
            // SHA256Lable
            // 
            SHA256Lable.AutoSize = true;
            SHA256Lable.Location = new Point(6, 148);
            SHA256Lable.Name = "SHA256Lable";
            SHA256Lable.Size = new Size(69, 20);
            SHA256Lable.TabIndex = 7;
            SHA256Lable.Text = "SHA256: ";
            // 
            // MD5Copy
            // 
            MD5Copy.Location = new Point(6, 116);
            MD5Copy.Name = "MD5Copy";
            MD5Copy.Size = new Size(94, 29);
            MD5Copy.TabIndex = 6;
            MD5Copy.Text = "Copy MD5";
            MD5Copy.UseVisualStyleBackColor = true;
            MD5Copy.Click += MD5Copy_Click;
            // 
            // PathOpen
            // 
            PathOpen.Location = new Point(6, 61);
            PathOpen.Name = "PathOpen";
            PathOpen.Size = new Size(94, 29);
            PathOpen.TabIndex = 5;
            PathOpen.Text = "Open Path";
            PathOpen.UseVisualStyleBackColor = true;
            PathOpen.Click += PathOpen_Click;
            // 
            // MD5Lable
            // 
            MD5Lable.AutoSize = true;
            MD5Lable.Location = new Point(6, 93);
            MD5Lable.Name = "MD5Lable";
            MD5Lable.Size = new Size(48, 20);
            MD5Lable.TabIndex = 4;
            MD5Lable.Text = "MD5: ";
            // 
            // FilePathLable
            // 
            FilePathLable.AutoSize = true;
            FilePathLable.Location = new Point(6, 38);
            FilePathLable.Name = "FilePathLable";
            FilePathLable.Size = new Size(71, 20);
            FilePathLable.TabIndex = 3;
            FilePathLable.Text = "File Path: ";
            // 
            // StatusFile
            // 
            StatusFile.AutoSize = true;
            StatusFile.Location = new Point(679, 365);
            StatusFile.Name = "StatusFile";
            StatusFile.Size = new Size(83, 20);
            StatusFile.TabIndex = 2;
            StatusFile.Text = "Status: N/A";
            // 
            // ScanFile
            // 
            ScanFile.Location = new Point(6, 361);
            ScanFile.Name = "ScanFile";
            ScanFile.Size = new Size(667, 29);
            ScanFile.TabIndex = 1;
            ScanFile.Text = "Scan";
            ScanFile.UseVisualStyleBackColor = true;
            ScanFile.Click += ScanFile_Click;
            // 
            // ChooseFileButton
            // 
            ChooseFileButton.Location = new Point(6, 6);
            ChooseFileButton.Name = "ChooseFileButton";
            ChooseFileButton.Size = new Size(756, 29);
            ChooseFileButton.TabIndex = 0;
            ChooseFileButton.Text = "Choose File";
            ChooseFileButton.UseVisualStyleBackColor = true;
            ChooseFileButton.Click += ChooseFileButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(RTPPATHLABEL);
            tabPage3.Controls.Add(SaveConfigButton);
            tabPage3.Controls.Add(ChoosePathForRTP);
            tabPage3.Controls.Add(RealTimeProtection);
            tabPage3.Controls.Add(AutoSave);
            tabPage3.Controls.Add(AutoDelete);
            tabPage3.Controls.Add(AutoStart);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 396);
            tabPage3.TabIndex = 4;
            tabPage3.Text = "Config";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // RTPPATHLABEL
            // 
            RTPPATHLABEL.AutoSize = true;
            RTPPATHLABEL.Location = new Point(6, 123);
            RTPPATHLABEL.Name = "RTPPATHLABEL";
            RTPPATHLABEL.Size = new Size(96, 20);
            RTPPATHLABEL.TabIndex = 6;
            RTPPATHLABEL.Text = "Current Path: ";
            // 
            // SaveConfigButton
            // 
            SaveConfigButton.Location = new Point(668, 361);
            SaveConfigButton.Name = "SaveConfigButton";
            SaveConfigButton.Size = new Size(94, 29);
            SaveConfigButton.TabIndex = 5;
            SaveConfigButton.Text = "Save config";
            SaveConfigButton.UseVisualStyleBackColor = true;
            SaveConfigButton.Click += SaveConfigButton_Click;
            // 
            // ChoosePathForRTP
            // 
            ChoosePathForRTP.Location = new Point(513, 93);
            ChoosePathForRTP.Name = "ChoosePathForRTP";
            ChoosePathForRTP.Size = new Size(94, 29);
            ChoosePathForRTP.TabIndex = 4;
            ChoosePathForRTP.Text = "Path";
            ChoosePathForRTP.UseVisualStyleBackColor = true;
            ChoosePathForRTP.Click += ChoosePathForRTP_Click;
            // 
            // RealTimeProtection
            // 
            RealTimeProtection.AutoSize = true;
            RealTimeProtection.Location = new Point(6, 96);
            RealTimeProtection.Name = "RealTimeProtection";
            RealTimeProtection.Size = new Size(501, 24);
            RealTimeProtection.TabIndex = 3;
            RealTimeProtection.Text = "Real time protection (It will not rescan files that are already in the Path)";
            RealTimeProtection.UseVisualStyleBackColor = true;
            RealTimeProtection.CheckedChanged += RealTimeProtection_CheckedChanged;
            // 
            // AutoSave
            // 
            AutoSave.AutoSize = true;
            AutoSave.Location = new Point(6, 66);
            AutoSave.Name = "AutoSave";
            AutoSave.Size = new Size(144, 24);
            AutoSave.TabIndex = 2;
            AutoSave.Text = "Auto save output";
            AutoSave.UseVisualStyleBackColor = true;
            // 
            // AutoDelete
            // 
            AutoDelete.AutoSize = true;
            AutoDelete.Location = new Point(6, 36);
            AutoDelete.Name = "AutoDelete";
            AutoDelete.Size = new Size(143, 24);
            AutoDelete.TabIndex = 1;
            AutoDelete.Text = "Auto delete virus";
            AutoDelete.UseVisualStyleBackColor = true;
            // 
            // AutoStart
            // 
            AutoStart.AutoSize = true;
            AutoStart.Location = new Point(6, 6);
            AutoStart.Name = "AutoStart";
            AutoStart.Size = new Size(145, 24);
            AutoStart.TabIndex = 0;
            AutoStart.Text = "Start with System";
            AutoStart.UseVisualStyleBackColor = true;
            AutoStart.CheckedChanged += AutoStart_CheckedChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(CloseButton);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            tabPage4.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CloseButton;
        private TabPage tabPage4;
        private TabPage tabPage1;
        private TabControl tabControl;
        private ProgressBar progressBar;
        private Button ScanButton;
        private Button ChooseFolder;
        private ListBox Console;
        private TabPage tabPage2;
        private Button ChooseFileButton;
        private Button ScanFile;
        private Label StatusFile;
        private Label FilePathLable;
        private Label MD5Lable;
        private TabPage tabPage3;
        private CheckBox AutoSave;
        private CheckBox AutoDelete;
        private CheckBox AutoStart;
        private CheckBox RealTimeProtection;
        private Button ChoosePathForRTP;
        private Button SaveConfigButton;
        private Label PathLabel;
        private Label RTPPATHLABEL;
        private Button MD5Copy;
        private Button PathOpen;
        private RichTextBox CopyrightText;
        private Button SHA256Copy;
        private Label SHA256Lable;
    }
}
