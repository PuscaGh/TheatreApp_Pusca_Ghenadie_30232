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

namespace TheatreApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void signInBtn_click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;
            OperationResult.opResult result = UserBL.login(username, password);
            switch (result)
            {
                case OperationResult.opResult.OperationLoginUser:
                    {
                        UserForm user = new UserForm();
                        this.Hide();
                        user.Show();
                    }
                    break;
                case OperationResult.opResult.OperationLoginAdmin:
                    {
                        List<User> users = UserBL.getAllUsers();
                        AdminForm admin = new AdminForm(users);
                        this.Hide();
                        admin.Show();
                    }
                    break;
                case OperationResult.opResult.OperationLoginFail:
                default:
                    {
                        MessageBox.Show("Wrong username or/and password");
                    }
                    break;
            }
        }
    }
}
