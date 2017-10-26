using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StellarisModGrabber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\settings.txt";
        public string FileBackUp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\settings_BackUp.txt";
        public string InstalledModsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\";
        public string PrintMissing;
        public bool MissingMod = false, ClearOverWrite = false;

        List<string> Mods = new List<string>();
        List<string> PastedModsTrim = new List<string>();
        public static List<string> MissingMods = new List<string>();
        List<string> PastedMods = new List<string>();
        IEnumerable<string> query;

        private void GetModList()
        {
            if (File.Exists(FileLocation))
            {
                query = File.ReadLines(FileLocation)
                                .SkipWhile(line => !line.Contains("last_mods={"))
                                .Skip(1)
                                .TakeWhile(line => !line.Contains("}"));

                foreach (string mod in query)
                {
                    Mods.Add(mod.Trim());
                }

            }
            else
            {
                MessageBox.Show("Your file appears to be in another castle.");
            }
        }

        private void CheckInstalled()
        {
            foreach(string mod in PastedModsTrim)
            {
                if (!File.Exists(InstalledModsPath + mod))
                {
                    MissingMods.Add(mod);
                    MissingMod = true;
                }
            }
        }

        private void TrimPasted()
        {
            PastedModsTrim.Clear();
            string temp;
            for(int i = 0; i < PastedMods.Count; i++)
            {
                temp = PastedMods[i].Replace("/", "\\");
                PastedModsTrim.Add(temp.Replace("\"", ""));
            }
        }

        private void ExecuteCopy()
        {
            if (!MissingMod && (PastedMods.Count != 0 || ClearOverWrite))
            {
                var newMods = new StringBuilder();
                newMods.Append("last_mods={");
                newMods.Append("\n");
                foreach (var mod in PastedMods)
                {

                    newMods.Append(mod);
                    newMods.Append("\n");
                }


                string fileContents = File.ReadAllText(FileLocation);


                var startIndex = fileContents.IndexOf("last_mods");
                var stopIndex = fileContents.IndexOf("}", startIndex);

                var substring = fileContents.Substring(startIndex, stopIndex - startIndex);
                var newContents = fileContents.Replace(substring, newMods.ToString());


                using (var file = new StreamWriter(File.Create(FileLocation)))
                {
                    file.Write(newContents);
                }
                
                if (ClearOverWrite)
                {
                    ClearOverWrite = false;
                    MessageBox.Show("Mods Cleared.");
                }
                else
                {
                    MessageBox.Show("Mods have been written, hopefully.");
                }
            }
            else if (MissingMod)
            {
                MissingModDialog MissForm = new MissingModDialog();
                MissForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You cannot commit an empty list. \n Use the clear button to clear all mods.");
            }
        }


        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GrabBtn_Click(object sender, EventArgs e)
        {
            Mods.Clear();
            GetModList();
            GrabbedListBox.Items.Clear();
            int count = 0;
            foreach (string mod in Mods)
            {
                GrabbedListBox.Items.Add(Mods[count]);
                count++;
            }
        }

        private void BackUpBtn_Click(object sender, EventArgs e)
        {
            File.Delete(FileBackUp);
            File.Copy(@FileLocation, @FileBackUp);
            MessageBox.Show("Backup created!");
        }

        private void CopyGrabBtn_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(string.Join("\n", Mods));
        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(FileBackUp))
            {
                File.Delete(FileLocation);
                File.Copy(@FileBackUp, @FileLocation);
                MessageBox.Show("File restored!");
            }
            else
            {
                MessageBox.Show("There is no Backup.");
            }
        }

        private void PasteBtn_Click(object sender, EventArgs e)
        {
            InputListBox.Items.Clear();
            PastedMods.Clear();
            MissingMod = false;
            string s = Clipboard.GetText();
            string[] pasted = s.Split('\n');
            foreach (string pastedmods in pasted)
            {
                PastedMods.Add(pastedmods.Trim());
                InputListBox.Items.Add(pastedmods.Trim());
            }
            TrimPasted();
        }

        private void CommitPasteBtn_Click(object sender, EventArgs e)
        {
            MissingMods.Clear();
            CheckInstalled();
            ExecuteCopy();
        }

        private void PresetsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearModBtn_Click(object sender, EventArgs e)
        {
            bool MissingRestore = MissingMod;
            MissingMod = false;
            ClearOverWrite = true;
            PastedMods.Clear();
            ExecuteCopy();
            MissingMod = MissingRestore;
            foreach (string mod in InputListBox.Items)
            {
                PastedMods.Add(mod);
            }
        }
    }
}
