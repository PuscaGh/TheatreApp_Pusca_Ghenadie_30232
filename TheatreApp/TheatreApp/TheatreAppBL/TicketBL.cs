using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppDAL;

namespace TheatreAppBL
{
    public static class TicketBL
    {
        public static OperationResult.opResult addTicketForSpectacle(string code, string spectacol, int rand, int numar)
        {
            OperationResult.opResult result = TicketDAL.addTicketForSpectacle(code, spectacol, rand, numar);
            return result;
        }

        public static List<Ticket> getAllTicketsForSpectacle(string spectacol)
        {
            List<Ticket> tickets = TicketDAL.getAllTicketsForSpectacle(spectacol);
            return tickets;
        }
    }
}
