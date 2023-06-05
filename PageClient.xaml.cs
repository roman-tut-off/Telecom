using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TutoffCursach
{
    public partial class PageClient : Page
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        public PageClient()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void bt_add_click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var win = new WinClient(BD, client, true);
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
                Client item = BD.Client.Where(a => a.ClientID == i).First();
                var win = new WinClient(BD, item);
                win.ShowDialog();
                win.Close();
                dg_catalog.SelectedValue = null;
                tb_search.Text = "";
                UpdateDataGrid();
            }
        }
        public void UpdateDataGrid()
        {
            if(tb_search.Text != null)
            {
                dg_catalog.ItemsSource = BD.Client.Where(cl => cl.IsDelected == false).Where(cl => cl.AbonentNumb.ToLower().Contains(tb_search.Text)).ToList();
            }
            else
            {
                dg_catalog.ItemsSource = BD.Client.Where(cl => cl.IsDelected == false).ToList();
            }
        }
    }
}
