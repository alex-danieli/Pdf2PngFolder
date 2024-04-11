
using System.Diagnostics;

namespace Pdf2PngFolder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(583, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(517, 699);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 32);
            label1.Name = "label1";
            label1.Size = new Size(421, 74);
            label1.TabIndex = 1;
            label1.Text = "Pdf2PngFolder";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(24, 106);
            label2.Name = "label2";
            label2.Size = new Size(182, 25);
            label2.TabIndex = 2;
            label2.Text = "@ 2024 - Alex Danieli";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.White;
            progressBar1.Location = new Point(24, 689);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(528, 34);
            progressBar1.TabIndex = 3;
            progressBar1.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(24, 641);
            button1.Name = "button1";
            button1.Size = new Size(142, 34);
            button1.TabIndex = 4;
            button1.Text = "Select Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(24, 149);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(528, 479);
            listBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(410, 641);
            button2.Name = "button2";
            button2.Size = new Size(142, 34);
            button2.TabIndex = 6;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1122, 749);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
               
               ProcessDirectory(folderBrowserDialog1.SelectedPath);
            }
            
        }

        #endregion


        #region Directory Recursive Visit
        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public  void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            Debug.WriteLine("DIRECTORY: " + targetDirectory);
            listBox1.Items.Add("Processed DIRECTORY: " + targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public  void ProcessFile(string path)
        {
            listBox1.Items.Add("Processed FILE: " + Path.GetFileName(path));
            FileInfo fi = new FileInfo(path);

            // Debug.WriteLine("FILE ext: " + fi.Extension);
            if (fi.Extension.ToLower()==".pdf")
            {
                Program.ConvertPdfToPngPages(path, 300);
            }
            // 
            // listBox1.Items.Add("Processed FILE: " + fi.Extension);
            // Debug.WriteLine("Processed FILE: " + Path.GetFileName(path));
        }
        #endregion


        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button button2;
        private ListBox listBox1;
    }
}
