using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TM.DailyTrackR.Common;
using TM.DailyTrackR.DataType;
using TM.DailyTrackR.ViewModel;

namespace TM.DailyTrackR.View
{

	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
			this.DataContext = new LoginViewModel();
		}

		private void LoginToApp(object sender, RoutedEventArgs e)
		{
			string usermame = usernameTextBox.Text;
			string password = passwordBox.Password;
			if (usermame == "" || password == "")
			{
				MessageBox.Show("Please enter your credentials", "Error");
			}
			else
			{
				User loggedUser = LogicHelper.Instance.LoginController.Login(usermame, password);
				if (loggedUser != null)
				{
					UserService.Instance.SetLoggedInUser(loggedUser);
					ViewService.Instance.ShowWindow(new MainWindowViewModel());
				}
				else
				{
					MessageBox.Show("Invalid credentials", "Login Error");
				}
			}
			
		}
	}
}
