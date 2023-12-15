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

namespace WPF_BZ
{
    /// <summary>
    /// Логика взаимодействия для MessageBoxResultCustom.xaml
    /// </summary>
    public partial class MessageBoxResultCustom : Window
    {
        public MessageBoxResultCustom()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void Yes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    
}
