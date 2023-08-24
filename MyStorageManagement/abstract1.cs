using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStorageManagement
{
    abstract class abstract1
    {
        public abstract string RandomNumber(int length);
        public string IDLetter(string a)
        {
            string x = "";
            if (a == "Headphones") { x = "HP"; }
            else if (a == "Camera") { x = "CR"; }
            else if (a == "Smartwatch") { x = "SW"; }
            else if (a == "Laptop") { x = "LP"; }
            else if (a == "TV") { x = "TV"; }
            return x;
        }
    }
}
