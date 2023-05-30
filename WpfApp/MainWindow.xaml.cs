using DBLogik;
using DBLogik.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static DBLogik.DTO.RandomUserDTO;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Database context = new Database();
        private BrugerBilViewModel vm = new BrugerBilViewModel();

        public MainWindow()
        {
            InitializeComponent();
            BilListeVisning_SelectionChanged(null, null);
            BrugerListBox_SelectionChanged(null, null);
            _ = GetRandomUser();
            
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

        
        /*
        private void BilTilføjKnap_Click(object sender, RoutedEventArgs e)
        {
            
            Bil b = new Bil(BilNavn.Text, BilMærke.Text, BilModel.Text, int.Parse(BilÅr.Text),
                    double.Parse(BilIndkøbspris.Text), double.Parse(BilSalgspris.Text));
          
                context.Biler.Add(b);
                context.SaveChanges();
                BilListeVisning_SelectionChanged(null, null);
        }
        */

        private void BilTilføjKnap_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(BilÅr.Text, out int år) &&
               double.TryParse(BilIndkøbspris.Text, out double indkøbspris) &&
               double.TryParse(BilSalgspris.Text, out double salgspris))
            {
                Bil b = new Bil(BilNavn.Text, BilMærke.Text, BilModel.Text, år, indkøbspris, salgspris);
                context.Biler.Add(b);
                context.SaveChanges();
                BilListeVisning_SelectionChanged(null, null);
            }
            else
            {
                StatusLabel.Text = "Ugyldigt input. Prøv igen.";
            }
        }


        private void BilListeVisning_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var alleBiler = context.Biler.ToList();
            BilListeVisning.ItemsSource = alleBiler;
        }

        private void BilListeVisning_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBil = (Bil)BilListeVisning.SelectedItem;
            if (selectedBil != null)
            {
                var bil = context.Biler.FirstOrDefault(b => b.BilId == selectedBil.BilId);
                MessageBox.Show(bil.ToStringWithAllAttributes(), "Bil detaljer");
            }
        }

        private void BilOpdater_Click(object sender, RoutedEventArgs e)
        {
            var selectedBil = BilListeVisning.SelectedItem as Bil;
            if (selectedBil != null)
            {
                if (int.TryParse(BilÅr.Text, out int år) &&
                    double.TryParse(BilIndkøbspris.Text, out double indkøbspris) &&
                    double.TryParse(BilSalgspris.Text, out double salgspris))
                {
                    var bil = context.Biler.FirstOrDefault(b => b.BilId == selectedBil.BilId);
                    bil.Navn = BilNavn.Text;
                    bil.Mærke = BilMærke.Text;
                    bil.Model = BilModel.Text;
                    bil.År = år;
                    bil.IndKPris = indkøbspris;
                    bil.SalgsPris = salgspris;

                    context.SaveChanges();
                    BilListeVisning_SelectionChanged(null, null);
                }
                else
                {
                    StatusLabel.Text = "Ugyldigt input. Prøv igen.";
                }
            }
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
            if (!string.IsNullOrWhiteSpace(BrugerNavn.Text) &&
               !string.IsNullOrWhiteSpace(BrugerMail.Text) &&
               radioButtonKønValg() != null)
            {
                Bruger br = new Bruger(BrugerNavn.Text, BrugerMail.Text, radioButtonKønValg(), brugerBørnCheck());
                context.Bruger.Add(br);
                context.SaveChanges();
                BrugerListBox_SelectionChanged(null, null);
            }
            else
            {
                StatusLabel.Text = "Ugyldigt input. Prøv igen.";
            }
        }

        private void BrugerListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var alleBrugere = context.Bruger.ToList();
            BrugerListBox.ItemsSource = alleBrugere;
        }

        private void BrugerListeVisning_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBruger = (Bruger)BrugerListBox.SelectedItem;
            if (selectedBruger != null)
            {
                var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == selectedBruger.BrugerId);
                MessageBox.Show(bruger.ToDetailedString(), "Bruger Detaljer");
            }
        }


        private void BrugerOpdaterKnap_Click(object sender, RoutedEventArgs e)
        {
            var selectedBruger = BrugerListBox.SelectedItem as Bruger;
            if (selectedBruger != null)
            {
                if (!string.IsNullOrWhiteSpace(BrugerNavn.Text) &&
                    !string.IsNullOrWhiteSpace(BrugerMail.Text) &&
                    radioButtonKønValg() != null)
                {
                    var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == selectedBruger.BrugerId);
                    bruger.Navn = BrugerNavn.Text;
                    bruger.Mail = BrugerMail.Text;
                    bruger.HarBørn = brugerBørnCheck();
                    bruger.Køn = radioButtonKønValg();
                    context.SaveChanges();
                    BrugerListBox_SelectionChanged(null, null);
                }
                else
                {
                    StatusLabel.Text = "Ugyldigt input. Prøv igen.";
                }
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

        public async Task<string> GetRandomUser()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://randomuser.me/api/?results=1");
                    response.EnsureSuccessStatusCode();
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Root>(jsonResult);

                    foreach (var result in data.results)
                    {
                        string navn = result.name.first + " " + result.name.last;
                        string mail = result.email;
                        
                        if (result.gender == "male")
                        {
                         
                            BrugerMandRadio.IsChecked = true;
                        }
                        else if (result.gender == "female")
                        {
                  
                            BrugerKvindeRadio.IsChecked = true;
                        }
                        else
                        {
                           
                            BrugerAndetRadio.IsChecked = true;
                        }

                        BrugerNavn.Text = navn;
                        BrugerMail.Text = mail;
                    }
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while calling the randomuser API: {ex.Message}");
                    return null;
                }
            }
        }

        private void BrugerTilføjRandom_Click(object sender, RoutedEventArgs e)
        {
            _ = GetRandomUser();
        }
    }
}
