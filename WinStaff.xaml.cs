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
    /// Логика взаимодействия для WinStaff.xaml
    /// </summary>
    public partial class WinStaff : Window
    {
        TutoffCourseEntities BD;
        Staff staff;
        bool ThisNew;

        public WinStaff(TutoffCourseEntities bD, Staff staff, bool thisNew = false)
        {
            InitializeComponent();
            BD = bD;
            this.staff = staff;
            ThisNew = thisNew;

            this.DataContext = staff;

            cmb_brand.ItemsSource = BD.Brand.ToList();
            cmb_city.ItemsSource = BD.City.ToList();
            cmb_street.ItemsSource = BD.Street.ToList();    
            cmb_type.ItemsSource = BD.TypeStaff.ToList();
        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNew)
            {
                if (tb_serianumber.Text != "" & cmb_brand.Text != "" & cmb_city.Text != "" & cmb_model.Text != "" & cmb_street.Text != "" & cmb_type.Text != "")
                {
                    if (BD.Adress.Where(a => a.House == tb_house.Text & a.Street.Title == cmb_street.Text & a.City.Title == cmb_city.Text).FirstOrDefault() == null)
                    {
                        Adress address = new Adress();
                        address.City = BD.City.Where(a => a.Title == cmb_city.Text).First();
                        address.Street = BD.Street.Where(a => a.Title == cmb_street.Text).First();
                        address.House = tb_house.Text;
                        BD.Adress.Add(address);
                        BD.SaveChanges();
                    }
                    staff.Adress = BD.Adress.Where(a => a.House == tb_house.Text
                    & a.Street.Title == cmb_street.Text & a.City.Title == cmb_city.Text).FirstOrDefault();
                    BD.Staff.Add(staff);
                    BD.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Не все поля были заполнены");
                    return;
                }
            }
            this.Close();
        }

        private void cmb_brand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = (int)cmb_brand.SelectedValue;
            cmb_model.ItemsSource = BD.Model.Where(mod => mod.BrandID == i).ToList();
        }
    }
}
