using Login.Models;
using CoreML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services
{
    class UsersList
    {
        public List<User> Users { get; private set; }
        public UsersList()
        {
            this.Users = new List<User>();
            Users.Add(new User());
        }
    }
        public class LoginService
    {
        public LoginService()
        {
            this.Users = new UsersList().Users;
        }
        List<User> Users;
        public User FindUserByNameAndPassword(string name,string password)
        {
            return Users.Where(x => x.Name == name && x.Password==password).FirstOrDefault();
        }
    }
}
