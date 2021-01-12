using Newtonsoft.Json.Linq;
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
        API Api = new API();
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login_Button(object sender, RoutedEventArgs e)
        {
            string[] result = { "false" };
            JObject stringResult = await Api.LoginQueryAsync(LoginTextBox.Text, PasswordTextBox.Password.ToString());
            String status = (string)stringResult.First.First;
            try {
               // result = stringResult[0].First.First;
            }
            catch (Exception error) {
                Console.WriteLine(error);
            }
            
            if (status == "true"){
                NavigationService.Navigate(Pages.p5);
            }

        }
    }
   
}
