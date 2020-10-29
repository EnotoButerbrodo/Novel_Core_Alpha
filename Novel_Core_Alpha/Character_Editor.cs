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

        public Character_Editor()
        {
            InitializeComponent();
            Chr_box.Enabled = false;
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

                    using (FileStream fs = File.Create(sfd.FileName))
                    {
                    }
                    curr_char.data_path = sfd.FileName;
                    Chr_box.Enabled = true;
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
                        CharaterName_textbox.Text = curr_char.name;
                    }
                }
            }
        }

        private void SaveFile_button_Click(object sender, EventArgs e)
        {

        }
    }

       
}
