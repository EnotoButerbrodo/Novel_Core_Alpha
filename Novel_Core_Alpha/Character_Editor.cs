using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Novel_Core_Alpha
{
    public partial class Character_Editor : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();//Эта штука для сериализации

        Character curr_char = new Character();
        string curr_char_path;

        public Character_Editor()
        {
            InitializeComponent();
            Chr_box.Enabled = false;
            SaveFile_button.Enabled = false;
        }



        private void AddCharacter_button_Click(object sender, EventArgs e)
        {
            
        }

        private void CreateNewFile_menu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Персонаж|*.chr";
                sfd.DefaultExt = ".chr";
                sfd.InitialDirectory = $"{Registry.CurrentUser.GetValue(@"Software\NCE\AddContent\ContentFolderPath")}\\Characters";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    curr_char_path = sfd.FileName;
                    Chr_box.Enabled = true;
                    SaveFile_button.Enabled = true;
                }
            }
        }

        private void OpenFile_menu_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                opd.Filter = "Персонаж|*chr";
                opd.Multiselect = false;
                opd.Title = "Выбирай персонажа";

                if (opd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(opd.FileName, FileMode.Open))
                    {
                        curr_char = (Character)formatter.Deserialize(fs);
                        
                    }
                    CharaterName_textbox.Text = curr_char.name;
                    curr_char_path = opd.FileName;
                }
                Chr_box.Enabled = true;
                SaveFile_button.Enabled = true;
            }
            
        }

        private void SaveFile_button_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(curr_char_path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, curr_char);
            }    
        }

        private void CharaterName_textbox_TextChanged(object sender, EventArgs e)
        {
            curr_char.name = CharaterName_textbox.Text;
        }
    }

       
}
