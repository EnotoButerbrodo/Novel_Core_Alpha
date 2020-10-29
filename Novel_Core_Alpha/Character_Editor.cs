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

namespace Novel_Core_Alpha
{
    public partial class Character_Editor : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();//Эта штука для сериализации

        public Character_Editor()
        {
            InitializeComponent();
        }

        

        private void AddCharacter_button_Click(object sender, EventArgs e)
        {
            Character NewChar = new Character(Charater_name_textbox.Text);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Персонаж|*.chr";
                sfd.DefaultExt = ".chr";
                sfd.FileName = NewChar.name;
                sfd.InitialDirectory = $"NCE_content\\Scene";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        formatter.Serialize(fs, NewChar);
                    }
                }
            }

        }

        private void Charater_name_textbox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
