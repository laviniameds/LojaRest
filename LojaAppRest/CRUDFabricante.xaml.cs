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
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace LojaAppRest
{
    /// <summary>
    /// Interaction logic for CRUDFabricante.xaml
    /// </summary>
    public partial class CRUDFabricante : Window
    {
        public CRUDFabricante()
        {
            InitializeComponent();
        }

        private string ip = "http://localhost:57471/";

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Fabricante/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Fabricante> obj = JsonConvert.DeserializeObject<List<Models.Fabricante>>(str);
            dataGrid.ItemsSource = obj;
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Fabricante f = new Models.Fabricante
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text
            };
            List<Models.Fabricante> fl = new List<Models.Fabricante>();
            fl.Add(f);
            string s = "=" + JsonConvert.SerializeObject(fl);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PostAsync("/api/Fabricante/", content);
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Fabricante f = new Models.Fabricante
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text
            };
            string s = "=" + JsonConvert.SerializeObject(f);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Fabricante/" + f.Id, content);
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            await httpClient.DeleteAsync("/api/Fabricante/" + txtId.Text);
        }
    }
}
