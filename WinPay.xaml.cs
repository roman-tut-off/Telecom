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

namespace TutoffCursach
{
    /// <summary>
    /// Логика взаимодействия для WinPay.xaml
    /// </summary>
    public partial class WinPay : Window
    {
        TutoffCourseEntities BD;
        Pay pay;
        bool ThisNew;
        public WinPay(TutoffCourseEntities bD, Pay pay, bool thisNew = false)
        {
            InitializeComponent();
            BD = bD;
            this.pay = pay;
            ThisNew = thisNew;

            pay.DatePay = DateTime.Now;
            this.DataContext = pay;
            cmb_client.ItemsSource = BD.Client.Where(cl => cl.IsDelected == false).ToList();
        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNew == true)
            {
                if(cmb_client.Text != "" & tb_cost.Text != "")
                {
                    Client temp = (Client)cmb_client.SelectedItem;
                    temp.Balance += pay.Cost;
                    pay.BalanceAfter = temp.Balance;
                    pay.EmployID = CurrentEmploy.EmplID;
                    BD.Pay.Add(pay);
                    BD.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Не все поля были введены");
                    return;
                }

            }
            this.Close();
        }
    }
}
