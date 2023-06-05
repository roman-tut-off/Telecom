using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TutoffCursach
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    static public class CurrentEmploy
    {
        public static int EmplID { get; set; } = 0;
        public static bool IsAdmin { get; set; } = true;
        public static string UserName { get; set; } = string.Empty;

    }
}
