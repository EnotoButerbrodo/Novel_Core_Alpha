﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel_Core_Alpha
{
    [Serializable]
    class Character
    {

        public string name { get; set; } = "Monica";
        public string data_path { get; set; }
        public string emotions { get; }
        Point position { get; set; } = new Point(0, 0);


    }
}
