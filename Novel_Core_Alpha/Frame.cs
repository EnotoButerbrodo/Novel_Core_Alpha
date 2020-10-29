using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novel_Core_Alpha
{
    [Serializable]
    class Frame
    {
        public string background { get; set; }
        public string text { get; set; } = "Пусто";
        private List<Character> characters { get; }


    }
}
