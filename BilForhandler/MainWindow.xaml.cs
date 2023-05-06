using DBLogik;
using DBLogik.Model;
using System;
using System.Windows;


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

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Bil b = new Bil("Porsche", "911", "2022", 2022, 100.00, 200.00);
            context.Biler.Add(b);
            context.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Bruger nyBruger = new Bruger("John Doe", "john.doe@example.com", "Mand", true);
            context.Bruger.Add(nyBruger);
            context.SaveChanges();
        }

       

    }
}
