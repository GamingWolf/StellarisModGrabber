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
            CheckSteamDirectory();
        }

        public static string FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\settings.txt";
        public string FileBackUp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\settings_BackUp.txt";
        public static string InstalledModsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Stellaris\\";
        public static string SteamModPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Steam\\steamapps\\workshop\\content\\281990";
        public string PrintMissing;
        public static bool MissingMod = false, ClearOverWrite = false;


        public static List<string> Mods = new List<string>();
        public static List<string> PastedModsTrim = new List<string>();
        public static List<string> MissingMods = new List<string>();
        public static List<string> PastedMods = new List<string>();
        public static List<string> RealNameList = new List<string>();
        public static List<string> RealNameListHolder = new List<string>();
        IEnumerable<string> query;


        private void CheckSteamDirectory()
        {
            if (!File.Exists(PresetDialog.PresetPath + "Location\\location.txt"))
            {
                if (!Directory.Exists(SteamModPath))
                {
                    SteamModPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Steam\\steamapps\\workshop\\content\\281990";
                    if (!Directory.Exists(SteamModPath))
                    {
                        Directory.CreateDirectory(InstalledModsPath + "Presets\\Location\\");
                        FolderBrowserDialog steam = new FolderBrowserDialog();
                        steam.Description = "Steam not found. \n Please select your steam install directory (steam.exe is in this folder).";
                        steam.ShowNewFolderButton = false;
                        steam.ShowDialog(this);
                        SteamModPath = steam.SelectedPath + "\\steamapps\\workshop\\content\\281990";

                        var location = new StringBuilder();
                        location.Append(SteamModPath);

                        using (var file = new StreamWriter(File.Create(InstalledModsPath + "Presets\\Location\\location.txt")))
                        {
                            file.Write(location);
                        }
                        Refresh();
                    }
                }
            }
            else
            {
                SteamModPath = File.ReadLines(PresetDialog.PresetPath + "Location\\location.txt").First();
                                   
            }
        }
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

        public static void CheckInstalled(List<string> Checker)
        {
            MissingMod = false;
            MissingMods.Clear();
            MissingMods.TrimExcess();
            Directory.GetDirectories(SteamModPath);
            foreach(string mod in Checker)
            {
                if (!Directory.Exists(SteamModPath + mod))
                {
                    MissingMods.Add(mod);
                    MissingMod = true;
                }
            }
        }

        private void TrimPasted()
        {
            PastedModsTrim.Clear();
            PastedModsTrim.TrimExcess();
            string temp;
            for(int i = 0; i < PastedMods.Count; i++)
            {
                temp = PastedMods[i].Replace("\"mod/ugc_", "\\");
                temp = temp.Replace(".mod\"", "");
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

        private void GetRealNames()
        {
            string temp, query2;
            int count = 0;
            Mods.Clear();
            Mods.TrimExcess();
            GetModList();
            foreach (string mod in Mods)
            {
                temp = mod.Replace("/", "\\");
                RealNameListHolder.Add(temp.Replace("\"", ""));
                query2 = File.ReadLines(InstalledModsPath + RealNameListHolder[count])
                .First();
                count++;
                RealNameList.Add(query2.Replace("name=", ""));
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GrabBtn_Click(object sender, EventArgs e)
        {
            RealNameList.Clear();
            RealNameList.TrimExcess();
            GetRealNames();
            Mods.Clear();
            Mods.TrimExcess();
            GetModList();
            GrabbedListBox.Items.Clear();
            int count = 0;
            foreach (string mod in RealNameList)
            {
                GrabbedListBox.Items.Add(RealNameList[count]);
                count++;
            }
            Clipboard.SetText(GrabbedListBox.ToString());
        }

        private void BackUpBtn_Click(object sender, EventArgs e)
        {
            File.Delete(FileBackUp);
            File.Copy(@FileLocation, @FileBackUp);
            MessageBox.Show("Backup created!");
        }

        private void CopyGrabBtn_Click(object sender, EventArgs e)
        {
            if (GrabbedListBox.Items.Count != 0)
            {
                Clipboard.Clear();
                Clipboard.SetText(string.Join("\n", Mods));
            }
            else
            {
                MessageBox.Show("You are trying to copy an empty list. \n Please press \"Grab mods\" before trying to copy.");
            }
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
            PastedMods.TrimExcess();
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
            MissingMods.TrimExcess();
            CheckInstalled(PastedModsTrim);
            ExecuteCopy();
        }

        private void PresetsBtn_Click(object sender, EventArgs e)
        {
            PresetDialog PresetForm = new PresetDialog();
            PresetForm.ShowDialog();
        }

        private void ClearModBtn_Click(object sender, EventArgs e)
        {
            bool MissingRestore = MissingMod;
            MissingMod = false;
            ClearOverWrite = true;
            PastedMods.Clear();
            PastedMods.TrimExcess();
            ExecuteCopy();
            MissingMod = MissingRestore;
            foreach (string mod in InputListBox.Items)
            {
                PastedMods.Add(mod);
            }
        }
    }
}
