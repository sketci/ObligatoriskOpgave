using BilForhandler.DataAccessLayer;
using BilForhandler.Model;
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

namespace BilForhandler
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pris p = new Pris("PorschePris", 100.00, true, false);
            context.Priser.Add(p);
            context.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PriserListe.Items.Clear();
            foreach(Pris p in context.Priser)
            {
                PriserListe.Items.Add(p);
            }
        }
    }
}
