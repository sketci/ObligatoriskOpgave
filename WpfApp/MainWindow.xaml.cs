using DBLogik;
using DBLogik.Model;
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
        }

        private void BrugerTilføj_Click(object sender, RoutedEventArgs e)
        {
            Bruger br = new Bruger(BrugerNavn.Text, BrugerMail.Text, radioButtonKønValg(), brugerBørnCheck());
            context.Bruger.Add(br);
            context.SaveChanges();
        }
    }
}
