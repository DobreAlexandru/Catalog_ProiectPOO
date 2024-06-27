using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Catalog
{
    public partial class FormStudent : Form
    {
        private string username;

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True");

        public FormStudent(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadStudentGrades(username);
        }

        private void LoadStudentGrades(string username)
        {
            string query = @"
                SELECT [Numar Matricol], Nume, Prenume, Grupa, SAE, TS2, ASCN, Engleza, ED, POO, CEL, PA, MN, TS1, MT, ROBOTICA
                FROM CatalogAIA2
                WHERE Nume = @nume AND Prenume = @prenume";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nume", username.Split(' ')[0]);
            cmd.Parameters.AddWithValue("@prenume", username.Split(' ')[1]);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                da.Fill(dt);


                dataGridViewGrades.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Form1 formC = new Form1();
            formC.Show();
            this.Hide();
        }
    }
}
