using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStorageManagement
{
    internal class IdGenerator:abstract1
    {
        private static Random rdm = new Random();

        public override string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rdm.Next(s.Length)]).ToArray());
        }
    }
}
