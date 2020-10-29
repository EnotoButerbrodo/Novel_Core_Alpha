using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novel_Core_Alpha
{
    public partial class Character_Editor : Form
    {

        String char_name;
        
        public Character_Editor()
        {
            InitializeComponent();
        }

        public string CharacterName
        {
            get
            {
                return Charater_name_textbox.Text;
            }
            set 
            { 
                CharacterName = value; 
            }
        }

        private void AddCharacter_button_Click(object sender, EventArgs e)
        { 

        }

        private void Charater_name_textbox_TextChanged(object sender, EventArgs e)
        {
            CharacterName = Charater_name_textbox.Text;
        }
    }
}
