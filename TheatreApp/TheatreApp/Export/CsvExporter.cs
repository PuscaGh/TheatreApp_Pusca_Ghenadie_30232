using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppBL;
using TheatreApp.Utils;
using System.IO;

namespace TheatreApp.Export
{
    public class CsvExporter: Exporter
    {
        public void exportTickets(List<Ticket> tickets, String path)
        {
            var exporter = new CsvExport();

            foreach (Ticket ticket in tickets)
            {
                exporter.AddRow();
                exporter["Code"] = ticket.Code;
                exporter["Spectacol"] = ticket.Spectacol;
                exporter["Rand"] = ticket.Rand;
                exporter["Numar"] = ticket.Numar;
            }

            File.WriteAllBytes(path, exporter.ExportToBytes());
        }
    }
}
