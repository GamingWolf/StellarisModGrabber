using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StellarisModGrabber
{
    public partial class MissingModDialog : Form
    {
        public MissingModDialog()
        {
            InitializeComponent();
            LabelNames();
            Refresh();
        }

        public static List<string> newMissingMods = new List<string>();
        public List<string> LabelNameList = new List<string>();
        public static  List<string> URLTitleList = new List<string>();
        public static int linkNum = 0;
        public LinkLabel[] LinkCollection;
        public LinkLabel LinkLabelA = new LinkLabel();
        public Point LinkSpawn;
        WebClient title = new WebClient();
        public bool DidIt = false;
        delegate void SetProgressCallback(int value);

        public static void PassList(List<string> Passer)
        {
            newMissingMods.Clear();
            newMissingMods.TrimExcess();
            foreach(string mod in Passer)
            {
                newMissingMods.Add(mod.Replace("\\","/"));
            }
        }

        private void LabelNames()
        {
            BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgWorker_RunWorkerCompleted);
            PassList(Form1.MissingMods);
            NameGenerationProgress.Maximum = newMissingMods.Count() - 1;
            Notice_lbl.Text = "Generating missing mod list, please wait";
            LabelNameList.Clear();
            LabelNameList.TrimExcess();      
            URLTitleList.Clear();
            URLTitleList.TrimExcess();
            BgWorker.RunWorkerAsync();
            LinkCollection = new LinkLabel[newMissingMods.Count];
            LinkSpawn = new Point(Notice_lbl.Location.X + 10, Notice_lbl.Location.Y + 30);
            
        }

        private void CreateLabels()
        {
            for (int i = 0; i < newMissingMods.Count; i++)
            {
                LinkLabelA = new LinkLabel();
                LinkLabelA.Text = URLTitleList[i].ToString();
                LinkLabelA.Name = LabelNameList[i];
                LinkLabelA.Location = LinkSpawn;
                LinkLabelA.TextAlign = ContentAlignment.MiddleCenter;
                LinkLabelA.AutoSize = true;
                Controls.Add(LinkLabelA);
                LinkCollection[i] = LinkLabelA;
                LinkSpawn = new Point(LinkSpawn.X, LinkSpawn.Y + 20);

                if(!DidIt)
                {
                    LinkLabelA.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
                }
            }
        }

        private void SetText(int value)
        {
            if (NameGenerationProgress.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetText);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                NameGenerationProgress.Value = value;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((LinkLabel)sender).LinkVisited = true;

            System.Diagnostics.Process.Start(((LinkLabel)sender).Name);
        }
        
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string temp, tempURL, source;
            int i = 0;
            foreach (string mod in newMissingMods)
            {
                temp = newMissingMods[i].Replace("/", "");
                LabelNameList.Add("http://steamcommunity.com/sharedfiles/filedetails/?id=" + temp.Replace(".mod", ""));
                source = title.DownloadString(LabelNameList[i].ToString());
                tempURL = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                URLTitleList.Add(tempURL.Replace("Steam Workshop :: ", ""));
                SetText(i);
                i++;
            }
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                Notice_lbl.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                Notice_lbl.Text = "Error: " + e.Error.Message;
            }
            else
            {
                NameGenerationProgress.Visible = false;
                NameGenerationProgress.Enabled = false;
                Notice_lbl.Text = "File has not been written! \n Download missing mods from the workshop below and try again.";
                title.Dispose();
                CreateLabels();
            }
        }

        void MissForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
