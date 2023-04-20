using Microsoft.VisualBasic;
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
using Task = toDoApiWPF.Models.Task;

namespace toDoApiWPF
{
    /// <summary>
    /// Interaction logic for AddNewTask.xaml
    /// </summary>
    public partial class AddNewTask : Window
    {

        HttpClient client = new HttpClient();
        SqlConnection con = new SqlConnection("Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True");
     

        public AddNewTask()
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/task/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private async void savetask()
        {
            Task task = new Task();
            task.Id = int.Parse(id.Text);
            task.Activity = (activity.Text);
            task.DateTime = dateTm.Text;

            HttpResponseMessage response = await client.PostAsJsonAsync<Task>("Addtask/", task);

            ServerStatus4.Content = response.StatusCode.ToString();
        }

        private void listTaskById()
        {

            var response = client.GetFromJsonAsync<Response>("GetTaskByID/" + int.Parse(id.Text));

            Task task = response.Result.task;
            if (task != null)
            {
                task.Activity = (activity.Text);
                task.DateTime =dateTm.Text;

                ServerStatus1.Content = response.Result.StatusMessage;
            }
            else
            {
                ServerStatus1.Content = response.Result.StatusMessage;
            }
        }

        private async void deleteTasktById()
        {
            HttpResponseMessage response = await client.DeleteAsync("DeleteTask/" + int.Parse(id.Text));
            if (response != null)
            {
                ServerStatus2.Content = response.StatusCode.ToString();
            }
            else
            {
                MessageBox.Show("ID does not Exist!");
            }
        }

        private async void updateTask()
        {
            Task task = new Task();
            task.Id = int.Parse(id.Text);
            task.Activity = (activity.Text);
            task.DateTime = dateTm.Text;

            HttpResponseMessage response = await client.PutAsJsonAsync<Task>("UpdateTask/", task);

            ServerStatus3.Content = response.StatusCode.ToString();
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
                string connectionString =
               "Data Source=SAHAR\\SQLEXPRESS;Initial Catalog=UserDB;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                string Query = "Select * from schedule";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGrid.ItemsSource = DT.AsDataView();
                DataContext = DA;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Checked(object sender, RoutedEventArgs e)
        {
            deleteTasktById();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            listTaskById();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            updateTask();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            savetask();
        }
    }
}
