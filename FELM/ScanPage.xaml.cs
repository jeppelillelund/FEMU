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
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace FELM
{
    /// <summary>
    /// Interaction logic for ScanPage.xaml
    /// </summary>
    public partial class ScanPage : Page
    {
        bool ToggleFavorit = false;

        API Api = new API();
        public ScanPage()
        {
            InitializeComponent();
        }

        private void ScanBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.p5);
        }

        

        private async void history_Button(object sender, RoutedEventArgs e)
        {
            JArray stringResult = await Api.AllEventsQueryAsync();

            var bc = new BrushConverter();

            Console.WriteLine(stringResult);
            EventStackPanel.Children.Clear();
            for (int i = 0; i < stringResult.Count(); i++)
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
                newButton.Content = stringResult[i].First.First;
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

        private async void Favorit_Button(object sender, RoutedEventArgs e)
        {
            if(ToggleFavorit == false)
            {
                JArray stringResult = await Api.AllFavoritsQuery();
                //string[] stringRArray = new string[] { "hej", "nope", "hypsa" };

                var bc = new BrushConverter();

                 //Console.WriteLine(stringResult);
                FavoritBorder.Visibility = Visibility.Visible;
                FavoritStackPanel.Children.Clear();
                for (int i = 0; i < stringResult.Count(); i++)
                {
                    Button newButton = new Button();
                    Tilføj_vare popup = new Tilføj_vare();
                    if (i % 2 == 0)
                    {
                        newButton.Background = (Brush)bc.ConvertFrom("#00b5a3");
                    }
                    else
                    {
                        newButton.Background = (Brush)bc.ConvertFrom("#017056");
                    }

                    newButton.Name = $"FavoritButton{i}";
                    newButton.Content = stringResult[i].First.First;
                    newButton.Width = 420;
                    newButton.HorizontalAlignment = HorizontalAlignment.Center;
                    newButton.VerticalAlignment = VerticalAlignment.Center;
                    newButton.FontWeight = FontWeights.Bold;
                    newButton.BorderThickness = new Thickness(0);
                    newButton.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
                    newButton.Margin = new Thickness(0, 10, 0, 0);

                    popup.Vare_Label.Content = stringResult[i].First.First;


                    newButton.Click += (s, se) => 
                    {
                        popup.ShowDialog();
                    };
                    FavoritStackPanel.Children.Add(newButton);



                    ToggleFavorit = true;
                }
            }
            else if(ToggleFavorit == true)
            {
                FavoritBorder.Visibility = Visibility.Hidden;
                ToggleFavorit = false;
            }

        }

        private async void Antenne_Button(object sender, RoutedEventArgs e)
        {
            JArray hypsa = await Api.GetItemsQueryAsync();
        }

        private void Toggle_Aflevering_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Scanner(object sender, RoutedEventArgs e)
        {

        }
    }
}
