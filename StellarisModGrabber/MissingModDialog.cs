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
            CreateLabels();
        }

        public static List<string> newMissingMods = new List<string>();
        public List<string> LabelNameList = new List<string>();
        public List<string> URLTitleList = new List<string>();
        public static int linkNum = 0;
        public LinkLabel[] LinkCollection;
        public LinkLabel LinkLabelA = new LinkLabel();
        public Point LinkSpawn;
        WebClient title = new WebClient();
        public bool DidIt = false;


        public static void PassList(List<string> Passer)
        {
            newMissingMods.Clear();
            foreach(string mod in Passer)
            {
                newMissingMods.Add(mod.Replace("\\","/"));
            }
        }

        private void LabelNames()
        {
            LabelNameList.Clear();
            LinkCollection = new LinkLabel[newMissingMods.Count];
            LinkSpawn = new Point(Notice_lbl.Location.X + 10, Notice_lbl.Location.Y + 30);
            string temp, source;
            for (int i = 0; i < newMissingMods.Count; i++)
            {
                temp = newMissingMods[i].Replace("mod/ugc_", "");
                LabelNameList.Add("http://steamcommunity.com/sharedfiles/filedetails/?id=" + temp.Replace(".mod", ""));
                source = title.DownloadString(LabelNameList[i].ToString());
                URLTitleList.Add(Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value);
            }
        }

        private void CreateLabels()
        {
            
            PassList(Form1.MissingMods);
            LabelNames();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((LinkLabel)sender).LinkVisited = true;

            System.Diagnostics.Process.Start(((LinkLabel)sender).Name);
        }
    }
}
