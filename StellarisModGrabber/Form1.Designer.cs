namespace StellarisModGrabber
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
            this.GrabbedListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrabBtn = new System.Windows.Forms.Button();
            this.CopyGrabBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InputListBox = new System.Windows.Forms.ListBox();
            this.CommitPasteBtn = new System.Windows.Forms.Button();
            this.PasteBtn = new System.Windows.Forms.Button();
            this.BackUpBtn = new System.Windows.Forms.Button();
            this.RestoreBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ClearModBtn = new System.Windows.Forms.Button();
            this.PresetsBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrabbedListBox
            // 
            this.GrabbedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.GrabbedListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GrabbedListBox.FormattingEnabled = true;
            this.GrabbedListBox.HorizontalScrollbar = true;
            this.GrabbedListBox.Location = new System.Drawing.Point(6, 19);
            this.GrabbedListBox.Name = "GrabbedListBox";
            this.GrabbedListBox.Size = new System.Drawing.Size(188, 277);
            this.GrabbedListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GrabbedListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grabbed List";
            // 
            // GrabBtn
            // 
            this.GrabBtn.Location = new System.Drawing.Point(18, 320);
            this.GrabBtn.Name = "GrabBtn";
            this.GrabBtn.Size = new System.Drawing.Size(89, 23);
            this.GrabBtn.TabIndex = 2;
            this.GrabBtn.Text = "Grab Mods";
            this.GrabBtn.UseVisualStyleBackColor = true;
            this.GrabBtn.Click += new System.EventHandler(this.GrabBtn_Click);
            // 
            // CopyGrabBtn
            // 
            this.CopyGrabBtn.Location = new System.Drawing.Point(117, 320);
            this.CopyGrabBtn.Name = "CopyGrabBtn";
            this.CopyGrabBtn.Size = new System.Drawing.Size(89, 23);
            this.CopyGrabBtn.TabIndex = 3;
            this.CopyGrabBtn.Text = "Copy Grab";
            this.CopyGrabBtn.UseVisualStyleBackColor = true;
            this.CopyGrabBtn.Click += new System.EventHandler(this.CopyGrabBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(218, 118);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(89, 23);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InputListBox);
            this.groupBox2.Location = new System.Drawing.Point(313, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 302);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input List";
            // 
            // InputListBox
            // 
            this.InputListBox.BackColor = System.Drawing.SystemColors.Control;
            this.InputListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.InputListBox.FormattingEnabled = true;
            this.InputListBox.HorizontalScrollbar = true;
            this.InputListBox.Location = new System.Drawing.Point(6, 19);
            this.InputListBox.Name = "InputListBox";
            this.InputListBox.Size = new System.Drawing.Size(188, 277);
            this.InputListBox.TabIndex = 0;
            // 
            // CommitPasteBtn
            // 
            this.CommitPasteBtn.Location = new System.Drawing.Point(418, 320);
            this.CommitPasteBtn.Name = "CommitPasteBtn";
            this.CommitPasteBtn.Size = new System.Drawing.Size(89, 23);
            this.CommitPasteBtn.TabIndex = 6;
            this.CommitPasteBtn.Text = "Commit Paste";
            this.CommitPasteBtn.UseVisualStyleBackColor = true;
            this.CommitPasteBtn.Click += new System.EventHandler(this.CommitPasteBtn_Click);
            // 
            // PasteBtn
            // 
            this.PasteBtn.Location = new System.Drawing.Point(319, 320);
            this.PasteBtn.Name = "PasteBtn";
            this.PasteBtn.Size = new System.Drawing.Size(89, 23);
            this.PasteBtn.TabIndex = 5;
            this.PasteBtn.Text = "Paste Mods";
            this.PasteBtn.UseVisualStyleBackColor = true;
            this.PasteBtn.Click += new System.EventHandler(this.PasteBtn_Click);
            // 
            // BackUpBtn
            // 
            this.BackUpBtn.Location = new System.Drawing.Point(218, 31);
            this.BackUpBtn.Name = "BackUpBtn";
            this.BackUpBtn.Size = new System.Drawing.Size(89, 23);
            this.BackUpBtn.TabIndex = 7;
            this.BackUpBtn.Text = "BackUp";
            this.BackUpBtn.UseVisualStyleBackColor = true;
            this.BackUpBtn.Click += new System.EventHandler(this.BackUpBtn_Click);
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.Location = new System.Drawing.Point(218, 60);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(89, 23);
            this.RestoreBtn.TabIndex = 8;
            this.RestoreBtn.Text = "Restore";
            this.RestoreBtn.UseVisualStyleBackColor = true;
            this.RestoreBtn.Click += new System.EventHandler(this.RestoreBtn_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ClearModBtn
            // 
            this.ClearModBtn.Location = new System.Drawing.Point(218, 89);
            this.ClearModBtn.Name = "ClearModBtn";
            this.ClearModBtn.Size = new System.Drawing.Size(89, 23);
            this.ClearModBtn.TabIndex = 9;
            this.ClearModBtn.Text = "Clear Mods";
            this.ClearModBtn.UseVisualStyleBackColor = true;
            this.ClearModBtn.Click += new System.EventHandler(this.ClearModBtn_Click);
            // 
            // PresetsBtn
            // 
            this.PresetsBtn.Location = new System.Drawing.Point(218, 285);
            this.PresetsBtn.Name = "PresetsBtn";
            this.PresetsBtn.Size = new System.Drawing.Size(89, 23);
            this.PresetsBtn.TabIndex = 10;
            this.PresetsBtn.Text = "Preset Control";
            this.PresetsBtn.UseVisualStyleBackColor = true;
            this.PresetsBtn.Click += new System.EventHandler(this.PresetsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(534, 353);
            this.Controls.Add(this.PresetsBtn);
            this.Controls.Add(this.ClearModBtn);
            this.Controls.Add(this.RestoreBtn);
            this.Controls.Add(this.BackUpBtn);
            this.Controls.Add(this.CommitPasteBtn);
            this.Controls.Add(this.PasteBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CopyGrabBtn);
            this.Controls.Add(this.GrabBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stellaris Mod Grabber";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox GrabbedListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GrabBtn;
        private System.Windows.Forms.Button CopyGrabBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox InputListBox;
        private System.Windows.Forms.Button CommitPasteBtn;
        private System.Windows.Forms.Button PasteBtn;
        private System.Windows.Forms.Button BackUpBtn;
        private System.Windows.Forms.Button RestoreBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ClearModBtn;
        private System.Windows.Forms.Button PresetsBtn;
    }
}

