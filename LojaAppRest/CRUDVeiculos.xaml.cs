using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace LojaAppRest
{
    /// <summary>
    /// Interaction logic for CRUDVeiculos.xaml
    /// </summary>
    public partial class CRUDVeiculos : Window
    {
        public CRUDVeiculos()
        {
            InitializeComponent();
            dp.SelectedDate = DateTime.Now;
            SelectFab();
        }

        private string ip = "http://localhost:57471/";

        private async void SelectFab()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Fabricante/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Fabricante> obj = JsonConvert.DeserializeObject<List<Models.Fabricante>>(str);
            cb.ItemsSource = obj;
            cb.SelectedValuePath = "Id";
            cb.DisplayMemberPath = "Descricao";
        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Veiculo/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Veiculo> obj = JsonConvert.DeserializeObject<List<Models.Veiculo>>(str);
            dataGrid.ItemsSource = obj;
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Veiculo f = new Models.Veiculo
            {
                Id = int.Parse(txtID.Text),
                Modelo = txtModelo.Text,
                Ano = int.Parse(txtAno.Text),
                IdFabricante = int.Parse(cb.SelectedValue.ToString()),
                DataCompra = Convert.ToDateTime(dp.SelectedDate),
                ValorCompra = Convert.ToDecimal(txtValorCompra.Text),
                PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text),
            };
            List<Models.Veiculo> fl = new List<Models.Veiculo>();
            fl.Add(f);
            string s = "=" + JsonConvert.SerializeObject(fl);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PostAsync("/api/Veiculo/", content);
            MessageBox.Show("Inserido com sucesso!");
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Veiculo f = new Models.Veiculo
            {
                Modelo = txtModelo.Text,
                Ano = int.Parse(txtAno.Text),
                IdFabricante = int.Parse(cb.SelectedValuePath),
                DataCompra = Convert.ToDateTime(dp.SelectedDate),
                ValorCompra = Convert.ToDecimal(txtValorCompra.Text),
                PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text),
            };
            string s = "=" + JsonConvert.SerializeObject(f);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Veiculo/" + f.Id, content);
            MessageBox.Show("Atualizado com sucesso!");
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            await httpClient.DeleteAsync("/api/Veiculo/" + txtID.Text);
            MessageBox.Show("Deletado com sucesso!");
        }
    }
}
