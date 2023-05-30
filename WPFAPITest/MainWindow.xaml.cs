using System.Windows;
using DBLogik;
using API;
using DBLogik.DTO;
using API.Controllers;

namespace WPFAPITest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ValuesController vc = new ValuesController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string mail = textBoxMail.Text;
            BrugerDTO bdto = vc.Get(mail);
        }
    }
}
