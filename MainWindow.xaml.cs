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

namespace TutoffCursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageClient client = new PageClient();
        PagePay pay = new PagePay();
        PageStaff staff = new PageStaff();
        PageEmpl empl = new PageEmpl();
        PageReq req = new PageReq();

        public MainWindow()
        {
            InitializeComponent();
            tb_auth.Text = CurrentEmploy.UserName;
            
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            new WinLogin().Show();
            this.Close();
        }

        private void bt_Empl_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEmploy.IsAdmin)
            {
                bt_Empl.IsEnabled = false;
                bt_Staff.IsEnabled = true;
                bt_Pays.IsEnabled = true;
                bt_Client.IsEnabled = true;
                bt_Request.IsEnabled = true;
                fr_catalog.Content = empl;
            }
            else
            {
                MessageBox.Show("У вас нет прав на просмотр страницы сотрудников");
            }
        }

        private void bt_Pays_Click(object sender, RoutedEventArgs e)
        {
            bt_Empl.IsEnabled = true ;
            bt_Staff.IsEnabled = true;
            bt_Pays.IsEnabled = false;
            bt_Client.IsEnabled = true;
            bt_Request.IsEnabled = true;
            fr_catalog.Content = pay;
        }

        private void bt_Staff_Click(object sender, RoutedEventArgs e)
        {
            bt_Empl.IsEnabled = true;
            bt_Staff.IsEnabled = false;
            bt_Pays.IsEnabled = true;
            bt_Request.IsEnabled = true;
            bt_Client.IsEnabled = true;
            fr_catalog.Content = staff;
        }

        private void bt_Client_Click(object sender, RoutedEventArgs e)
        {
            bt_Empl.IsEnabled = true;
            bt_Staff.IsEnabled = true;
            bt_Pays.IsEnabled = true;
            bt_Client.IsEnabled = false;
            bt_Request.IsEnabled = true;
            fr_catalog.Content = client;
        }

        private void bt_Request_Click(object sender, RoutedEventArgs e)
        {
            bt_Empl.IsEnabled = true;
            bt_Staff.IsEnabled = true;
            bt_Pays.IsEnabled = true;
            bt_Client.IsEnabled = true;
            bt_Request.IsEnabled = false;
            fr_catalog.Content = req;
        }

    }
}
