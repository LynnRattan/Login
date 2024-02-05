
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Login.Models;
using Login.Services;

namespace Login.ViewModels
{
    public class LoginPageViewModel:ViewModel
    {
        private string name;
        private string password;
        private string theLogin;
        private Color theLoginColor;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); ((Command)CancelCommand).ChangeCanExecute(); } }

        public string Password { get { return password; } set { password = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); ((Command)CancelCommand).ChangeCanExecute(); } }

        public string TheLogin { get { return theLogin; } set { theLogin = value; OnPropertyChanged(); } }
        public string TheLoginColor { get { return theLogin; } set { theLogin = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        private User user;
        public ICommand CancelCommand { get; set; }

        
        public LoginPageViewModel()
        {
            user = new User();
            LoginCommand = new Command(Login,() => !String.IsNullOrEmpty(Name)&& !String.IsNullOrEmpty(Password));
            CancelCommand = new Command(Cancel, () => !String.IsNullOrEmpty(Name) || !String.IsNullOrEmpty(Password));
        } 

      
        private void Login()
        {
            LoginServices service = new LoginServices();
            user.Name = name;
            user.Password = password;
            if(service.LoginCheck(user)==true)
            {
                theLogin = "התחבר בהצלחה";
                theLoginColor = Colors.Green;
            }
            else
            {
                theLogin = "התחברות נכשלה";
                theLoginColor = Colors.Red;
            }

        }

        private void Cancel()
        {
            theLogin = string.Empty;
            Name = string.Empty;
            Password = string.Empty;
            user = new User();
        }

      
    }
}
