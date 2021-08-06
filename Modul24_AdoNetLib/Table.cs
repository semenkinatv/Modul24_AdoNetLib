using System;
using System.Collections.Generic;
using System.Text;

namespace Modul24_AdoNetLib
{
    public class Table
    {
        public Table()
        {
            Fields = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Fields { get; set; }

        public string ImportantField { get; set; }

    }
}
