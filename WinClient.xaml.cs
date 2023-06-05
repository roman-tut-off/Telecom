using System.Linq;
using System.Windows;

namespace TutoffCursach
{
    public partial class WinClient : Window
    {
        TutoffCourseEntities BD = new TutoffCourseEntities();
        Client client = new Client();
        bool ThisNew;
        public WinClient(TutoffCourseEntities bD, Client client, bool thisNew =false)
        {
            InitializeComponent();
            BD = bD;
            this.client = client;
            ThisNew = thisNew;
            this.DataContext = client;

            cmb_city.ItemsSource = BD.City.ToList();
            cmb_street.ItemsSource = BD.Street.ToList();
            cmb_tarif.ItemsSource = BD.Tarif.ToList();
        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {
            if(ThisNew != true)
            {
                client.IsDelected = true;
            }
            BD.SaveChanges();
            this.Close();
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNew == true)
            {
                if (tb_1.Text != "" & tb_1.Text != "" & tb_3.Text != "" & tb_4.Text != "" & tb_5.Text != "" & tb_house.Text != "" & cmb_city.Text!="" & cmb_street.Text!="" & cmb_tarif.Text!="")
                {
                    if (cmb_city.Text != "")
                    {
                        if (BD.Adress.Where(a => a.House == tb_house.Text & a.Apart == tb_apart.Text & a.Street.Title == cmb_street.Text & a.City.Title == cmb_city.Text).FirstOrDefault() == null)
                        {
                            Adress address = new Adress();
                            address.City = BD.City.Where(a => a.Title == cmb_city.Text).First();
                            address.Street = BD.Street.Where(a => a.Title == cmb_street.Text).First();
                            address.House = tb_house.Text;
                            address.Apart = tb_apart.Text;
                            BD.Adress.Add(address);
                            BD.SaveChanges();
                        }
                    }
                    client.Adress = BD.Adress.Where(a => a.House == tb_house.Text
                    & a.Apart == tb_apart.Text & a.Street.Title == cmb_street.Text & a.City.Title == cmb_city.Text).FirstOrDefault();

                    BD.Client.Add(client);
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
