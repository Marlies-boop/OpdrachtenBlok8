using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    internal class Woorden
    {
        public int Id { get; set; }
        public string Woord { get; set; }

        public string Test()
        {
            return $"id = {Id}, woord = {Woord}";
        }

        public override string ToString()
        {
            return Woord;
        }
    }
}
