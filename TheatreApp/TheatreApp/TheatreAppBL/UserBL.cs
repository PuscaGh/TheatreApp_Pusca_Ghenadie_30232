using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using TheatreAppDAL;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TheatreAppBL
{
    public class UserBL
    {
        public static OperationResult.opResult login(string username, string password)
        {
            OperationResult.opResult result = OperationResult.opResult.OperationLoginFail;
            User user = UserDAL.getUser(username);
            string passwordEncod = getMd5Hash(password);
            if (user != null && user.Password.Equals(passwordEncod))
            {
                result = OperationResult.opResult.OperationLoginUser;
                if (user.UserRole == User.userRole.Administrator)
                {
                    result = OperationResult.opResult.OperationLoginAdmin;
                }
            }
            return result;
        }

        public static OperationResult.opResult addUser(string name, string username, string password, User.userRole role)
        {
            string passwordEncod = getMd5Hash(password);
            OperationResult.opResult result = UserDAL.addUser(name, username, passwordEncod, role);
            return result;
        }

        public static List<User> getAllUsers()
        {
            List<User> users = UserDAL.getAllUsers();
            return users;
        }

        private static string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
