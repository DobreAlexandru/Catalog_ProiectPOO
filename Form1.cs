using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Catalog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEGT18M\SQLEXPRESS02;Initial Catalog=Login;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            tip_user.SelectedIndex = 3;
        }

        private void login(object sender, EventArgs e)
        {
            String username, password;
            username = txt_user.Text;
            password = txt_pass.Text;
            
            String role = tip_user.SelectedItem.ToString();
            String query = "";
            try
            {
                if (role == "Student")
                {
                    query = "SELECT * FROM StudentPass WHERE Username = '" + txt_user.Text + "' AND Password = '" + txt_pass.Text + "'";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        username = txt_user.Text;
                        password = txt_pass.Text;
                        FormStudent formB = new FormStudent(username);
                        formB.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials");
                    }
                }
                else if (role == "Administrator" || role == "Secretar")
                {
                    query = "SELECT * FROM AdministratorPass WHERE Username = '" + txt_user.Text + "' AND Password = '" + txt_pass.Text + "'";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        username = txt_user.Text;
                        password = txt_pass.Text;
                        MenuAdmin formA = new MenuAdmin();
                        formA.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Parola gresita");
                    }
                }
                else if (role == "Profesor")
                {
                    query = "SELECT * FROM ProfesorPass WHERE Username = '" + txt_user.Text + "' AND Password = '" + txt_pass.Text + "'";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        username = txt_user.Text;
                        password = txt_pass.Text;
                        FormProf formC = new FormProf();
                        formC.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Parola gresita");
                    }
                }
                else
                {
                    MessageBox.Show("Parola gresita");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
