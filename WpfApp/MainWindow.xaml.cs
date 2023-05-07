using DBLogik;
using DBLogik.Model;
using System;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Database context = new Database();

        public MainWindow()
        {
            InitializeComponent();
            BilListeVisning_SelectionChanged(null, null);
            BrugerListBox_SelectionChanged(null, null);
        }

        private string radioButtonKønValg()
        {
            if (BrugerMandRadio.IsChecked == true)
            {
                return "Mand";
            }
            else if (BrugerKvindeRadio.IsChecked == true)
            {
                return "Kvinde";
            }
            else if (BrugerAndetRadio.IsChecked == true)
            {
                return "Andet";
            }
            else
            {
                return "Ej oplyst";
            }
        }

        private bool brugerBørnCheck()
        {
            if (BrugerBørnCheckBox.IsChecked == true)
            {
                return true;
            }
            else
            {
                return false;
            };
        }


        private void BilTilføjKnap_Click(object sender, RoutedEventArgs e)
        {
            Bil b = new Bil(BilNavn.Text, BilMærke.Text, BilModel.Text, int.Parse(BilÅr.Text), double.Parse(BilIndkøbspris.Text), double.Parse(BilSalgspris.Text));
            context.Biler.Add(b);
            context.SaveChanges();
            BilListeVisning_SelectionChanged(null, null);
        }

        
        
        private void BilListeVisning_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var alleBiler = context.Biler.ToList();
            BilListeVisning.ItemsSource = alleBiler;
        }
        
      

        private void BilOpdater_Click(object sender, RoutedEventArgs e)
        {
   
            var selectedBil = BilListeVisning.SelectedItem as Bil;
            if (selectedBil != null)
            {
                var bil = context.Biler.FirstOrDefault(b => b.BilId == selectedBil.BilId);
                bil.Navn = BilNavn.Text;
                bil.Mærke = BilMærke.Text;
                bil.Model = BilModel.Text;
                bil.År = int.Parse(BilÅr.Text);
                bil.IndKPris = double.Parse(BilIndkøbspris.Text);
                bil.SalgsPris = double.Parse(BilSalgspris.Text);
            }
            context.SaveChanges();
            BilListeVisning_SelectionChanged(null,null);
        }

        private void BilSlet_Click(object sender, RoutedEventArgs e)
        {
            var selectedBil = BilListeVisning.SelectedItem as Bil;
            if (selectedBil != null)
            {
                var bil = context.Biler.FirstOrDefault(b => b.BilId == selectedBil.BilId);
                context.Biler.Remove(bil);
                context.SaveChanges();
            }

            BilListeVisning_SelectionChanged(null, null);
            }

        private void BrugerTilføj_Click(object sender, RoutedEventArgs e)
        {
            Bruger br = new Bruger(BrugerNavn.Text, BrugerMail.Text, radioButtonKønValg(), brugerBørnCheck());
            context.Bruger.Add(br);
            context.SaveChanges();
            BrugerListBox_SelectionChanged(null, null);
        }

        private void BrugerListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var alleBrugere = context.Bruger.ToList();
            BrugerListBox.ItemsSource = alleBrugere;
        }
       

        private void BrugerOpdaterKnap_Click(object sender, RoutedEventArgs e)
        {
            var selectedBruger = BrugerListBox.SelectedItem as Bruger;
            if (selectedBruger != null)
            {
                var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == selectedBruger.BrugerId);
                bruger.Navn = BrugerNavn.Text;
                bruger.Mail = BrugerMail.Text;
                bruger.HarBørn = brugerBørnCheck();
                bruger.Køn = radioButtonKønValg();
                context.SaveChanges();
                BrugerListBox_SelectionChanged(null, null);
            }

        }

        private void BrugerSletKnap_Click(object sender, RoutedEventArgs e)
        {
            var selectedBruger = BrugerListBox.SelectedItem as Bruger;
            if (selectedBruger != null)
            {
                var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == selectedBruger.BrugerId);
                context.Bruger.Remove(bruger);
                context.SaveChanges();
            }
        }

        private void buttonBrugerId_Click(object sender, RoutedEventArgs e)
        {
            var selectedBruger = BrugerListBox.SelectedItem as Bruger;
            var selectedBil = BilListeVisning.SelectedItem as Bil;
            if (selectedBil != null && selectedBruger != null) 
            {
                var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == selectedBruger.BrugerId);
                var bil = context.Biler.FirstOrDefault(b => b.BilId == selectedBil.BilId);
                bil.BrugerId = bruger.BrugerId;
                context.SaveChanges();
                BrugerListBox_SelectionChanged(null, null);
                BilListeVisning_SelectionChanged(null, null);
            }
        }
    }
}
