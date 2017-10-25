namespace StellarisModGrabber
{
    partial class MissingModDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissingModDialog));
            this.MissingMain_lbl = new System.Windows.Forms.Label();
            this.Notice_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MissingMain_lbl
            // 
            this.MissingMain_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MissingMain_lbl.Location = new System.Drawing.Point(12, 9);
            this.MissingMain_lbl.Name = "MissingMain_lbl";
            this.MissingMain_lbl.Size = new System.Drawing.Size(330, 38);
            this.MissingMain_lbl.TabIndex = 1;
            this.MissingMain_lbl.Text = "You are missing mods!";
            this.MissingMain_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notice_lbl
            // 
            this.Notice_lbl.Location = new System.Drawing.Point(15, 47);
            this.Notice_lbl.Name = "Notice_lbl";
            this.Notice_lbl.Size = new System.Drawing.Size(327, 29);
            this.Notice_lbl.TabIndex = 2;
            this.Notice_lbl.Text = "List has not been written to settings.txt!\r\nDownload missing mods below and try a" +
    "gain.";
            this.Notice_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MissingModDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(354, 103);
            this.Controls.Add(this.Notice_lbl);
            this.Controls.Add(this.MissingMain_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 657);
            this.Name = "MissingModDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WARNING!";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label MissingMain_lbl;
        private System.Windows.Forms.Label Notice_lbl;
    }
}