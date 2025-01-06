using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassMan
{
    public partial class PasswordForm : Form
    {
        private int? passwordId = null;
        private Password currentPassword;
        private TextBox txtTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtNotes;
        private CheckBox chkShowPassword;
        private ComboBox cmbCategory;

        public PasswordForm(Password password = null)
        {
            SetupComponents();
            if (password != null)
            {
                passwordId = password.Id;
                currentPassword = password;
                this.Text = "Editar Contraseña";
                LoadPasswordData();
            }
            else
            {
                this.Text = "Nueva Contraseña";
            }
        }

        private void SetupComponents()
        {
            // Form configuration
            this.Size = new Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Labels
            Label lblTitle = new Label { Text = "Título:", Location = new Point(20, 20) };
            Label lblUsername = new Label { Text = "Usuario:", Location = new Point(20, 60) };
            Label lblPassword = new Label { Text = "Contraseña:", Location = new Point(20, 100) };
            Label lblNotes = new Label { Text = "Notas:", Location = new Point(20, 140) };
            Label lblCategory = new Label { Text = "Categoría:", Location = new Point(20, 180) };

            //ComboBox
            cmbCategory = new ComboBox
            {
                Location = new Point(120, 180),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "Name",
                ValueMember = "Id"
            };


            // TextBoxes
            txtTitle = new TextBox { Location = new Point(120, 20), Width = 200 };
            txtUsername = new TextBox { Location = new Point(120, 60), Width = 200 };
            txtPassword = new TextBox { Location = new Point(120, 100), Width = 200, UseSystemPasswordChar = true };
            txtNotes = new TextBox { Location = new Point(120, 140), Width = 200, Height = 60, Multiline = true };

            // Show Password CheckBox
            chkShowPassword = new CheckBox
            {
                Text = "Mostrar contraseña",
                Location = new Point(120, 180),
                AutoSize = true
            };
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;

            // Buttons
            Button btnSave = new Button
            {
                Text = "Guardar",
                Location = new Point(120, 220),
                DialogResult = DialogResult.OK
            };
            btnSave.Click += BtnSave_Click;

            Button btnCancel = new Button
            {
                Text = "Cancelar",
                Location = new Point(220, 220),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, lblPassword, lblNotes,
                txtTitle, txtUsername, txtPassword, txtNotes,
                chkShowPassword, btnSave, btnCancel
            });
        }

        private void LoadPasswordData()
        {
            txtTitle.Text = currentPassword.Title;
            txtUsername.Text = currentPassword.Username;
            txtPassword.Text = currentPassword.EncryptedPassword;
            txtNotes.Text = currentPassword.Notes;
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("El título es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentPassword = new Password
            {
                Id = passwordId ?? 0,
                Title = txtTitle.Text,
                Username = txtUsername.Text,
                EncryptedPassword = txtPassword.Text,
                Notes = txtNotes.Text,
                CreatedDate = passwordId.HasValue ? currentPassword?.CreatedDate ?? DateTime.Now : DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        public Password GetPassword()
        {
            return currentPassword;
        }
    }
}