using System;
using System.Collections.Generic;
using System.IO;
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

namespace English
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;

        public MainWindow()
        {
            users = new List<User>();
            GetUsers();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                if(LoginTextBox.Text == item.Login && passwordBox.Password == item.Password)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void GetUsers()
        {
            try
            {
                List<string> list = File.ReadAllLines("users.txt").ToList();
                foreach (var item in list)
                {
                    string[] tmp = item.Split(' ');
                    users.Add(new User(tmp[0], tmp[1], int.Parse(tmp[2]), int.Parse(tmp[3])));
                }
            }
            catch
            {
                MessageBox.Show("Error in file!");
                Environment.Exit(0);
            }
        }
    }
}
