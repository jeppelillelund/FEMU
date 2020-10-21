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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FELM
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        API apiLogin = new API();
        public LoginPage()
        {

            InitializeComponent();
        }
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var loginVerified = await apiLogin.LoginQuery(LoginTextBox.Text, PasswordTextBox.Text);
            if (loginVerified)
            {
                NavigationService.Navigate(Pages.p5);
            }
        }
    }
   
}
