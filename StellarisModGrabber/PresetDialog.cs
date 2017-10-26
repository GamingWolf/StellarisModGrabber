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

        public string PresetPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\Presets\\";
        Dictionary<int, string> PresetSelectList = new Dictionary<int, string>();
        public static List<string> PresetListGrabbed = new List<string>();
        public static List<string> PresetListPasted = new List<string>();
        public static List<string> ExistingPresets = new List<string>();
        public bool IntDone = false;
        IEnumerable<string> query;

        public static void PassList(List<string> Passer)
        {
            if(Passer.Count > 0)
            {
                PresetListPasted.Clear();
                foreach(string mod in Passer)
                {
                    PresetListPasted.Add(mod);
                    
                }
            }
            else
            {
                MessageBox.Show("The list you are trieng to grab is empty.");
            }
        }

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

        private void PresetSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IntDone && File.Exists(PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())]))
            {
                PresetContent.Items.Clear();
                query = File.ReadLines(PresetPath + PresetSelectList[Convert.ToInt32(PresetSelectBox.SelectedValue.ToString())])
                                .SkipWhile(line => !line.Contains("last_mods={"))
                                .Skip(1)
                                .TakeWhile(line => !line.Contains("}"));

                foreach (string mod in query)
                {
                    PresetContent.Items.Add(mod.Trim());
                }

            }
            else if(IntDone)
            {
                MessageBox.Show("The selected file does not exist.");
            }
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
            }
            else
            {
                MessageBox.Show("Preset deleted.");
            }
        }
    }
}
