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
    /// Логика взаимодействия для WinEmpl.xaml
    /// </summary>
    public partial class WinEmpl : Window
    {
        TutoffCourseEntities BD;
        Employ employ;
        bool ThisNew;
        public WinEmpl(TutoffCourseEntities bD, Employ employ, bool thisNew =false)
        {
            InitializeComponent();
            BD = bD;
            this.employ = employ;
            ThisNew = thisNew;

            cmb_post.ItemsSource = BD.Post.ToList();

            this.DataContext = employ;
        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {
            if(ThisNew == false)
            {
                employ.IsDeleted = true;
            }
            BD.SaveChanges();
            this.Close();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNew == true)
            {
                if(tb_1.Text != "" & tb_2.Text != "" & tb_3.Text != "" & tb_4.Text != "" & tb_5.Text != "" & tb_6.Text != "" & tb_7.Text != "" & cmb_post.Text != "")
                {
                    BD.Employ.Add(employ);
                }
                else
                {
                    MessageBox.Show("Не все поля были введены");
                    return;
                }
            }
            BD.SaveChanges();
            this.Close();
        }
    }
}
