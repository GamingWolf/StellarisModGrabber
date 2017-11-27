using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StellarisModGrabber
{
    public partial class PresetDialog : Form
    {
        public PresetDialog()
        {
            InitializeComponent();
            IntPresets();
        }

        public static string PresetPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Presets\\";
        Dictionary<int, string> PresetSelectList = new Dictionary<int, string>();
        public static List<string> PresetListGrabbed = new List<string>();
        public static List<string> PresetListPasted = new List<string>();
        public static List<string> ExistingPresets = new List<string>();
        public static List<string> RealNameList = new List<string>();
        public static List<string> RealNameListHolder = new List<string>();
        public bool IntDone = false;
        IEnumerable<string> query;

        private void IntPresets()
        {
            int key = 0;
            PresetSelectList.Clear();
            if (!Directory.Exists(PresetPath))
            {
                Directory.CreateDirectory(PresetPath);
            }
            DirectoryInfo PInfo = new DirectoryInfo(PresetPath);
            FileInfo[] Files = PInfo.GetFiles("*.txt");
            foreach(FileInfo file in Files)
            {
                ExistingPresets.Add(file.ToString());
                PresetSelectList.Add(key, file.ToString());
                key++;
            }
            if (PresetSelectList.Count != 0)
            {
                PresetSelectBox.DataSource = new BindingSource(PresetSelectList, null);
                PresetSelectBox.DisplayMember = "Value";
                PresetSelectBox.ValueMember = "Key";
            }
            IntDone = true;
        }

        private void GetRealNames()
        {
            RealNameList.Clear();
            RealNameList.TrimExcess();
            string query;
            int count = 0;
            if (!Form1.MissingMod)
            {
                string temp;
                foreach (string mod in PresetListPasted)
                {
                    temp = PresetListPasted[count].Replace("\\", "mod\\ugc_") + ".mod";
                    query = File.ReadLines(Form1.InstalledModsPath + temp)
                                .First();
                    count++;
                    RealNameList.Add(query.Replace("name=", ""));
                    PresetContent.Items.Add(query.Replace("name=", ""));
                }
            }
            else if (Form1.MissingMod)
            {
                MissingModDialog MissForm = new MissingModDialog();
                MissForm.ShowDialog();
            }
        }

        private void PresetSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            string temp;
            try
            {
                if (IntDone && File.Exists(PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())]))
                {
                    PresetGrpBox.Text = PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())];
                    PresetContent.Items.Clear();
                    PresetListPasted.Clear();
                    PresetListPasted.TrimExcess();
                    query = File.ReadLines(PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())])
                                    .SkipWhile(line => !line.Contains("last_mods={"))
                                    .Skip(1)
                                    .TakeWhile(line => !line.Contains("}"));

                    foreach (string mod in query)
                    {
                        temp = mod.Replace("\"mod/ugc_", "\\").Trim();
                        PresetListPasted.Add(temp.Replace(".mod\"", ""));
                    }
                    Form1.CheckInstalled(PresetListPasted);
                    GetRealNames();
                    foreach (string real in RealNameList)
                    {
                        PresetContent.Items.Add(RealNameList[count]);
                        count++;
                    }
                }
                else if (IntDone)
                {
                    MessageBox.Show("The selected file does not exist.");
                }
            }
            catch { }
        }

        private void FromCurrentBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PresetPath + PresetName.Text + ".txt"))
            {
                File.Copy(@Form1.FileLocation, @PresetPath + PresetName.Text + ".txt");
                IntPresets();
            }
            else
            {
                MessageBox.Show("A preset with the given name already exists");
            }
        }

        private void DeletePresetBtn_Click(object sender, EventArgs e)
        {
            File.Delete(PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())]);
            IntPresets();
            if (PresetSelectList.Count == 0)
            {
                MessageBox.Show("Last preset deleted. \n" +
                                "The name will remain until you restart the program.");
                IntPresets();
            }
            else
            {
                MessageBox.Show("Preset deleted.");
                IntPresets();
            }
        }

        private void FromPasteBtn_Click(object sender, EventArgs e)
        {
            Directory.GetDirectories(Form1.SteamModPath);
            PresetContent.Items.Clear();
            PresetListPasted.Clear();
            PresetListPasted.TrimExcess();
            string s = Clipboard.GetText(), temp;
            string[] pasted = s.Split('\n');
            foreach (string pastedmods in pasted)
            {
                temp = pastedmods.Replace("\"mod/ugc_", "\\");
                PresetListPasted.Add(temp.Replace(".mod\"", "").Trim());
            }
            RealNameList.Clear();
            RealNameList.TrimExcess();
            Form1.CheckInstalled(PresetListPasted);
            if (!Form1.MissingMod && !File.Exists(PresetPath + PresetName.Text + ".txt"))
            {
                GetRealNames();
                File.Copy(@Form1.FileLocation, @PresetPath + PresetName.Text + ".txt");

                if (!Form1.MissingMod && PresetListPasted.Count != 0)
                {
                    var newMods = new StringBuilder();
                    newMods.Append("last_mods={");
                    newMods.Append("\n");
                    foreach (var mod in PresetListPasted)
                    {
                        newMods.Append(mod.Replace("\\", "/"));
                        newMods.Append("\n");
                    }


                    string fileContents = File.ReadAllText(PresetPath + PresetName.Text + ".txt");


                    var startIndex = fileContents.IndexOf("last_mods");
                    var stopIndex = fileContents.IndexOf("}", startIndex);

                    var substring = fileContents.Substring(startIndex, stopIndex - startIndex);
                    var newContents = fileContents.Replace(substring, newMods.ToString());


                    using (var file = new StreamWriter(File.Create(PresetPath + PresetName.Text + ".txt")))
                    {
                        file.Write(newContents);
                    }
                    IntPresets();
                }
            }
            else if(File.Exists(PresetPath + PresetName.Text + ".txt"))
            {
                MessageBox.Show("A preset with the given name already exists.");
            }
            else if (Form1.MissingMod)
            {
                MissingModDialog MissForm = new MissingModDialog();
                MissForm.ShowDialog();
            }
        }

        private void LoadPresetBtn_Click(object sender, EventArgs e)
        {
            File.Delete(Form1.FileLocation);
            File.Copy(@PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())], @Form1.FileLocation);
            MessageBox.Show("Preset loaded.");
        }
    }
}
