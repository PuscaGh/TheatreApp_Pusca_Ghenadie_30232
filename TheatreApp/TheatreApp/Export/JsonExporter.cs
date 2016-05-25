using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppBL;
using Newtonsoft.Json;

namespace TheatreApp.Export
{
    public class JsonExporter: Exporter
    {
        public void exportTickets(List<Ticket> tickets, String path)
        {
            
            string json = JsonConvert.SerializeObject(tickets.ToArray());
            //write string to file
            System.IO.File.WriteAllText(path, json);
        }
    }
}
