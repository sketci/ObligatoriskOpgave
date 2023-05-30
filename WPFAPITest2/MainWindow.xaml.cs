using API.Controllers;
using System.Windows;
using DBLogik;
using Newtonsoft.Json;
using static DBLogik.DTO.RandomUserDTO;
using System.Net.Http;
using System;
using DBLogik.DTO;
using System.Windows.Documents;
using System.Collections.Generic;

namespace WPFAPITest2
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

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string mail = textBoxMail.Text;
                    var response = await client.GetAsync($"https://localhost:44304/api/Values?mail={mail}");
                    response.EnsureSuccessStatusCode();
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BrugerDTO>(jsonResult);


                    listBoxBrugere.ItemsSource = new List<BrugerDTO> { data };

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while calling the randomuser API: {ex.Message}");
                   
                }
            }
        }
    }
}
