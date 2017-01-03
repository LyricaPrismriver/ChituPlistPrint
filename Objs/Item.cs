using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChituPlistPrint
{
    class Item
    {
        private string key;
        private string str;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Str
        {
            get { return str; }
            set { str = value; }
        }
    }
}
