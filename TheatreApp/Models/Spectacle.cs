using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Spectacle
    {
        public DateTime Premiera { get; set; }
        public string Titlu { get; set; }
        public string Regia { get; set; }
        public string Distributia { get; set; }
        public int TicketsNR { get; set; }

        public Spectacle(DateTime premiera,string titlu, string regia, string distributia,int nrOfTickets)
        {
            this.Titlu = titlu;
            this.Regia = regia;
            this.Distributia = distributia;
            this.Premiera = premiera;
            this.TicketsNR = nrOfTickets;
        }
    }
}
