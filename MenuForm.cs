using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Catalog
{
    public partial class MenuForm : Form
    {
        private string csvFilePath = "students.csv";

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                DataTable databaseData = new DataTable();

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT * FROM Students";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        databaseData.Load(reader);
                    }
                }

                dataGridViewStudents.DataSource = databaseData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from database: " + ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCsvData();
            SaveToDatabase();
        }

        private void SaveCsvData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(csvFilePath))
                {
                    for (int i = 0; i < dataGridViewStudents.Columns.Count; i++)
                    {
                        sw.Write(dataGridViewStudents.Columns[i].HeaderText);
                        if (i < dataGridViewStudents.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();

                    for (int i = 0; i < dataGridViewStudents.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridViewStudents.Columns.Count; j++)
                        {
                            sw.Write(dataGridViewStudents.Rows[i].Cells[j].Value);
                            if (j < dataGridViewStudents.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Data saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving CSV file: " + ex.Message);
            }
        }

        private void SaveToDatabase()
        {
            try
            {
                DataTable csvData = (DataTable)dataGridViewStudents.DataSource;

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True"))
                {
                    conn.Open();

                    foreach (DataRow row in csvData.Rows)
                    {
                        string query = "IF EXISTS (SELECT 1 FROM Students WHERE NumeStudent = @NumeStudent) " +
                                       "BEGIN " +
                                       "UPDATE Students SET NumeStudent = @NumeStudent WHERE NumeStudent = @NumeStudent " +
                                       "END " +
                                       "ELSE " +
                                       "BEGIN " +
                                       "INSERT INTO Students (NumeStudent) VALUES (@NumeStudent) " +
                                       "END";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NumeStudent", row["NumeStudent"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Database updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // În evenimentul CellClick al DataGridView din MenuForm
        // În evenimentul CellClick al DataGridView din MenuForm
        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Asigură-te că nu este un indice invalid
            {
                string studentName = dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString(); // Ia numele studentului din celula selectată

                Form2 form2 = new Form2(studentName); // Creează o instanță a Form2 și trimite numele studentului
                form2.ShowDialog(); // Afișează Form2
            }
        }





    }
}
