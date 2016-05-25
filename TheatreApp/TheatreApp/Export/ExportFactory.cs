using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreApp.Export
{
    public abstract class ExportFactory
    {
        public static Exporter getExporter(ExporterType type)
        {
            switch (type)
            {
                case ExporterType.CsvExporter:
                    {
                        return new CsvExporter();
                    }
                case ExporterType.JsonExporter:
                    {
                        return new JsonExporter();
                    }
                default: return null;
            }

        }
    }
}
