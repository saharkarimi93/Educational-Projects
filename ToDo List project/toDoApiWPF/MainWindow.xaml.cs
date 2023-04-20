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

namespace toDoApiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addtask_Click(object sender, RoutedEventArgs e)
        {
            AddNewTask addNewTask = new AddNewTask();
            addNewTask.Show();
            this.Close();
        }

        private void Bill_Click(object sender, RoutedEventArgs e)
        {
            addBill addBill = new addBill();
            addBill.Show();
            this.Close();
        }
    }
}
