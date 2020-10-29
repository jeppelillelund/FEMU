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
    /// Interaction logic for ScanPage.xaml
    /// </summary>
    public partial class ScanPage : Page
    {
        API Api = new API();
        public ScanPage()
        {
            InitializeComponent();
        }

        private void ScanBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.p5);
        }

        private async void Historik_Click(object sender, RoutedEventArgs e)
        {
            string stringResult = await Api.AllEventsQueryAsync();
            Console.WriteLine(stringResult);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string stringResult = await Api.AllEventsQueryAsync();
            string[] stringRArray = stringResult.Split(',');
            Console.WriteLine(stringResult);
            for (int i = 0; i <= 2; i++)
            {
                Button newButton = new Button();
                newButton.Content = stringRArray[i];
                newButton.Click += (s, se) => {/*API CALL MM. her*/};
                EventStackPanel.Children.Add(newButton);
            }
        }
    }
}
