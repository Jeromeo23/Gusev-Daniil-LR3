using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RolesUsers.ADO_NET;

namespace RolesUsers.Forms
{
    public class FormParent : Form
    {
        protected FormParent(string caption)
        {
            Text = caption; StartPosition = FormStartPosition.CenterParent; ClientSize = new Size(440, 280); FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;
            var title = new Label { Text = caption, Font = new Font(Font.FontFamily, 16, FontStyle.Bold), AutoSize = true, Location = new Point(24, 22) };
            var labelName = new Label { Name = "labelNames", AutoSize = true, Location = new Point(24, 75), Font = new Font(Font.FontFamily, 11) };
            var labelRole = new Label { Name = "labelRole", AutoSize = true, Location = new Point(24, 108), Font = new Font(Font.FontFamily, 11) };
            var pictureBox = new PictureBox { Name = "pictureBox1", Location = new Point(270, 62), Size = new Size(130, 130), SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle };
            var buttonBack = new Button { Name = "buttonBack", Text = "Назад", Location = new Point(24, 205), Size = new Size(110, 35) };
            Controls.AddRange(new Control[] { title, labelName, labelRole, pictureBox, buttonBack }); buttonBack.Click += (s, e) => Close();
            Load += (s, e) => FillUserData(labelName, labelRole, pictureBox);
        }

        private static void FillUserData(Label labelName, Label labelRole, PictureBox pictureBox)
        {
            var user = FormAutorization.Enter_User;
            if (user == null) return;
            labelName.Text = "Пользователь: " + user.First_Name + " " + user.Second_Name;
            using (var model = new Model1()) labelRole.Text = "Роль: " + model.Roles.Where(x => x.ID == user.RoleID).Select(x => x.Name).FirstOrDefault();
            var imagePath = Path.Combine(Application.StartupPath, "Photo", user.Pictures ?? "");
            if (File.Exists(imagePath)) pictureBox.Image = Image.FromFile(imagePath);
        }
    }
}
