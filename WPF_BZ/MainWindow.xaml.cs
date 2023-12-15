using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_BZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\WORK\\COde\\Project\\WPF_BZ\\WPF_BZ\\DataBaseSQL.mdf;Integrated Security=True;Connect Timeout=30";

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            AnimateObject();
        }


        private void AnimateObject()
        {
            DoubleAnimation animation_image = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(3))
            };

            ThicknessAnimation thickness_animation_image = new ThicknessAnimation
            {
                From = new Thickness(0, 0, 0, 300),
                To = new Thickness(0, 0, 0, 360),
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };



            head_image.BeginAnimation(Image.OpacityProperty, animation_image);
            head_image.BeginAnimation(Image.MarginProperty, thickness_animation_image);
        } 
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResultCustom messageBoxResultCustom = new MessageBoxResultCustom();
            messageBoxResultCustom.Show();
        }

        private void ButtonRollUp_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow != null && mainWindow.WindowState.Equals(WindowState.Normal))
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM [Autorization] WHERE [Username] = @Username AND [Password] = @Password";
                
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Login or password incorrect");
                }
                else
                {
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Access Done!");
                        }
                        else
                        {
                            MessageBox.Show("Login or password incorrect");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }                                    
            }
        }
    }
}
