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
    /// Логика взаимодействия для PageStaff.xaml
    /// </summary>
    public partial class PageStaff : Page
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        public PageStaff()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void bt_add_click(object sender, RoutedEventArgs e)
        {
            var staff = new Staff();
            var win = new WinStaff(BD, staff, true);
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
                dg_catalog.ItemsSource = BD.Staff.Where(cl => cl.SerialNumber.ToLower().Contains(tb_search.Text)).ToList();
            }
            else
            {
                dg_catalog.ItemsSource = BD.Staff.ToList();
            }
        }
    }
}
