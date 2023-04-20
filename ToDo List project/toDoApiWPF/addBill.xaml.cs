using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Xml.Linq;
using toDoApi.Models;
using toDoApiWPF.Models;

namespace toDoApiWPF
{
    /// <summary>
    /// Interaction logic for addBill.xaml
    /// </summary>
    public partial class addBill : Window
    {

        HttpClient client = new HttpClient();
        SqlConnection con = new SqlConnection("Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True");
        public addBill()
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/bill/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private async void saveBills()
        {
            Bill bill = new Bill();
            bill.Id = int.Parse(id.Text);
            bill.Description = descrip.Text;
            bill.Amount=decimal.Parse(amount.Text);
            bill.DueDate=dueDate.Text;
            bill.bankBalance=decimal.Parse(bankBalance.Text);


            HttpResponseMessage billResponse = await client.PostAsJsonAsync<Bill>("AddBill/", bill);

            
            ServerStatus1.Content = billResponse.StatusCode.ToString();
        }
        private async void updateBill()
        {
            Bill bill = new Bill();
            bill.Id = int.Parse(id.Text);
            bill.Description = descrip.Text;
            bill.Amount = decimal.Parse(amount.Text);
            bill.DueDate = dueDate.Text;
            bill.bankBalance = decimal.Parse(bankBalance.Text);

            HttpResponseMessage billResponse = await client.PutAsJsonAsync<Bill>("UpdateBill/", bill);


            ServerStatus2.Content = billResponse.StatusCode.ToString();
        }

        private void GetAllBillsByID()
        {

            var Response = client.GetFromJsonAsync<billResponse>("GetAllBillsByID/" + int.Parse(id.Text));
            Response.Wait();
            Bill bill = Response.Result.bll;
            if (bill != null)
            {
                descrip.Text = bill.Description;
                amount.Text= bill.Amount.ToString();
                dueDate.Text= bill.DueDate;
                bankBalance.Text= bill.bankBalance.ToString();

                ServerStatus3.Content = Response.Result.StatusMessage;
            }
            else
            {
                ServerStatus3.Content = Response.Result.StatusMessage;
            }
        }
        private async void PayBill()
        {
            Bill bill = new Bill();
            bill.Id= int.Parse(id.Text);
            bill.Amount= decimal.Parse(amount.Text);
            bill.bankBalance= decimal.Parse(bankBalance.Text);

            HttpResponseMessage billResponse = await client.PutAsync("PayBill/" + bill.Id + "/" + bill.Amount + "/" + bill.bankBalance, null);

            ServerStatus4.Content = billResponse.StatusCode.ToString();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void viewData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Response = client.GetFromJsonAsync<billResponse>("GetAllBills/");
                Response.Wait();
                if (Response.Result.Bills != null)
                {
                    dataGrid.ItemsSource= Response.Result.Bills;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   

        private void search_Click(object sender, RoutedEventArgs e)
        {
            GetAllBillsByID();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            updateBill();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            saveBills();
        }

        private void pay_Checked(object sender, RoutedEventArgs e)
        {
            PayBill();
        }

      
    }
}
