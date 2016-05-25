using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppBL;
using System.ComponentModel;

namespace TheatreApp.Export
{
    public enum ExporterType : int { [Description("Csv")]CsvExporter, [Description("Json")] JsonExporter }
    
    public interface Exporter
    {
        void exportTickets(List<Ticket> tickets, String path);
    }
}
