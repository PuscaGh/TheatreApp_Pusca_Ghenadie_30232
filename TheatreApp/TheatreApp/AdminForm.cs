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
    public partial class AdminForm : Form
    {
        // Proprieties declaration
        private TableContainer userTable;
        private TableContainer spectalesTable;
        private DataEdit addNewEmployee;
        private DataEdit addNewSpectacle;
        private DataEdit updateSpectacle;
        private DataEdit deleteSpectacle;

        // The data views will be displayed in the same form
        // Only current view will displayed, when changing current view
        // previous one will be dismissed.
        private UIView currentView;

        public AdminForm(List<User> users)
        {
            InitializeComponent();
            this.CenterToScreen();
            userTable = new TableContainer();
            spectalesTable = new TableContainer();
            spectalesTable.StartEditRow += handlerTableEditRow;
            addNewEmployee = new DataEdit();
            addNewEmployee.FinishEdit += handleFinishEdit;
            addNewSpectacle = new DataEdit();
            addNewSpectacle.FinishEdit += handleFinishEdit;
            deleteSpectacle = new DataEdit();
            deleteSpectacle.FinishEdit += handleFinishEdit;
            updateSpectacle = new DataEdit();
            updateSpectacle.FinishEdit += handleFinishEdit;
        }

        // Handle Spectacles update operation
        private void handlerTableEditRow(object sender, System.Collections.Specialized.OrderedDictionary e)
        {
            if (sender.Equals(spectalesTable))
            {
                if(currentView != null) currentView.dismissFromContainer();
                Tuple<String, String> premiera = new Tuple<String, String>(Constants.premieraField, e[Constants.premieraField].ToString());
                Tuple<String, String> titlu = new Tuple<String, String>(Constants.titluField, e[Constants.titluField].ToString());
                Tuple<String, String> regia = new Tuple<String, String>(Constants.regiaField, e[Constants.regiaField].ToString());
                Tuple<String, String> distributia = new Tuple<String, String>(Constants.distributiaField, e[Constants.distributiaField].ToString());
                Tuple<String, String> nrOfTickets = new Tuple<String, String>(Constants.nrOfTicketsField, e[Constants.nrOfTicketsField].ToString());
                Array arr = new Tuple<String, String>[] { premiera, titlu, regia, distributia, nrOfTickets };
                updateSpectacle.drawInForm(this);
                updateSpectacle.refreshWithData(arr);
                currentView = updateSpectacle;
            }
        }

        // Employees operations
        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentView != null) currentView.dismissFromContainer();
            Tuple<String,String> username = new Tuple<String,String>(Constants.usernameField,""); 
            Tuple<String,String> name = new Tuple<String,String>(Constants.nameField,""); 
            Tuple<String,String> password = new Tuple<String,String>(Constants.passwordField,""); 
            Tuple<String,String> userRole = new Tuple<String,String>(Constants.userRoleField,""); 
            Array arr = new Tuple<String,String>[]{username,name,password,userRole};
            addNewEmployee.drawInForm(this);
            addNewEmployee.refreshWithData(arr);
            currentView = addNewEmployee;
        }

        private void viewEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array users = UserBL.getAllUsers().ToArray();
            if (users == null)
            {
                MessageBox.Show("Cannot get data");
                return;
            }
            if (currentView != null) currentView.dismissFromContainer();
            userTable.drawInForm(this);
            userTable.refreshWithData(users);
            currentView = userTable;
        }

        // Spectacles Operations
        private void viewSpectaclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array spectacles = SpectacleBL.getAllSpectacles().ToArray();
            if (spectacles == null)
            {
                MessageBox.Show("Cannot get data");
                return;
            }
            if (currentView != null) currentView.dismissFromContainer();
            spectalesTable.drawInForm(this);
            spectalesTable.refreshWithData(spectacles);
            currentView = spectalesTable;
        }

        private void addNewSpectacleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentView != null) currentView.dismissFromContainer();
            Tuple<String, String> premiera = new Tuple<String, String>(Constants.premieraField, "");
            Tuple<String, String> titlu = new Tuple<String, String>(Constants.titluField, "");
            Tuple<String, String> regia = new Tuple<String, String>(Constants.regiaField, "");
            Tuple<String, String> distributia = new Tuple<String, String>(Constants.distributiaField, "");
            Tuple<String, String> nrOfTickets = new Tuple<String, String>(Constants.nrOfTicketsField, "");
            Array arr = new Tuple<String, String>[] { premiera, titlu, regia, distributia, nrOfTickets };
            addNewSpectacle.drawInForm(this);
            addNewSpectacle.refreshWithData(arr);
            currentView = addNewSpectacle;
        }

        private void deleteSpectacleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentView != null) currentView.dismissFromContainer();
            Tuple<String, String> premiera = new Tuple<String, String>(Constants.titluField, "");
            Array arr = new Tuple<String, String>[] { premiera};

            deleteSpectacle.drawInForm(this);
            deleteSpectacle.refreshWithData(arr);
            currentView = deleteSpectacle;
        }

        // This method is callback method like, where the data received after editing is processed.
        private void handleFinishEdit(object sender, System.Collections.Specialized.OrderedDictionary e)
        {
            if (sender.Equals(this.addNewEmployee))
            {
                string name = e[Constants.nameField].ToString();
                string username = e[Constants.usernameField].ToString();
                string password = e[Constants.passwordField].ToString();
                User.userRole role;
                try
                {
                    role = (User.userRole)int.Parse(e[Constants.userRoleField].ToString());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }

                if (name.Length == 0 || username.Length == 0 || password.Length == 0 || role > User.userRole.User)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }

                OperationResult.opResult result = UserBL.addUser(name, username, password, role);
                if (result == OperationResult.opResult.OperationAddUserSucces)
                {
                    MessageBox.Show("Succes");

                }
                else
                {
                    MessageBox.Show("Cannot add user");
                }
            }
            else if (sender.Equals(this.addNewSpectacle))
            {
               
                string titlu = e[Constants.titluField].ToString();
                string regia = e[Constants.regiaField].ToString();
                string distributia = e[Constants.distributiaField].ToString();
                DateTime premiera;
                int nrOfTickets;
                try
                {
                    premiera = DateTime.Parse(e[Constants.premieraField].ToString());
                    nrOfTickets = int.Parse(e[Constants.nrOfTicketsField].ToString());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }


                if (titlu.Length == 0 || regia.Length == 0 || distributia.Length == 0)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }
                OperationResult.opResult result = SpectacleBL.addSpectacle(premiera, titlu, regia, distributia, nrOfTickets);
                if (result == OperationResult.opResult.OperationAddSpectacleSucces)
                {
                    MessageBox.Show("Succes");

                }
                else
                {
                    MessageBox.Show("Cannot add spectacle");
                }
            }
            else if (sender.Equals(this.deleteSpectacle))
            {
                string titlu = e[Constants.titluField].ToString();
                if (titlu.Length == 0)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }
                OperationResult.opResult result = SpectacleBL.deleteSpectacle(titlu);
                if (result == OperationResult.opResult.OperationDeleteSpectacleSucces)
                {
                    MessageBox.Show("Succes");

                }
                else
                {
                    MessageBox.Show("Cannot delete spectacle");
                }
            }
            else if (sender.Equals(this.updateSpectacle))
            {
                string titlu = e[Constants.titluField].ToString();
                string regia = e[Constants.regiaField].ToString();
                string distributia = e[Constants.distributiaField].ToString();

                DateTime premiera;
                int nrOfTickets;
                try
                {
                    premiera = DateTime.Parse(e[Constants.premieraField].ToString());
                    nrOfTickets = int.Parse(e[Constants.nrOfTicketsField].ToString());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }

                if (titlu.Length == 0 || regia.Length == 0 || distributia.Length == 0)
                {
                    MessageBox.Show("Bad request,please check fields");
                    return;
                }
                OperationResult.opResult result = SpectacleBL.updateSpectacle(premiera, titlu, regia, distributia, nrOfTickets);
                if (result == OperationResult.opResult.OperationUpdateSpectacleSucces)
                {
                    MessageBox.Show("Succes");

                }
                else
                {
                    MessageBox.Show("Cannot update data");
                }
            }
        }

        // Logout
        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }
    }
}
