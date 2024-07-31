using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ChampionshipWorldSkills.DataSet
{
    class User
    {
        public int Id { get; private set; }
        public string Fio { get; private set; }
        public Gender Gender { get; private set; }
        public string Password { get; private set; }
        public string Pin { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Role Role { get; private set; }
        public int SkillId { get; private set; }
        public int RegionId { get; private set; }
        public int PlaceId { get; private set; }
        public int ChampionshipId { get; private set; }

        public User(string pin, string password)
        {
            string query =
                $"SELECT * FROM [user] WHERE [pin] = '{pin}' AND [password] = '{password}'";
            
            SqlCommand command = new SqlCommand(query, DataBaseConnection.Connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Id = (int)reader["id"];
                    Fio = reader["fio"].ToString();
                    Gender = reader["gender"].ToString() == "м" ? Gender.Male : Gender.Female;
                    Password = reader["password"].ToString();
                    Pin = reader["pin"].ToString();
                    BirthDate = (DateTime)reader["birth_date"];
                    Role = reader["role"] != DBNull.Value ? (Role)reader["role"] : Role.Undefined;
                    SkillId = reader["skill"] != DBNull.Value ? (int)reader["skill"] : -1;
                    RegionId = reader["region"] != DBNull.Value ? (int)reader["region"] : -1;
                    PlaceId = reader["place"] != DBNull.Value ? (int)reader["place"] : -1;
                    ChampionshipId = reader["championship"] != DBNull.Value ? (int)reader["championship"] : -1;

                    return;
                }
            }

            throw new RecordNotFoundException("Запись пользователя с таким логином и паролем не найдена");
        }

        public static DataTable GetChiefExpertUsers()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [user] WHERE [role] = {(int)DataSet.Role.ChiefExpert}", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
    }
}
