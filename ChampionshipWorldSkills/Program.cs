using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChampionshipWorldSkills.DataSet;

namespace ChampionshipWorldSkills
{
    static class Program
    {
        public static ApplicationContext Context;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DataBaseConnection.Connecting();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к базе данных: {ex.Message}");
                return;
            }

            Context = new ApplicationContext(new FormLogin());
            Application.Run(Context);
        }

        public static void SetMainForm(Form form)
        {
            Form current = Context.MainForm;
            form.Show();
            Context.MainForm = form;
            current.Dispose();
        }
    }
}
