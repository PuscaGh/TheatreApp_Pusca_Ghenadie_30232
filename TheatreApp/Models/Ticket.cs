using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public string Code { get; set; }
        public string Spectacol { get; set; }
        public int Rand { get; set; }
        public int Numar { get; set; }

        public Ticket(string code, string spectacol, int rand, int numar)
        {
            this.Code = code;
            this.Spectacol = spectacol;
            this.Rand = rand;
            this.Numar = numar;
        }
    }
}
