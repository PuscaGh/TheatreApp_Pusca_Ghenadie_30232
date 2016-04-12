using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public enum userRole: int {Administrator = 0, User} 
        public string Name{get;set;}
        public string Username{get;set;}
        public string Password{get;set;}
        public userRole UserRole{get;set;}

        public User(){ }

        public User(string name, string username, string password,userRole role)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.UserRole = role;
        }
    }
}
