using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Catalog
{
    public partial class MenuAdmin : Form
    {
        private SqlConnection conn;

        public MenuAdmin()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True");
        }

        private void showStudents(object sender, EventArgs e)
        {
            this.Controls.Clear();
            ListBox lstStudents = new ListBox();
            lstStudents.Dock = DockStyle.Fill;
            lstStudents.Click += new EventHandler(lstStudents_Click);
            this.Controls.Add(lstStudents);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += new EventHandler(backToMainMenu);
            this.Controls.Add(btnBack);

         
            string query = "SELECT NumarMatricol, Nume, Prenume FROM Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstStudents.Items.Add(new Student
                    {
                        NumarMatricol = reader["NumarMatricol"].ToString(),
                        Nume = reader["Nume"].ToString(),
                        Prenume = reader["Prenume"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstStudents_Click(object sender, EventArgs e)
        {
           
            ListBox lst = (ListBox)sender;
            if (lst.SelectedItem == null) return;
            Student selectedStudent = (Student)lst.SelectedItem;

            
            this.Controls.Clear();
            DataGridView dgvStudentDetails = new DataGridView();
            dgvStudentDetails.Dock = DockStyle.Fill;
            this.Controls.Add(dgvStudentDetails);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += (s, args) => showStudents(null, null);
            this.Controls.Add(btnBack);

            Button btnSave = new Button
            {
                Text = "Save",
                Dock = DockStyle.Top
            };
            btnSave.Click += (s, args) => saveStudentDetails(dgvStudentDetails);
            this.Controls.Add(btnSave);

           
            string query = "SELECT NumarMatricol, Nume, Prenume, CNP, DataInscrierii, CiclulDeInvatamant, MediaLaInscriere FROM Students WHERE NumarMatricol = @NumarMatricol";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NumarMatricol", selectedStudent.NumarMatricol);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvStudentDetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveStudentDetails(DataGridView dgv)
        {
            try
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string query = "UPDATE Students SET Nume = @Nume, Prenume = @Prenume, CNP = @CNP, DataInscrierii = @DataInscrierii, CiclulDeInvatamant = @CiclulDeInvatamant, MediaLaInscriere = @MediaLaInscriere WHERE NumarMatricol = @NumarMatricol";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NumarMatricol", row.Cells["NumarMatricol"].Value);
                    cmd.Parameters.AddWithValue("@Nume", row.Cells["Nume"].Value);
                    cmd.Parameters.AddWithValue("@Prenume", row.Cells["Prenume"].Value);
                    cmd.Parameters.AddWithValue("@CNP", row.Cells["CNP"].Value);
                    cmd.Parameters.AddWithValue("@DataInscrierii", row.Cells["DataInscrierii"].Value);
                    cmd.Parameters.AddWithValue("@CiclulDeInvatamant", row.Cells["CiclulDeInvatamant"].Value);
                    cmd.Parameters.AddWithValue("@MediaLaInscriere", row.Cells["MediaLaInscriere"].Value);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void backToMainMenu(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Button btnStudent = new Button
            {
                Text = "Studenti",
                Name = "btn_student",
                Dock = DockStyle.Top
            };
            btnStudent.Click += new EventHandler(showStudents);
            this.Controls.Add(btnStudent);

            Button btnProf = new Button
            {
                Text = "Profesori",
                Name = "btn_prof",
                Dock = DockStyle.Top
            };
            btnProf.Click += new EventHandler(showProfesori);
            this.Controls.Add(btnProf);

            Button btnDiscipline = new Button
            {
                Text = "Discipline",
                Name = "btn_discipline",
                Dock = DockStyle.Top
            };
            btnDiscipline.Click += new EventHandler(showDiscipline);
            this.Controls.Add(btnDiscipline);

            Button btnCatalog = new Button
            {
                Text = "Catalog",
                Name = "btn_catalog",
                Dock = DockStyle.Top
            };
            btnCatalog.Click += new EventHandler(showCatalog);
            this.Controls.Add(btnCatalog);


        }

        private void showProfesori(object sender, EventArgs e)
        {
         
            this.Controls.Clear();
            ListBox lstProfesori = new ListBox();
            lstProfesori.Dock = DockStyle.Fill;
            lstProfesori.Click += new EventHandler(lstProfesori_Click);
            this.Controls.Add(lstProfesori);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += new EventHandler(backToMainMenu);
            this.Controls.Add(btnBack);

          
            string query = "SELECT MarcaAngajat, Nume, Prenume FROM Profesori";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstProfesori.Items.Add(new Professor
                    {
                        MarcaAngajat = reader["MarcaAngajat"].ToString(),
                        Nume = reader["Nume"].ToString(),
                        Prenume = reader["Prenume"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstProfesori_Click(object sender, EventArgs e)
        {
        
            ListBox lst = (ListBox)sender;
            if (lst.SelectedItem == null) return;
            Professor selectedProfessor = (Professor)lst.SelectedItem;

           
            this.Controls.Clear();
            DataGridView dgvProfessorDetails = new DataGridView();
            dgvProfessorDetails.Dock = DockStyle.Fill;
            this.Controls.Add(dgvProfessorDetails);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += (s, args) => showProfesori(null, null);
            this.Controls.Add(btnBack);

            Button btnSave = new Button
            {
                Text = "Save",
                Dock = DockStyle.Top
            };
            btnSave.Click += (s, args) => saveProfessorDetails(dgvProfessorDetails);
            this.Controls.Add(btnSave);

            
            string query = "SELECT MarcaAngajat, Nume, Prenume, Titlu, Post FROM Profesori WHERE MarcaAngajat = @MarcaAngajat";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MarcaAngajat", selectedProfessor.MarcaAngajat);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProfessorDetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveProfessorDetails(DataGridView dgv)
        {
            try
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string query = "UPDATE Profesori SET Nume = @Nume, Prenume = @Prenume, Titlu = @Titlu, Post = @Post WHERE MarcaAngajat = @MarcaAngajat";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MarcaAngajat", row.Cells["MarcaAngajat"].Value);
                    cmd.Parameters.AddWithValue("@Nume", row.Cells["Nume"].Value);
                    cmd.Parameters.AddWithValue("@Prenume", row.Cells["Prenume"].Value);
                    cmd.Parameters.AddWithValue("@Titlu", row.Cells["Titlu"].Value);
                    cmd.Parameters.AddWithValue("@Post", row.Cells["Post"].Value);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Modificarile au fost salvate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void showDiscipline(object sender, EventArgs e)
        {
            this.Controls.Clear();
            ListBox lstDiscipline = new ListBox();
            lstDiscipline.Dock = DockStyle.Fill;
            lstDiscipline.Click += new EventHandler(lstDiscipline_Click);
            this.Controls.Add(lstDiscipline);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += new EventHandler(backToMainMenu);
            this.Controls.Add(btnBack);

            string query = "SELECT CodulDisciplinei, Nume FROM Discipline";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstDiscipline.Items.Add(new Discipline
                    {
                        CodulDisciplinei = reader["CodulDisciplinei"].ToString(),
                        Nume = reader["Nume"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstDiscipline_Click(object sender, EventArgs e)
        {
          
            ListBox lst = (ListBox)sender;
            if (lst.SelectedItem == null) return;
            Discipline selectedDiscipline = (Discipline)lst.SelectedItem;

       
            this.Controls.Clear();
            DataGridView dgvDisciplineDetails = new DataGridView();
            dgvDisciplineDetails.Dock = DockStyle.Fill;
            this.Controls.Add(dgvDisciplineDetails);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += (s, args) => showDiscipline(null, null);
            this.Controls.Add(btnBack);

            Button btnSave = new Button
            {
                Text = "Save",
                Dock = DockStyle.Top
            };
            btnSave.Click += (s, args) => saveDisciplineDetails(dgvDisciplineDetails);
            this.Controls.Add(btnSave);

        
            string query = "SELECT CodulDisciplinei, Nume, Acronim, Credite FROM Discipline WHERE CodulDisciplinei = @CodulDisciplinei";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CodulDisciplinei", selectedDiscipline.CodulDisciplinei);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDisciplineDetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveDisciplineDetails(DataGridView dgv)
        {
            try
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string query = "UPDATE Discipline SET Nume = @Nume, Acronim = @Acronim, Credite = @Credite WHERE CodulDisciplinei = @CodulDisciplinei";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CodulDisciplinei", row.Cells["CodulDisciplinei"].Value);
                    cmd.Parameters.AddWithValue("@Nume", row.Cells["Nume"].Value);
                    cmd.Parameters.AddWithValue("@Acronim", row.Cells["Acronim"].Value);
                    cmd.Parameters.AddWithValue("@Credite", row.Cells["Credite"].Value);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void showCatalog(object sender, EventArgs e)
        {
            this.Controls.Clear();

            ComboBox cmbCiclulDeInvatamant = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCiclulDeInvatamant.Items.Add("Alege Ciclul de Invatamant");
            cmbCiclulDeInvatamant.Items.AddRange(new string[] { "Licenta", "Masterat" });
            cmbCiclulDeInvatamant.SelectedIndex = 0;
            this.Controls.Add(cmbCiclulDeInvatamant);

            ComboBox cmbProgramulDeStudii = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbProgramulDeStudii.Items.Add("Alege Programul de Studii");
            cmbProgramulDeStudii.Items.AddRange(new string[]
            {
        "Cyber security", "Sisteme electrice avansate", "Sisteme avansate in automatica",
        "Automatica si informatica aplicata", "Electronica aplicata", "Calculatoare",
        "Robotica", "Tehnologia informatiei"
            });
            cmbProgramulDeStudii.SelectedIndex = 0;
            this.Controls.Add(cmbProgramulDeStudii);

            ComboBox cmbAnulDeStudiu = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbAnulDeStudiu.Items.Add("Alege Anul de Studii");
            cmbAnulDeStudiu.Items.AddRange(new string[] { "1", "2", "3", "4" });
            cmbAnulDeStudiu.SelectedIndex = 0;
            this.Controls.Add(cmbAnulDeStudiu);

            Button btnAfiseazaCatalogul = new Button
            {
                Text = "Afiseaza Catalogul",
                Dock = DockStyle.Top
            };
            btnAfiseazaCatalogul.Click += (s, args) => afiseazaCatalogul(cmbCiclulDeInvatamant, cmbProgramulDeStudii, cmbAnulDeStudiu);
            this.Controls.Add(btnAfiseazaCatalogul);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += new EventHandler(backToMainMenu);
            this.Controls.Add(btnBack);
        }


        private void afiseazaCatalogul(ComboBox cmbCiclulDeInvatamant, ComboBox cmbProgramulDeStudii, ComboBox cmbAnulDeStudiu)
        {
            if (cmbCiclulDeInvatamant.SelectedIndex == 0 || cmbProgramulDeStudii.SelectedIndex == 0 || cmbAnulDeStudiu.SelectedIndex == 0)
            {
                MessageBox.Show("Alege toate optiunile necesare");
                return;
            }

            this.Controls.Clear();
            string ciclulDeInvatamant = cmbCiclulDeInvatamant.SelectedItem.ToString();
            string programulDeStudii = cmbProgramulDeStudii.SelectedItem.ToString();
            string anulDeStudiu = cmbAnulDeStudiu.SelectedItem.ToString();

            string tabel = $"CatalogAIA2";

            DataGridView dgvCatalog = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(dgvCatalog);

            Button btnSave = new Button
            {
                Text = "Save",
                Dock = DockStyle.Top
            };
            btnSave.Click += (s, args) => saveCatalogDetails(dgvCatalog, tabel);
            this.Controls.Add(btnSave);

            Button btnBack = new Button
            {
                Text = "Back",
                Dock = DockStyle.Top
            };
            btnBack.Click += new EventHandler(showCatalog);
            this.Controls.Add(btnBack);

            string query = $"SELECT * FROM CatalogAIA2";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCatalog.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void saveCatalogDetails(DataGridView dgv, string tabel)
        {
            try
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    string query = $"UPDATE {tabel} SET " +
               "[Numar matricol] = @NumarMatricol, " +
               "[Nume] = @Nume, " +
               "[Prenume] = @Prenume, " +
               "[Grupa] = @Grupa, " +
               "[SAE] = @SAE, " +
               "[TS2] = @TS2, " +
               "[ASCN] = @ASCN, " +
               "[Engleza] = @Engleza, " +
               "[ED] = @ED, " +
               "[POO] = @POO, " +
               "[CEL] = @CEL, " +
               "[PA] = @PA, " +
               "[MN] = @MN, " +
               "[TS1] = @TS1, " +
               "[MT] = @MT, " +
               "[ROBOTICA] = @ROBOTICA " +
               "WHERE [Numar matricol] = @NumarMatricol";



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
                MessageBox.Show("Modificarile au fost salvate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



    }

    public class Student
    {
        public string NumarMatricol { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public override string ToString()
        {
            return $"{Nume} {Prenume}";
        }
    }

    public class Professor
    {
        public string MarcaAngajat { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public override string ToString()
        {
            return $"{Nume} {Prenume}";
        }
    }

    public class Discipline
    {
        public string CodulDisciplinei { get; set; }
        public string Nume { get; set; }

        public override string ToString()
        {
            return $"{Nume}";
        }
    }
}
