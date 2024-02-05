using Login.ViewModels;
using Login.Views;
namespace Login.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginPageViewModel();
	}

}