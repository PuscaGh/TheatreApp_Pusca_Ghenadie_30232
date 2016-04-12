using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using TheatreAppBL;
using TheatreApp.Utils;

namespace TheatreApp
{
    public partial class UserForm : Form
    {
        private TableContainer spectalesTable;
        private TableContainer ticketsTable;
        private DataEdit addTicket;
        private UIView currentView;

        public UserForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            spectalesTable = new TableContainer();
            spectalesTable.StartEditRow += handlerTableEditRow;
            ticketsTable = new TableContainer();
            addTicket = new DataEdit();
            addTicket.FinishEdit += handleFinishEdit;
        }

        private void handlerTableEditRow(object sender, System.Collections.Specialized.OrderedDictionary e)
        {
            if (sender.Equals(spectalesTable))
            {
                string titlu =  e[Constants.titluField].ToString();
                Array tickets = TicketBL.getAllTicketsForSpectacle(titlu).ToArray();
                if (tickets == null || tickets.Length == 0)
                {
                    MessageBox.Show("No tickets added for this spectacle");
                    return;
                }
                if (currentView != null) currentView.dismissFromContainer();
                ticketsTable.drawInForm(this);
                ticketsTable.refreshWithData(tickets);
                currentView = ticketsTable;
            }
        }

        private void viewSpectaclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentView != null) currentView.dismissFromContainer();
            Array spectacles = SpectacleBL.getAllSpectacles().ToArray();
            spectalesTable.drawInForm(this);
            spectalesTable.refreshWithData(spectacles);
            currentView = spectalesTable;
        }

        private void addTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentView != null) currentView.dismissFromContainer();
            Tuple<String, String> code = new Tuple<String, String>(Constants.codeField, "");
            Tuple<String, String> spectacol = new Tuple<String, String>(Constants.spectacolField, "");
            Tuple<String, String> rand = new Tuple<String, String>(Constants.randField, "");
            Tuple<String, String> numar = new Tuple<String, String>(Constants.numarField, "");
            Array arr = new Tuple<String, String>[] { code, spectacol, rand, numar };

            addTicket.drawInForm(this);
            addTicket.refreshWithData(arr);
            currentView = addTicket;
        }

        private void handleFinishEdit(object sender, System.Collections.Specialized.OrderedDictionary e)
        {
            if (sender.Equals(this.addTicket))
            {
                string code = e[Constants.codeField].ToString();
                string spectacol = e[Constants.spectacolField].ToString();
                int nrOfTickets = SpectacleBL.getNrOfTicketsForSpectacle(spectacol);
                if (nrOfTickets == 0)
                {
                    MessageBox.Show("Cannot add more tickets");
                    return;
                }
                else if (nrOfTickets == -1)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }
                int rand = int.Parse(e[Constants.randField].ToString());
                int numar = int.Parse(e[Constants.numarField].ToString());
                OperationResult.opResult result = TicketBL.addTicketForSpectacle(code, spectacol, rand, numar);

                if (result == OperationResult.opResult.OperationInsertTicketDuplicate ||
                    result == OperationResult.opResult.OperationAddTicketFail)
                {
                    MessageBox.Show("Cannot add ticket for this place");
                    return;
                }
                else
                {
                    MessageBox.Show("Succes");
                }
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }
    }
}
