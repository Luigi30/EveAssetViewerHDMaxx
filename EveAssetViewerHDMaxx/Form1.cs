using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using EveAssetViewerHDMaxx.Classes;

namespace EveAssetViewerHDMaxx
{

    public partial class Form1 : Form
    {

        List<Skill> eveItems = new List<Skill>();

        Form2 childView = new Form2();

        public Form1()
        {
            InitializeComponent();

            eveItems = generateEveItemsList();

            lbSkillsList.DataSource = eveItems;
            lbSkillsList.DisplayMember = "DisplayName";

            childView.Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDesc.Text = eveItems[lbSkillsList.SelectedIndex].description;
            lblSkillId.Text = String.Format("Skill ID: {0}", eveItems[lbSkillsList.SelectedIndex].typeId.ToString());
            lblSkillX.Text = String.Format("Skill X: {0}", eveItems[lbSkillsList.SelectedIndex].multiplier.ToString());
        }

        public List<Skill> generateEveItemsList()
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Integrated Security=SSPI;Initial Catalog=ebs_DATADUMP");
            List<Skill> itemList = new List<Skill>();
            con.Open();

            using (SqlCommand command = new SqlCommand("SELECT i.typeID, i.typeName, i.description, a.valueFloat, i.marketGroupID, (SELECT marketGroupName FROM ebs_DATADUMP.dbo.invMarketGroups AS m WHERE i.marketGroupID = m.marketGroupID) AS marketGroupName FROM ebs_DATADUMP.dbo.invTypes AS i JOIN ebs_DATADUMP.dbo.dgmTypeAttributes AS a ON i.typeID = a.typeID WHERE attributeID = 275 AND published = 1 ORDER BY marketGroupID ASC, typeName ASC", con))
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
