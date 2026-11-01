using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RolesUsers.ADO_NET;

namespace RolesUsers.Forms
{
    public class FormAutorization : Form
    {
        public static Users Enter_User;
        private readonly TextBox textBoxLogin = new TextBox { Name = "textBoxLogin", Width = 230 };
        private readonly TextBox textBoxPassword = new TextBox { Name = "textBoxPassword", Width = 230, UseSystemPasswordChar = true };
        private readonly Button buttonEnter = new Button { Name = "buttonEnter", Text = "Войти", Width = 230, Height = 35 };

        public FormAutorization()
        {
            Text = "Авторизация"; StartPosition = FormStartPosition.CenterScreen; ClientSize = new Size(360, 245); FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;
            var title = new Label { Text = "Авторизация", Font = new Font(Font.FontFamily, 16, FontStyle.Bold), AutoSize = true, Location = new Point(112, 22) };
            var login = new Label { Text = "Логин", AutoSize = true };
            var password = new Label { Text = "Пароль", AutoSize = true };
            var panel = new TableLayoutPanel { Location = new Point(62, 62), Size = new Size(240, 150), ColumnCount = 1, RowCount = 6 };
            panel.Controls.Add(login, 0, 0); panel.Controls.Add(textBoxLogin, 0, 1); panel.Controls.Add(password, 0, 2); panel.Controls.Add(textBoxPassword, 0, 3); panel.Controls.Add(buttonEnter, 0, 5);
            Controls.Add(title); Controls.Add(panel);
            buttonEnter.Click += buttonEnter_Click;
            AcceptButton = buttonEnter;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                using (var model = new Model1())
                {
                    Enter_User = model.Users.FirstOrDefault(x => x.Login == textBoxLogin.Text && x.Password == textBoxPassword.Text);
                }
                if (Enter_User == null) { MessageBox.Show("Неверный логин или пароль.", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                Form roleForm;
                switch (Enter_User.RoleID)
                {
                    case 1: roleForm = new FormManager(); break;
                    case 2: roleForm = new FormSeller(); break;
                    case 3: roleForm = new FormDirector(); break;
                    default: throw new InvalidOperationException("Роль пользователя не найдена.");
                }
                Hide(); roleForm.ShowDialog(this); Show();
            }
            catch (Exception ex) { MessageBox.Show("Не удалось выполнить вход: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
