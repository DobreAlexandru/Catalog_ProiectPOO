using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Catalog
{
    public partial class Form2 : Form
    {
        private string csvFilePath = "note.csv";
        public Form2(string studentName)
        {
            InitializeComponent();

            try
            {
                this.studentName = studentName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Form2 constructor: " + ex.Message);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void LoadNotes()
        {
            try
            {
                // Conectarea la baza de date și interogarea pentru a obține notele studentului
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "SELECT Note FROM Detalii WHERE Nume = @Nume";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nume", studentName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Afișarea datelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading notes: " + ex.Message);
            }
        }

        private void aa()
        {
            try
            {
                // Obține nota introdusă în DataGridView
                string note = dataGridView1.Rows[0].Cells[0].Value.ToString();

                // Actualizează fișierul CSV cu noua notă
                
                using (StreamWriter sw = new StreamWriter(csvFilePath))
                {
                    sw.WriteLine("Nume,Note");
                    sw.WriteLine($"{studentName},{note}");
                }

                // Actualizează baza de date cu noua notă
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "IF EXISTS (SELECT 1 FROM Detalii WHERE Nume = @Nume) " +
                                   "BEGIN " +
                                   "UPDATE Detalii SET Note = @Note WHERE Nume = @Nume " +
                                   "END " +
                                   "ELSE " +
                                   "BEGIN " +
                                   "INSERT INTO Detalii (Nume, Note) VALUES (@Nume, @Note) " +
                                   "END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nume", studentName);
                        cmd.Parameters.AddWithValue("@Note", note);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Note saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving note: " + ex.Message);
            }
        }
        private void SaveNote(object sender, EventArgs e)
        {
            aa();
        }
    }
}
