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
    public partial class FormOrganizerMenu : FormMenu
    {
        private DataTable _champs;
        private DataTable _chiefExperts;
        private DataTable _skills;

        private bool _championshipMenuInAddMode = true;
        private Championship _champ;

        public FormOrganizerMenu()
        {
            InitializeComponent();
            tabControl.TabPages.Clear();
            FillComboBoxChampName();
            FillComboBoxMainExpert();
            FillComboBoxCompetitions();
        }

        private void buttonMenuChampionship_Click(object sender, EventArgs e)
        {
            OpenChampMenuToAdd();
        }

        private void buttonAddChamp_Click(object sender, EventArgs e)
        {
            SetModeAddChamp();
        }

        private void buttonChangeChamp_Click(object sender, EventArgs e)
        {
            SetModeEditChamp();
        }

        private void buttonMenuChampSettings_Click(object sender, EventArgs e)
        {
            OpenChampMenuToEdit();
        }

        private void buttonMenuExpertMenegement_Click(object sender, EventArgs e)
        {
            OpenExpertMenu();
        }

        private void buttonMenuProtocols_Click(object sender, EventArgs e)
        {
            OpenProtocolsMenu();
        }

        private void SetModeAddChamp()
        {
            _championshipMenuInAddMode = true;
            comboBoxChampName.Enabled = false;
            buttonAddChamp.BackColor = Properties.Settings.Default.Green;
            buttonChangeChamp.BackColor = Properties.Settings.Default.Blue;
        }

        private void SetModeEditChamp()
        {
            _championshipMenuInAddMode = false;
            comboBoxChampName.Enabled = true;
            buttonAddChamp.BackColor = Properties.Settings.Default.Blue;
            buttonChangeChamp.BackColor = Properties.Settings.Default.Green;

            LoadSelectedChamp();
        }

        private void OpenChampMenuToAdd()
        {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabAddChampionship);

            buttonMenuChampionship.BackColor = Properties.Settings.Default.Green;
            buttonMenuChampSettings.BackColor = Properties.Settings.Default.Blue;
            buttonMenuExpertMenegement.BackColor = Properties.Settings.Default.Blue;
            buttonMenuProtocols.BackColor = Properties.Settings.Default.Blue;

            SetModeAddChamp();
        }

        private void OpenChampMenuToEdit()
        {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabAddChampionship);

            buttonMenuChampionship.BackColor = Properties.Settings.Default.Blue;
            buttonMenuChampSettings.BackColor = Properties.Settings.Default.Green;
            buttonMenuExpertMenegement.BackColor = Properties.Settings.Default.Blue;
            buttonMenuProtocols.BackColor = Properties.Settings.Default.Blue;

            SetModeEditChamp();
        }

        private void OpenExpertMenu()
        {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabExpertMenegement);

            buttonMenuChampionship.BackColor = Properties.Settings.Default.Blue;
            buttonMenuChampSettings.BackColor = Properties.Settings.Default.Blue;
            buttonMenuExpertMenegement.BackColor = Properties.Settings.Default.Green;
            buttonMenuProtocols.BackColor = Properties.Settings.Default.Blue;
        }

        private void OpenProtocolsMenu()
        {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabProtocols);

            buttonMenuChampionship.BackColor = Properties.Settings.Default.Blue;
            buttonMenuChampSettings.BackColor = Properties.Settings.Default.Blue;
            buttonMenuExpertMenegement.BackColor = Properties.Settings.Default.Blue;
            buttonMenuProtocols.BackColor = Properties.Settings.Default.Green;
        }

        private void FillComboBoxMainExpert()
        {
            _chiefExperts = DataSet.User.GetChiefExpertUsers();
            comboBoxMainExpert.DataSource = _chiefExperts;
            comboBoxMainExpert.DisplayMember = "fio";
            comboBoxMainExpert.ValueMember = "id";
        }

        private void FillComboBoxChampName()
        {
            _champs = DataSet.Championship.GetChampionships();
            comboBoxChampName.DataSource = _champs;
            comboBoxChampName.DisplayMember = "title";
            comboBoxChampName.ValueMember = "id";
        }

        private void FillComboBoxCompetitions()
        {
            _skills = DataSet.Skill.GetSkills();
            comboBoxCompetition.DataSource = _skills;
            comboBoxCompetition.DisplayMember = "title";
            comboBoxCompetition.ValueMember = "id";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (checkedBoxCompetitions.Visible)
            //{
            //    return;
            //}

            //checkedBoxCompetitions.Visible = true;
            //checkedBoxCompetitions.Items.Add(comboBoxCompetition.DataSource);
            //checkedBoxCompetitions.SetItemChecked(0, true);
        }

        private void buttonChooseLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                pictureChampLogo.Image = Image.FromFile(openFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть заданный файл", "Ошибка");
            }
        }

        private void buttonSaveNewChamp_Click(object sender, EventArgs e)
        {
            if (_championshipMenuInAddMode)
            {
                InsertNewChampInDb();
            }
            else
            {
                UpdateChampInDb();
            }
        }

        private void InsertNewChampInDb()
        {
            if ( ! IsInputDataCorrect())
            {
                return;
            }

            string title = textBoxChampName.Text;
            DateTime start = pickerStart.Value;
            DateTime end = pickerEnd.Value;
            string desc = textBoxComment.Text;
            string city = textBoxCityName.Text;
            int chiefExpertId = (int)comboBoxMainExpert.SelectedValue;
            int expertCount = (int)updownNumExperts.Value;
            int teamCount = (int)updownNumParticipants.Value;

            try
            {
                _champ = new Championship(title, start, end, desc, city, chiefExpertId, expertCount, teamCount);
                _champ.Skills.Add(new Skill((int)comboBoxCompetition.SelectedValue));
                _champ.InsertChampInDb();
                MessageBox.Show("Данные успешно добавлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateChampInDb()
        {
            if (!IsInputDataCorrect())
            {
                return;
            }

            _champ.Title = textBoxChampName.Text;
            _champ.Start = pickerStart.Value;
            _champ.End = pickerEnd.Value;
            _champ.Description = textBoxComment.Text;
            _champ.City = textBoxCityName.Text;
            _champ.ChiefExpertId = (int)comboBoxMainExpert.SelectedValue;
            _champ.ExpertCount = (int)updownNumExperts.Value;
            _champ.TeamCount = (int)updownNumParticipants.Value;

            try
            {
                _champ.UpdateChamp();
                MessageBox.Show("Данные успешно обновлены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private bool IsInputDataCorrect()
        {
            string title = textBoxChampName.Text;
            DateTime start = pickerStart.Value;
            DateTime end = pickerEnd.Value;
            string city = textBoxCityName.Text;

            if (start > end)
            {
                MessageBox.Show("Дата начала чемпионата должна быть раньше чем дата окончания");
                return false;
            }

            if (title.Length == 0)
            {
                MessageBox.Show("Заполните поле \"Название чемпионата\"");
                return false;
            }

            if (city.Length == 0)
            {
                MessageBox.Show("Заполните поле \"Город\"");
                return false;
            }

            return true;
        }

        private void LoadSelectedChamp()
        {
            _champ = new Championship((int)comboBoxChampName.SelectedValue);
            pickerStart.Value = _champ.Start;
            pickerEnd.Value = _champ.End;
            textBoxChampName.Text = _champ.Title;
            textBoxCityName.Text = _champ.City;
            textBoxComment.Text = _champ.Description;
            comboBoxCompetition.SelectedValue = _champ.Skills.Count != 0 ? _champ.Skills[0].Id : 1;
            comboBoxMainExpert.SelectedValue = _champ.ChiefExpertId;
            updownNumExperts.Value = _champ.ExpertCount;
            updownNumParticipants.Value = _champ.TeamCount;
        }

        private void comboBoxChampName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedChamp();
        }
    }
}
