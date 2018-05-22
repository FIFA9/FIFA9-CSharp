using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FifaDBtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillcombobox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=comboboxnew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string sql = "select * from comboboxnew";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(1);
                    comboBox1.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=comboboxnew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string sql = "select * from comboboxnew";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string id = myreader.GetInt32(0).ToString();
                    string HomeTeam = myreader.GetString(1);
                    string AwayTeam = myreader.GetString(2);
                    string PredHome = myreader.GetInt32(3).ToString();
                    string PredAway = myreader.GetInt32(4).ToString();
                    txtHTeam.Text = HomeTeam;
                    txtATeam.Text = AwayTeam;
                    txtPrediction1.Text = PredHome;
                    txtPrediction2.Text = PredAway;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
