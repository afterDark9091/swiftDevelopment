using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChampionshipWorldSkills.DataSet;

namespace ChampionshipWorldSkills
{
    public partial class FormLogin : FormDialog
    {
        public FormLogin()
        {
            InitializeComponent();

            if (Properties.Settings.Default.RememberedUserLogin.Length != 0)
            {
                textBoxLogin.Text = Properties.Settings.Default.RememberedUserLogin;
                textBoxPassword.Text = Properties.Settings.Default.RememberedUserPassword;
                checkBoxRememberMe.Checked = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AuthorizationService.LoginUser(textBoxLogin.Text, textBoxPassword.Text);
            }
            catch (RecordNotFoundException ex)
            {
                labelError.Text = ex.Message;
                return;
            }

            if (checkBoxRememberMe.Checked)
            {
                Properties.Settings.Default.RememberedUserLogin = textBoxLogin.Text;
                Properties.Settings.Default.RememberedUserPassword = textBoxPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberedUserLogin = "";
                Properties.Settings.Default.RememberedUserPassword = "";
                Properties.Settings.Default.Save();
            }
            
            switch (AuthorizationService.LoginedUser.Role)
            {
                case Role.Organizer: Program.SetMainForm(new FormOrganizerMenu()); break;
                default: MessageBox.Show("Роль этого пользователя еще не поддерживается", "Сообщение"); break;
            }
        }
    }
}
