using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Opiskelijat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            LoadStudentGroups();
        }

        private void LoadStudentData()
        {
            string connectionString =
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=OpiskelijatDB;" +
                "Trusted_Connection=True;";
            string query = "SELECT id, etunimi, sukunimi FROM opiskelija";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadStudentGroups()
        {
            string connectionString =
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=OpiskelijatDB;" +
                "Trusted_Connection=True;";
            string query = "SELECT id, ryhmannimi FROM opiskelijaryhma";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable groupTable = new DataTable();
                    adapter.Fill(groupTable);

                    comboBox1.DataSource = groupTable;
                    comboBox1.DisplayMember = "ryhmannimi";
                    comboBox1.ValueMember = "id";
                    comboBox1.SelectedIndex = 0;

                    comboBox2.DataSource = groupTable;
                    comboBox2.DisplayMember = "ryhmannimi";
                    comboBox2.ValueMember = "id";
                    comboBox2.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddStudent()
        {
            string connectionString =
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=OpiskelijatDB;" +
                "Trusted_Connection=True;";
            string query = "INSERT INTO opiskelija (etunimi, sukunimi, ryhma_id) VALUES (@etunimi, @sukunimi, @ryhma_id)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@etunimi", textBoxFirstName.Text);
                        cmd.Parameters.AddWithValue("@sukunimi", textBoxLastName.Text);
                        cmd.Parameters.AddWithValue("@ryhma_id", comboBox2.SelectedValue);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student added successfully.");
                            LoadStudentData(); // Refresh the data grid view
                        }
                        else
                        {
                            MessageBox.Show("Failed to add student.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent();
            LoadStudentData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveStudent();
        }

        private void numericUpDown1DeleteStudent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RemoveStudent()
        {
            string connectionString =
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=OpiskelijatDB;" +
                "Trusted_Connection=True;";
            string query = "DELETE FROM opiskelija WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", numericUpDown1DeleteStudent.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student removed successfully.");
                            LoadStudentData(); // Refresh the data grid view
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove student.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            LoadStudentData();
        }
    }
}
