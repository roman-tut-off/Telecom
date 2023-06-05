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
    /// Логика взаимодействия для PageEmpl.xaml
    /// </summary>
    public partial class PageEmpl : Page
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        public PageEmpl()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void bt_add_click(object sender, RoutedEventArgs e)
        {
            var empl = new Employ();
            var win = new WinEmpl(BD, empl, true);
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
            if (dg_catalog.SelectedValue != null)
            {
                int i = (int)dg_catalog.SelectedValue;
                Employ item = BD.Employ.Where(a => a.EmployID == i).First();
                var win = new WinEmpl(BD, item);
                win.ShowDialog();
                win.Close();
                dg_catalog.SelectedValue = null;
                tb_search.Text = "";
                UpdateDataGrid();
            }
        }
        public void UpdateDataGrid()
        {
            if (tb_search.Text != null)
            {
                dg_catalog.ItemsSource = BD.Employ.Where(cl => cl.IsDeleted == false).Where(cl => cl.Surname.ToLower().Contains(tb_search.Text)).ToList();
            }
            else
            {
                dg_catalog.ItemsSource = BD.Employ.Where(cl => cl.IsDeleted == false).ToList();
            }
        }
    }
}
