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

            var bc = new BrushConverter();

            Console.WriteLine(stringResult);
            EventStackPanel.Children.Clear();
            for (int i = 0; i <= 1; i++)
            {
                Button newButton = new Button();
                if(i % 2 == 0) 
                {
                    newButton.Background = (Brush)bc.ConvertFrom("#00b5a3");
                }
                else
                {
                    newButton.Background = (Brush)bc.ConvertFrom("#017056");
                }

                newButton.Name = $"eventbutton{i}";
                newButton.Content = stringRArray[i];
                newButton.Width = 420;
                newButton.HorizontalAlignment = HorizontalAlignment.Center;
                newButton.VerticalAlignment = VerticalAlignment.Center;
                newButton.FontWeight = FontWeights.Bold;
                newButton.BorderThickness = new Thickness(0);
                newButton.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                newButton.Margin = new Thickness(0, 10, 0, 0);

                newButton.Click += (s, se) => {/*API CALL MM. her*/};
                EventStackPanel.Children.Add(newButton);
            }
        }
    }
}
