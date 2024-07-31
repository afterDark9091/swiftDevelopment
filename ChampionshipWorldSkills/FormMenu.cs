using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChampionshipWorldSkills
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            SetGreetingsToLabel2();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AuthorizationService.LogoutUser();
                Program.SetMainForm(new FormLogin());
            }
        }

        protected void SetGreetingsToLabel2()
        {
            if (AuthorizationService.LoginedUser != null)
            {
                label2.Text = $"{TimeOfDay()}, {AuthorizationService.LoginedUser.Fio}";
            }
        }

        private string TimeOfDay()
        {
            double hours = DateTime.Now.TimeOfDay.TotalHours;
            string message;

            if (hours >= 5 && hours < 10)
            {
                message = "Доброе утро";
            }
            else if (hours >= 10 && hours < 17)
            {
                message = "Добрый день";
            }
            else if (hours >= 17 && hours < 23)
            {
                message = "Добрый вечер";
            }
            else
            {
                message = "Доброй ночи";
            }

            return message;
        }
    }
}
