using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Class to hold all database fields name
    public static class Constants
    {
        public static String connectionString { get { return @"Data Source=COMP-LAPTOP\SQLEXPRESS;Initial Catalog=Theatre;Integrated Security=SSPI;"; } }
        public static string nameField { get { return "Name"; } }
        public static string usernameField { get { return "Username"; } }
        public static string passwordField { get { return "Password"; } }
        public static string userRoleField { get { return "UserRole"; } }

        public static string codeField { get { return "Code"; } }
        public static string spectacolField { get { return "Spectacol"; } }
        public static string randField { get { return "Rand"; } }
        public static string numarField { get { return "Numar"; } }

        public static string titluField { get { return "Titlu"; } }
        public static string regiaField { get { return "Regia"; } }
        public static string distributiaField { get { return "Distributia"; } }
        public static string premieraField { get { return "Premiera"; } }
        public static string nrOfTicketsField { get { return "TicketsNR"; } }
    }
}
