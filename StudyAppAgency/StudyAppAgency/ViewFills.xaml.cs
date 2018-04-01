using MySql.Data.MySqlClient;
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
using System.Data;
namespace StudyAppAgency
{
    /// <summary>
    /// Interaction logic for ViewFills.xaml
    /// </summary>
    public partial class ViewFills : Window
    {
        MySqlConnection conn;
        string connString;
        public ViewFills()
        {
            InitializeComponent();

            connString = "SERVER = 107.180.41.48; PORT=3306 ; DATABASE=StudyApp; UID=asantono28;SslMode=none; PASSWORD=studyApp;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MessageBox.Show("SUCCESS");

                string query = "SELECT * FROM Fill_ins";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;


                MySqlDataAdapter adaptData = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Fill_ins");
                adaptData.Fill(dt);

                fill_ins.ItemsSource = dt.DefaultView;
                adaptData.Update(dt);


                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
