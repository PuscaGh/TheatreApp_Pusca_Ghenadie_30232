using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace TheatreAppDAL
{
    // User CRUD
    public class UserDAL
    {
        public static User getUser(string username)
        {
            string getUser = "SELECT * FROM Users WHERE Username = @username";
            User user = null;

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand getUserCommand = new SqlCommand(getUser, con);
                    getUserCommand.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = getUserCommand.ExecuteReader();
                    try
                    {
                        reader.Read();

                        int roleIdx = reader.GetOrdinal(Constants.userRoleField);
                        string nameStr = reader[Constants.nameField].ToString();
                        string usernameStr = reader[Constants.usernameField].ToString();
                        string passwordStr = reader[Constants.passwordField].ToString();
                        User.userRole role = (User.userRole)reader.GetInt32(roleIdx);
                        user = new User(nameStr, usernameStr, passwordStr, role);
                    }
                    catch (InvalidOperationException e)
                    {
                        return null;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    // Just return null and handle the this result in class that invokes this method
                    return null;
                }
            }
            return user;
        }

        public static List<User> getAllUsers()
        {
            string getAllUsers = "SELECT * FROM Users";
            List<User> users = null;

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand getUsersCommand = new SqlCommand(getAllUsers, con);
                    SqlDataReader reader = getUsersCommand.ExecuteReader();
                    users = new List<User>();

                    try
                    {
                        while (reader.Read())
                        {
                            int roleIdx = reader.GetOrdinal(Constants.userRoleField);
                            string nameStr = reader[Constants.nameField].ToString();
                            string usernameStr = reader[Constants.usernameField].ToString();
                            string passwordStr = reader[Constants.passwordField].ToString();
                            User.userRole role = (User.userRole)reader.GetInt32(roleIdx);
                            User user = new User(nameStr, usernameStr, passwordStr, role);
                            users.Add(user);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        return null;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    // Just return null and handle the this result in class that invokes this method
                    return null;
                }
            }

            return users;
        }

        public static OperationResult.opResult addUser(string name, string username, string password, User.userRole role)
        {
            string addUser = "INSERT INTO Users VALUES(@name,@username,@password,@userRole)";
            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand addUserCommand = new SqlCommand(addUser, con);
                    addUserCommand.Parameters.AddWithValue("@name", name);
                    addUserCommand.Parameters.AddWithValue("@username", username);
                    addUserCommand.Parameters.AddWithValue("@password", password);
                    addUserCommand.Parameters.AddWithValue("@userRole", (int)role);

                    addUserCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationAddUserFail;
                }
            }
            return OperationResult.opResult.OperationAddUserSucces;
        }
    }
}
