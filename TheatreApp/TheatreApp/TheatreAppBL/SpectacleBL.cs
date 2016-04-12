using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppDAL;

namespace TheatreAppBL
{
   public class SpectacleBL
    {
        public static List<Spectacle> getAllSpectacles()
        {
            List<Spectacle> spectacles = SpectacleDAL.getAllSpectacles();
            return spectacles;
        }

        public static OperationResult.opResult updateSpectacle(DateTime premiera, string titlu, string regia, string distributia,int nrOfTickets)
        {
            OperationResult.opResult result = SpectacleDAL.updateSpectacle(premiera, titlu, regia, distributia, nrOfTickets);
            return result;
        }

        public static OperationResult.opResult addSpectacle(DateTime premiera, string titlu, string regia, string distributia, int maxNrOfTickets)
        {
            OperationResult.opResult result = SpectacleDAL.addSpectacle(premiera, titlu, regia, distributia, maxNrOfTickets);
            return result;
        }

        public static OperationResult.opResult deleteSpectacle(string spectacol)
        {
            OperationResult.opResult result = SpectacleDAL.deleteSpectacle(spectacol);
            return result;
        }

        public static int getNrOfTicketsForSpectacle(string spectacol)
        {
            int tickets = SpectacleDAL.getNrOfTicketsForSpectacle(spectacol);
            return tickets;
        }
    }
}
