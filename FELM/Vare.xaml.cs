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

        public List<VareClass> Listen = new List<VareClass>();

        public Vare()
        {
            InitializeComponent();
            DummyListe();
            VareGrid.ItemsSource = Listen;
        }

        private void VareGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void DummyListe()
        {
            Listen.Add(new VareClass(0, "vare1", "?", "?", 10, "vare1", true, 1, 11, 1234));
            Listen.Add(new VareClass(1, "vare2", "?", "?", 20, "vare2", false, 2, 22, 1234));
            Listen.Add(new VareClass(2, "vare3", "?", "?", 30, "vare3", true, 3, 33, 1234));
            Listen.Add(new VareClass(3, "vare4", "?", "?", 40, "vare4", false, 4, 44, 1234));
        }


        private void Kopier_Button(object sender, RoutedEventArgs e)
        {
            var row = (VareClass)VareGrid.SelectedItem;
            VareNummer.Text = row.VareNr.ToString();
            Beskrivelse.Text = row.Beskrivelse;
            StikTypeTilgang.Text = row.Tilgang;
            StikTypeAfgang.Text = row.Afgang;
            Ampere.Text = row.Ampere.ToString();
            Note.Text = row.Note;
            Status.Text = row.Status.ToString();
            Antal.Text = row.Antal.ToString();
            VareLokation.Text = row.VareLokation.ToString();
            PinNummer.Text = row.PinNr.ToString();


            /*List<String> vare = new List<String>();

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

            MessageBox.Show(string.Join(Environment.NewLine, vare));*/

        }

        public void redigerVare()
        {
            
        }
    }
}
