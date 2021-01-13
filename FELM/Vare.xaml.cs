using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Vare.xaml
    /// </summary>
    public partial class Vare : Page
    {
        public class dummiData
        {
            public int VareNummer { get; set; }
            public string Beskrivelse { get; set; }
            public string tilgang { get; set; }
            public string afgang { get; set; }
            public string ampere { get; set; }
            public string note { get; set; }
            public string Status { get; set; }
            public int Antal { get; set; }
            public string Lokation { get; set; }
            public int pinNr { get; set; }
            public int webshopVarenummer { get; set; }
            public int længde { get; set; }
            public int rFID { get; set; }
            public bool favorit { get; set; }

            public dummiData(int VareNummer, string Beskrivelse, string tilgang, string afgang, string ampere, string note, string Status, int Antal, string Lokation, int pinNr, int webshopVarenummer, int længde, int rFID, bool favorit)
            {
                this.VareNummer = VareNummer;
                this.Beskrivelse = Beskrivelse;
                this.tilgang = tilgang;
                this.afgang = afgang;
                this.ampere = ampere;
                this.note = note;
                this.Status = Status;
                this.Antal = Antal;
                this.Lokation = Lokation;
                this.pinNr = pinNr;
                this.webshopVarenummer = webshopVarenummer;
                this.længde = længde;
                this.rFID = rFID;
                this.favorit = favorit;
            }


        }
        ICollectionView cvVare;
        List<dummiData> myList = new List<dummiData>();


        public Vare()
        {
            InitializeComponent();
            maList();

            cvVare = CollectionViewSource.GetDefaultView(myList);

            if (cvVare != null)
            {
                Vare.ItemsSource = myList;
                cvVare.Filter = seachFilter;
            }
        }

        public bool seachFilter(object o)
        {
            dummiData v = (o as dummiData);
            if (v == null)
                return false;

            if (v.Beskrivelse.Contains(seachbox.Text))
                return true;
            else
                return false;
        }

        public void maList()
        {
            myList.Add(new dummiData(1, "første", "stik", "usb", "40amp", "ingen", "klar", 3, "lager1", 7840, 1, 14, 1, true));
            myList.Add(new dummiData(12, "anden", "stik", "usb", "30amp", "ingen", "klar", 3, "lager1", 7840, 1, 16, 1, false));
            myList.Add(new dummiData(30, "tredje", "stik", "usb", "45amp", "ingen", "klar", 1, "lager1", 8000, 1, 15, 1, true));
            myList.Add(new dummiData(35, "4", "stik", "usb", "45amp", "ingen", "klar", 1, "lager1", 8000, 1, 15, 1, true));
        }








    }
}
