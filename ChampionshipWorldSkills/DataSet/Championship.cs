using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ChampionshipWorldSkills.DataSet
{
    class Championship
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string City { get; set; }

        public int ChiefExpertId { get; set; }
        public int ExpertCount { get; set; }
        public int TeamCount { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();


        public Championship(string title, DateTime start, DateTime end, string description, string city, int chiefExpertId, int expertCount, int teamCount)
        {
            Id = MaxChampId() + 1;
            Title = title;
            Start = start;
            End = end;
            Description = description;
            City = city;
            ChiefExpertId = chiefExpertId;
            ExpertCount = expertCount;
            TeamCount = teamCount;
        }

        public Championship(int id)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [competition] WHERE [id] = {id}", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();

            if (table.Rows.Count == 0)
            {
                throw new RecordNotFoundException("Чемпионат с таким id не наден");
            }

            Id = (int)table.Rows[0]["id"];
            Title = (string)table.Rows[0]["title"];
            Start = (DateTime)table.Rows[0]["date_start"];
            End = (DateTime)table.Rows[0]["date_end"];
            Description = (string)table.Rows[0]["description"];
            City = (string)table.Rows[0]["city"];
            ChiefExpertId = (int)table.Rows[0]["chief_expert"];
            ExpertCount = (int)table.Rows[0]["expert_count"];
            TeamCount = (int)table.Rows[0]["team_count"];

            LoadSkills();
        }

        public static DataTable GetChampionships()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [competition]", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }

        public void UpdateChamp()
        {
            string query =
                $"UPDATE [competition] SET [title] = '{Title}', [date_start] = '{Start.Date}', " +
                $"[date_end] = '{End.Date}', [description] = '{Description}', [city] = '{City}', " +
                $"[chief_expert] = {ChiefExpertId}, [expert_count] = {ExpertCount}, " +
                $"[team_count] = {TeamCount} WHERE [id] = {Id}";
            SqlCommand command = new SqlCommand(query, DataBaseConnection.Connection);

            try
            {
                command.ExecuteNonQuery();
                UpdateSkills();
            }
            catch
            {
                throw;
            }
        }

        public void InsertChampInDb()
        {
            string query =
                $"INSERT INTO [competition] VALUES ({Id}, '{Title}', '{Start.Date}', '{End.Date}', '{Description}', '{City}', {ChiefExpertId}, {ExpertCount}, {TeamCount})";
            SqlCommand command = new SqlCommand(query, DataBaseConnection.Connection);

            try
            {
                command.ExecuteNonQuery();
                InsertSkills();
            }
            catch
            {
                throw;
            }
        }

        private void InsertSkills()
        {
            foreach (Skill skill in Skills)
            {
                string query =
                $"INSERT INTO [competition_skill] VALUES ({Id}, {skill.Id})";
                SqlCommand command = new SqlCommand(query, DataBaseConnection.Connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        private void UpdateSkills()
        {
            string query =
                $"DELETE FROM [competition_skill] WHERE [competition_id] = {Id}";
            SqlCommand command = new SqlCommand(query, DataBaseConnection.Connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

            InsertSkills();
        }

        private int MaxChampId()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Max(id) AS [id] FROM [competition]", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();
            return (int)table.Rows[0]["id"];
        }

        private void LoadSkills()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [competition_skill] WHERE [competition_id] = {Id}", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();

            foreach (DataRow row in table.Rows)
            {
                Skills.Add(new Skill((int)row["skill_id"]));
            }
        }
    }
}
