using System.Linq;
using System.Windows;

namespace TutoffCursach
{
    /// <summary>
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        public WinLogin()
        {
            InitializeComponent();
            CurrentEmploy.IsAdmin = false;
            CurrentEmploy.EmplID = 0;
            CurrentEmploy.UserName = "";
        }

        private void Bt_auth_Click(object sender, RoutedEventArgs e)
        {
            var temp = BD.Employ.Where(em => em.LoginUser == tb_Login.Text & em.PasswordUser == tb_Pass.Password).ToList();
            if (temp.Count == 1)
            {
                CurrentEmploy.IsAdmin = temp.First().IsAdmin;
                CurrentEmploy.EmplID = temp.First().EmployID;
                CurrentEmploy.UserName = temp.First().Surname;
                var w = new MainWindow();
                w.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
    }
}
