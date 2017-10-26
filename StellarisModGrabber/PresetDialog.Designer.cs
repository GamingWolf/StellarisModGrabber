namespace StellarisModGrabber
{
    partial class PresetDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetDialog));
            this.PresetContent = new System.Windows.Forms.ListBox();
            this.PresetGrpBox = new System.Windows.Forms.GroupBox();
            this.PresetSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FromCurrentBtn = new System.Windows.Forms.Button();
            this.FromPasteBtn = new System.Windows.Forms.Button();
            this.DeletePresetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PresetName = new System.Windows.Forms.TextBox();
            this.LoadPresetBtn = new System.Windows.Forms.Button();
            this.PresetGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PresetContent
            // 
            this.PresetContent.BackColor = System.Drawing.SystemColors.Control;
            this.PresetContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PresetContent.FormattingEnabled = true;
            this.PresetContent.Location = new System.Drawing.Point(6, 19);
            this.PresetContent.Name = "PresetContent";
            this.PresetContent.Size = new System.Drawing.Size(188, 277);
            this.PresetContent.TabIndex = 0;
            // 
            // PresetGrpBox
            // 
            this.PresetGrpBox.Controls.Add(this.PresetContent);
            this.PresetGrpBox.Location = new System.Drawing.Point(12, 12);
            this.PresetGrpBox.Name = "PresetGrpBox";
            this.PresetGrpBox.Size = new System.Drawing.Size(200, 302);
            this.PresetGrpBox.TabIndex = 2;
            this.PresetGrpBox.TabStop = false;
            this.PresetGrpBox.Text = "Please Select a Preset";
            // 
            // PresetSelectBox
            // 
            this.PresetSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetSelectBox.FormattingEnabled = true;
            this.PresetSelectBox.Location = new System.Drawing.Point(218, 50);
            this.PresetSelectBox.Name = "PresetSelectBox";
            this.PresetSelectBox.Size = new System.Drawing.Size(120, 21);
            this.PresetSelectBox.TabIndex = 3;
            this.PresetSelectBox.SelectedIndexChanged += new System.EventHandler(this.PresetSelectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(218, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Preset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromCurrentBtn
            // 
            this.FromCurrentBtn.Location = new System.Drawing.Point(218, 147);
            this.FromCurrentBtn.Name = "FromCurrentBtn";
            this.FromCurrentBtn.Size = new System.Drawing.Size(120, 35);
            this.FromCurrentBtn.TabIndex = 5;
            this.FromCurrentBtn.Text = "Create new from Current";
            this.FromCurrentBtn.UseVisualStyleBackColor = true;
            this.FromCurrentBtn.Click += new System.EventHandler(this.FromCurrentBtn_Click);
            // 
            // FromPasteBtn
            // 
            this.FromPasteBtn.Location = new System.Drawing.Point(218, 188);
            this.FromPasteBtn.Name = "FromPasteBtn";
            this.FromPasteBtn.Size = new System.Drawing.Size(120, 35);
            this.FromPasteBtn.TabIndex = 6;
            this.FromPasteBtn.Text = "Create new from Clipboard";
            this.FromPasteBtn.UseVisualStyleBackColor = true;
            this.FromPasteBtn.Click += new System.EventHandler(this.FromPasteBtn_Click);
            // 
            // DeletePresetBtn
            // 
            this.DeletePresetBtn.Location = new System.Drawing.Point(218, 273);
            this.DeletePresetBtn.Name = "DeletePresetBtn";
            this.DeletePresetBtn.Size = new System.Drawing.Size(120, 35);
            this.DeletePresetBtn.TabIndex = 7;
            this.DeletePresetBtn.Text = "Delete selected preset";
            this.DeletePresetBtn.UseVisualStyleBackColor = true;
            this.DeletePresetBtn.Click += new System.EventHandler(this.DeletePresetBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(218, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 35);
            this.label2.TabIndex = 8;
            this.label2.Text = "Set preset name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PresetName
            // 
            this.PresetName.Location = new System.Drawing.Point(218, 121);
            this.PresetName.Name = "PresetName";
            this.PresetName.Size = new System.Drawing.Size(120, 20);
            this.PresetName.TabIndex = 9;
            this.PresetName.Text = "Default";
            this.PresetName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadPresetBtn
            // 
            this.LoadPresetBtn.Location = new System.Drawing.Point(218, 229);
            this.LoadPresetBtn.Name = "LoadPresetBtn";
            this.LoadPresetBtn.Size = new System.Drawing.Size(120, 35);
            this.LoadPresetBtn.TabIndex = 10;
            this.LoadPresetBtn.Text = "Load Preset";
            this.LoadPresetBtn.UseVisualStyleBackColor = true;
            this.LoadPresetBtn.Click += new System.EventHandler(this.LoadPresetBtn_Click);
            // 
            // PresetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 324);
            this.Controls.Add(this.LoadPresetBtn);
            this.Controls.Add(this.PresetName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeletePresetBtn);
            this.Controls.Add(this.FromPasteBtn);
            this.Controls.Add(this.FromCurrentBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PresetSelectBox);
            this.Controls.Add(this.PresetGrpBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PresetDialog";
            this.Text = "Preset Manager";
            this.PresetGrpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PresetContent;
        private System.Windows.Forms.GroupBox PresetGrpBox;
        private System.Windows.Forms.ComboBox PresetSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FromCurrentBtn;
        private System.Windows.Forms.Button FromPasteBtn;
        private System.Windows.Forms.Button DeletePresetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PresetName;
        private System.Windows.Forms.Button LoadPresetBtn;
    }
}