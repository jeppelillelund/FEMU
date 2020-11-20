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

namespace FELM
{
    /// <summary>
    /// Interaction logic for Tilføj_vare.xaml
    /// </summary>
    public partial class Tilføj_vare : Window
    {
        API api = new API();

        public Tilføj_vare()
        {
            InitializeComponent();
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
           await api.SetFavoritQueryAsync("hej", Vare_Label.Content.ToString(), Antal_TextBox.Text);
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {

        }

        
        
    }
}
