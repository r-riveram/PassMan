using System.Data;
using System.Data.SQLite;

namespace PassMan
{
    public partial class MainForm : Form
    {
        private void LoadPasswords()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "SELECT Id, Title, Username, EncryptedPassword, Notes FROM Passwords";

                using (var command = new SQLiteCommand(sql, connection))
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvPasswords.DataSource = dataTable;
                }
            }
            if (dgvPasswords.Columns.Contains("Id"))
                dgvPasswords.Columns["Id"].Visible = false;
        }

        private void AddPassword(string title, string username, string password, string notes)
        {
            var newPassword = new Password
            {
                Title = title,
                Username = username,
                EncryptedPassword = password,
                Notes = notes,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            DatabaseHelper.InsertPassword(newPassword);
            LoadPasswords();
        }

        private void EditPassword(int id, string title, string username, string password, string notes)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = @"
                    UPDATE Passwords 
                    SET Title = @Title, 
                        Username = @Username, 
                        EncryptedPassword = @Password, 
                        Notes = @Notes,
                        ModifiedDate = @ModifiedDate
                    WHERE Id = @Id";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Notes", notes);
                    command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            LoadPasswords();
        }

        private void DeletePassword(int id)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar esta contraseña?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string sql = "DELETE FROM Passwords WHERE Id = @Id";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
                LoadPasswords();
            }
        }

        private void InitializeFormComponents()
        {
            this.Text = "Password Manager";
            dgvPasswords.Dock = DockStyle.Fill;
            dgvPasswords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public MainForm()
        {
            InitializeComponent();
            InitializeFormComponents();
            DatabaseHelper.InitializeDatabase();
            LoadPasswords();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Newpass_Click(object sender, EventArgs e)
        {
            using (var form = new PasswordForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var password = form.GetPassword();
                    AddPassword(password.Title, password.Username, password.EncryptedPassword, password.Notes);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPasswords.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvPasswords.CurrentRow.Cells["Id"].Value);
                string title = dgvPasswords.CurrentRow.Cells["Title"].Value.ToString();
                string username = dgvPasswords.CurrentRow.Cells["Username"].Value.ToString();
                string password = dgvPasswords.CurrentRow.Cells["EncryptedPassword"].Value.ToString();
                string notes = dgvPasswords.CurrentRow.Cells["Notes"].Value.ToString();

                var currentPassword = new Password
                {
                    Id = id,
                    Title = title,
                    Username = username,
                    EncryptedPassword = password,
                    Notes = notes
                };

                using (var form = new PasswordForm(currentPassword))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedPassword = form.GetPassword();
                        EditPassword(id, updatedPassword.Title, updatedPassword.Username,
                                   updatedPassword.EncryptedPassword, updatedPassword.Notes);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvPasswords.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvPasswords.SelectedRows[0].Cells["Id"].Value);
                DeletePassword(id);
            }
            else
            {
                MessageBox.Show(
                    "Por favor, seleccione una contraseña para eliminar.",
                    "Ninguna contraseña seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Btn_newCategory_Click(object sender, EventArgs e)
        {
            using (var form = new CategoryForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //LoadCategories();
                }
            }
        }
    }
}
