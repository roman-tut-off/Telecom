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
    /// Логика взаимодействия для PagePay.xaml
    /// </summary>
    public partial class PagePay : Page
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();   
        public PagePay()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void bt_add_click(object sender, RoutedEventArgs e)
        {
            var pay = new Pay();
            var win = new WinPay(BD, pay, true);
            win.ShowDialog();
            UpdateDataGrid();
        }

        private void bt_search_click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void bt_clear_click(object sender, RoutedEventArgs e)
        {
            tb_search.Text = string.Empty;
            UpdateDataGrid();
        }

        private void dg_catalog_click(object sender, SelectionChangedEventArgs e)
        {

        }
        public void UpdateDataGrid()
        {
            if (tb_search.Text != null)
            {
                dg_catalog.ItemsSource = BD.Pay.Where(cl => cl.Client.AbonentNumb.ToLower().Contains(tb_search.Text)).ToList();
            }
            else
            {
                dg_catalog.ItemsSource = BD.Pay.ToList();
            }
        }
    }
}
