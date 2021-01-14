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
using System.Diagnostics;

namespace FELM
{
    /// <summary>
    /// Interaction logic for Vare.xaml
    /// </summary>
    public partial class Vare : Page
    {
        public Vare()
        {
            InitializeComponent();
        }

        private void VareGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Kopier_Button(object sender, RoutedEventArgs e)
        {

            List<String> vare = new List<String>();

            foreach (var panel in VareListe.Children)
            {

                if (panel is Border)
                {

                    var border = panel as Border;
                    var borderChild = border.Child;

                    if (borderChild is TextBox tb)
                    {

                        Trace.WriteLine(tb.Text);
                        vare.Add(tb.Text);

                    }

                }

            }

            MessageBox.Show(string.Join(Environment.NewLine, vare));

        }

        public void redigerVare()
        {
            
        }
    }
}
