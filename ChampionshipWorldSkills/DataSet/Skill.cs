using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ChampionshipWorldSkills.DataSet
{
    class Skill
    {
        public int Id;
        public string Title;
        public double WorkPlaceArea;
        public double ExpertGroupRoomArea;
        public double BrifingArea;
        public double StorageArea;
        public int TeamCount;

        public Skill(int id)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [skill] WHERE [id] = {id}", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();

            if (table.Rows.Count == 0)
            {
                throw new RecordNotFoundException("Skill не найден в базе");
            }

            Id = (int)table.Rows[0]["id"];
            Title = (string)table.Rows[0]["title"];
            WorkPlaceArea = (double)table.Rows[0]["work_place_area"];
            ExpertGroupRoomArea = (double)table.Rows[0]["expert_group_room_area"];
            BrifingArea = (double)table.Rows[0]["brifing_area"];
            StorageArea = (double)table.Rows[0]["storage_area"];
            TeamCount = (int)table.Rows[0]["team_count"];
        }

        public static DataTable GetSkills()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [skill]", DataBaseConnection.Connection);
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
    }
}
