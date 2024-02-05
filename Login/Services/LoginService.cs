using Login.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services
{
    public class UsersList
    {
        public class LoginServices
        {
            public List<User> Users { get; set; }
            public LoginServices()
            {
                FillUsers();
            }

            public bool LoginCheck(User user)
            {
                return Users.Any(x => x.Name == user.Name && x.Password == user.Password);
            }

            public void AddUser(User user)
            {
                Users.Add(user);
            }

            private void FillUsers()
            {
                Users.Add(new User()
                {
                    Name = "smth1",
                    Password = "12345"
                });

                Users.Add(new User()
                {
                    Name = "smth2",
                    Password = "123456"
                });

                Users.Add(new User()
                {
                    Name = "smth3",
                    Password = "123457"
                });

                Users.Add(new User()
                {
                    Name = "smth4",
                    Password = "123458"
                });
            }
        }
            
       
    }
}
