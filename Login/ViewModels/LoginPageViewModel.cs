using CoreML;
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
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); ((Command)SearchByNameCommand).ChangeCanExecute(); } }

        public string Password { get { return password; } set { password = value; OnPropertyChanged(); ((Command)SearchByPasswordCommand).ChangeCanExecute(); } }

        public ICommand SearchByNameCommand { get; set; }
        private User user;
        public ICommand SearchByPasswordCommand { get; set; }

        
        public LoginageViewModel()
        {
            user = new User() { Name = "התחברות נכשלה" };
            SearchByNameCommand = new Command(FindUserByName(Name), () => !String.IsNullOrEmpty(Name));
        }

        private void FindUser()
        {
            LoginService service = new LoginService();
            List<Monkey> lst = service.FindMonkeysByLocation(Country);
            if (lst.Count > 0)
                monkey = lst[0];
            else
                monkey = new Monkey() { Name = "אין קופים להצגה" };
            Count = lst.Count;
            RefreshData();
            Country = null;
        }

        public void RefreshData()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged(nameof(ImageUrl));
        }
    }
}
