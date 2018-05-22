using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectFifaV2
{
    public partial class frmPlayer : Form
    {
        private Form frmRanking;
        private DatabaseHandler dbh;
        private string userName;
        int User_id;

        List<TextBox> txtBoxList;

        public frmPlayer(Form frm, string un, int user_id)
        {
            this.ControlBox = false;
            frmRanking = frm;
            dbh = new DatabaseHandler();
            if (user_id != null)
            {
                this.User_id = user_id;
            }

            InitializeComponent();
            fillcombobox();
            if (DisableEditButton())
            {
                btnEditPrediction.Enabled = false;
            }
            ShowResults();
            ShowScoreCard();
            this.Text = "Welcome " + un;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnShowRanking_Click(object sender, EventArgs e)
        {
            frmRanking.Show();
        }

        private void btnClearPrediction_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear your prediction?", "Clear Predictions", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                // Clear predections
                // Update DB
            }
        }

        private bool DisableEditButton()
        {
            bool hasPassed;
            //This is the deadline for filling in the predictions
            DateTime deadline = new DateTime(2014, 06, 12);
            DateTime curTime = DateTime.Now;
            int result = DateTime.Compare(deadline, curTime);

            if (result < 0)
            {
                hasPassed = true;
            }
            else
            {
                hasPassed = false;
            }

            return hasPassed;
        }

        private void ShowResults()
        {
            dbh.TestConnection();
            dbh.OpenConnectionToDB();

            DataTable hometable = dbh.FillDT("SELECT tblTeams.TeamName, tblGames.HomeTeamScore FROM tblGames INNER JOIN tblTeams ON tblGames.HomeTeam = tblTeams.Team_ID");
            DataTable awayTable = dbh.FillDT("SELECT tblTeams.TeamName, tblGames.AwayTeamScore FROM tblGames INNER JOIN tblTeams ON tblGames.AwayTeam = tblTeams.Team_ID");

            dbh.CloseConnectionToDB();

            for (int i = 0; i < hometable.Rows.Count; i++)
            {
                DataRow dataRowHome = hometable.Rows[i];
                DataRow dataRowAway = awayTable.Rows[i];
                ListViewItem lstItem = new ListViewItem(dataRowHome["TeamName"].ToString());
                lstItem.SubItems.Add(dataRowHome["HomeTeamScore"].ToString());
                lstItem.SubItems.Add(dataRowAway["AwayTeamScore"].ToString());
                lstItem.SubItems.Add(dataRowAway["TeamName"].ToString());
                lvOverview.Items.Add(lstItem);
            }
        }

        private void ShowScoreCard()
        {
            dbh.TestConnection();
            dbh.OpenConnectionToDB();

            DataTable hometable = dbh.FillDT("SELECT tblTeams.TeamName FROM tblGames INNER JOIN tblTeams ON tblGames.HomeTeam = tblTeams.Team_ID");
            DataTable awayTable = dbh.FillDT("SELECT tblTeams.TeamName FROM tblGames INNER JOIN tblTeams ON tblGames.AwayTeam = tblTeams.Team_ID");

            dbh.CloseConnectionToDB();

            for (int i = 0; i < hometable.Rows.Count; i++)
            {
                DataRow dataRowHome = hometable.Rows[i];
                DataRow dataRowAway = awayTable.Rows[i];
                
                Label lblHomeTeam = new Label();
                Label lblAwayTeam = new Label();
                TextBox txtHomePred = new TextBox();
                TextBox txtAwayPred = new TextBox();

                lblHomeTeam.TextAlign = ContentAlignment.BottomRight;
                lblHomeTeam.Text = dataRowHome["TeamName"].ToString();
                lblHomeTeam.Location = new Point(15, txtHomePred.Bottom + (i * 30));
                lblHomeTeam.AutoSize = true;

                txtHomePred.Text = "0";
                txtHomePred.Location = new Point(lblHomeTeam.Width, lblHomeTeam.Top - 3);
                txtHomePred.Width = 40;

                txtAwayPred.Text = "0";
                txtAwayPred.Location = new Point(txtHomePred.Width + lblHomeTeam.Width, txtHomePred.Top);
                txtAwayPred.Width = 40;

                lblAwayTeam.Text = dataRowAway["TeamName"].ToString();
                lblAwayTeam.Location = new Point(txtHomePred.Width + lblHomeTeam.Width + txtAwayPred.Width, txtHomePred.Top + 3);
                lblAwayTeam.AutoSize = true;

                ListViewItem lstItem = new ListViewItem(dataRowHome["TeamName"].ToString());
                //lstItem.SubItems.Add(dataRowHome["HomeTeamScore"].ToString());
                //lstItem.SubItems.Add(dataRowAway["AwayTeamScore"].ToString());
                //lstItem.SubItems.Add(dataRowAway["TeamName"].ToString());
                //lvOverview.Items.Add(lstItem);
            }
        }

        internal void GetUsername(string un)
        {
            userName = un;
        }

        public void fillcombobox()
        {
            string sql = "SELECT * FROM [TblGames]";
            SqlCommand cmd = new SqlCommand(sql, dbh.GetCon());
            SqlDataReader myreader;
            try
            {
                dbh.GetCon().Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetInt32(0).ToString();
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

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql = "select * from [TblGames] where Game_id = '" + comboBox1.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, dbh.GetCon());
            SqlDataReader myreader;
            SqlCommand cmdHome = null;
            SqlCommand cmdAway = null;
            try
            {
                dbh.GetCon().Close();
                dbh.GetCon().Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string homeTeamQuery = "SELECT TeamName FROM [TblTeams] WHERE team_id = " + myreader.GetInt32(1).ToString();
                    string awayTeamQuery = "SELECT TeamName FROM [TblTeams] WHERE team_id = " + myreader.GetInt32(2).ToString();
                    cmdHome = new SqlCommand(homeTeamQuery, dbh.GetCon());
                    cmdAway = new SqlCommand(awayTeamQuery, dbh.GetCon());
                }
                dbh.GetCon().Close();
                dbh.GetCon().Open();
                textBox1.Text = (string)cmdHome.ExecuteScalar();
                textBox2.Text = (string)cmdAway.ExecuteScalar();
                dbh.GetCon().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddPrediction_Click(object sender, EventArgs e)
        {
            int Game_id = Int32.Parse(comboBox1.Text);
            int PredictedHomeScore = Convert.ToInt32(numericUpDown1.Value);
            int PredictedAwayScore = Convert.ToInt32(numericUpDown2.Value);
            string sql = "INSERT INTO [TblPredictions] (User_id, Game_id, PredictedHomeScore, PredictedAwayScore) VALUES('" + User_id + "','" + Game_id + "', '" + PredictedHomeScore + "', '" + PredictedAwayScore + "');";
            SqlCommand cmd = new SqlCommand(sql, dbh.GetCon());
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [TblPredictions] (User_id, Game_id, PredictedHomeScore, PredictedAwayScore) VALUES('" + User_id + "','" + Game_id + "', '" + PredictedHomeScore + "', '" + PredictedAwayScore + "');";
            cmd.CommandType = CommandType.Text;

            dbh.GetCon().Close();
            dbh.GetCon().Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            dbh.GetCon().Close();
        }
    }
}
