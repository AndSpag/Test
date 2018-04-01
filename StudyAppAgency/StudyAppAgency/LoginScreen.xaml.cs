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
using MySql.Data.MySqlClient;

namespace StudyAppAgency
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        MySqlConnection conn;
        string connString;
        public LoginScreen()
        {
            InitializeComponent();

        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            connString = "SERVER = 107.180.41.48; PORT=3306 ; DATABASE=StudyApp; UID=asantono28;SslMode=none; PASSWORD=studyApp;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MessageBox.Show("SUCCESS");

                string query = "SELECT COUNT(1) FROM Agency WHERE email=@email AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;

                MessageBox.Show("SUCCESS");
                cmd.Parameters.AddWithValue("@email", AgencyText.Text);
                cmd.Parameters.AddWithValue("@password", PasswordText.Text);


                //MySqlDataReader dataReader = cmd.ExecuteReader();
                MessageBox.Show("SUCCESS");
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("SUCCESS");
                if (count==2)
                {
                    MainWindow mainScreen = new MainWindow();
                    mainScreen.Show();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Agency Name or Password");
                }

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgencyText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
