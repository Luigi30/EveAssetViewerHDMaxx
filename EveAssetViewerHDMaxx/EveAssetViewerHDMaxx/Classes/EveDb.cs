using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EveAssetViewerHDMaxx.Classes
{
    public static class EveDb
    {
        public static List<Skill> generateEveSkillsList()
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Integrated Security=SSPI;Initial Catalog=ebs_DATADUMP");
            List<Skill> itemList = new List<Skill>();
            con.Open();

            using (SqlCommand command = new SqlCommand("SELECT i.typeID, i.typeName, i.description, a.valueFloat, i.marketGroupID, (SELECT marketGroupName FROM ebs_DATADUMP.dbo.invMarketGroups AS m WHERE i.marketGroupID = m.marketGroupID) AS marketGroupName FROM ebs_DATADUMP.dbo.invTypes AS i JOIN ebs_DATADUMP.dbo.dgmTypeAttributes AS a ON i.typeID = a.typeID WHERE attributeID = 275 AND published = 1 AND marketGroupID IS NOT NULL ORDER BY marketGroupID ASC, typeName ASC", con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    itemList.Add(new Skill(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(4), reader.GetDouble(3), reader.GetString(5)));
                }
            }

            return itemList;

        }
    }
}
