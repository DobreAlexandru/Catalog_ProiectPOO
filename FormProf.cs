using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Catalog
{
    public partial class FormProf : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True");
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter;
        private DataGridView dataGridView1;

        public FormProf()
        {
            InitializeComponent();
            LoadData();
        }

        private void FormProf_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadData()
        {
            string query = @"
                SELECT * FROM CatalogAIA2";

            SqlCommand cmd = new SqlCommand(query, conn);


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                foreach (DataGridViewRow row in dataGridViewGrades.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        string query = @"UPDATE CatalogAIA2 SET
                                    Nume = @Nume,
                                    Prenume = @Prenume,
                                    Grupa = @Grupa,
                                    SAE = @SAE,
                                    TS2 = @TS2,
                                    ASCN = @ASCN,
                                    Engleza = @Engleza,
                                    ED = @ED,
                                    POO = @POO,
                                    CEL = @CEL,
                                    PA = @PA,
                                    MN = @MN,
                                    TS1 = @TS1,
                                    MT = @MT,
                                    ROBOTICA = @ROBOTICA
                                WHERE [Numar matricol] = @NumarMatricol";

                        SqlCommand cmd = new SqlCommand(query, conn);


                        cmd.Parameters.AddWithValue("@NumarMatricol", row.Cells["Numar matricol"].Value);
                        cmd.Parameters.AddWithValue("@Nume", row.Cells["Nume"].Value);
                        cmd.Parameters.AddWithValue("@Prenume", row.Cells["Prenume"].Value);
                        cmd.Parameters.AddWithValue("@Grupa", row.Cells["Grupa"].Value);
                        cmd.Parameters.AddWithValue("@SAE", row.Cells["SAE"].Value);
                        cmd.Parameters.AddWithValue("@TS2", row.Cells["TS2"].Value);
                        cmd.Parameters.AddWithValue("@ASCN", row.Cells["ASCN"].Value);
                        cmd.Parameters.AddWithValue("@Engleza", row.Cells["Engleza"].Value);
                        cmd.Parameters.AddWithValue("@ED", row.Cells["ED"].Value);
                        cmd.Parameters.AddWithValue("@POO", row.Cells["POO"].Value);
                        cmd.Parameters.AddWithValue("@CEL", row.Cells["CEL"].Value);
                        cmd.Parameters.AddWithValue("@PA", row.Cells["PA"].Value);
                        cmd.Parameters.AddWithValue("@MN", row.Cells["MN"].Value);
                        cmd.Parameters.AddWithValue("@TS1", row.Cells["TS1"].Value);
                        cmd.Parameters.AddWithValue("@MT", row.Cells["MT"].Value);
                        cmd.Parameters.AddWithValue("@ROBOTICA", row.Cells["ROBOTICA"].Value);


                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Modificarile au fost salvate");
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formC = new Form1();
            formC.Show();
            this.Hide();
        }
    }
}
