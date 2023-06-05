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
    /// Логика взаимодействия для WinReq.xaml
    /// </summary>
    public partial class WinReq : Window
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        Request request = new Request();
        bool ThisNew;
        public WinReq(TutoffCourseEntities BD, Request request, bool thisNew = false)
        {
            InitializeComponent();
            cmb_client.ItemsSource = BD.Client.Where(cl => cl.IsDelected == false).ToList();
            cmb_type.ItemsSource = BD.TypeReq.ToList();
            cmb_status.ItemsSource = BD.StatusReq.ToList();
            this.BD = BD;
            this.request = request;
            ThisNew = thisNew;
            if (ThisNew)
            {
                request.DateReq = DateTime.Now;
            }
            this.DataContext = request;
        }

        private void cmb_client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            request.Client = (Client)cmb_client.SelectedValue;
        }

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmb_elem.ItemsSource = BD.ElemReq.Where(t => t.TypeReqID == (int)cmb_type.SelectedValue).ToList();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNew)
            {
                if(tb_text.Text != "" & tb_title.Text != "" & cmb_client.Text != "" & cmb_elem.Text != "" & cmb_status.Text != "" & cmb_type.Text != "")
                {
                    BD.Request.Add(request);
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
            }
            BD.SaveChanges();
            this.Close();
        }

        private void bt_canc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
