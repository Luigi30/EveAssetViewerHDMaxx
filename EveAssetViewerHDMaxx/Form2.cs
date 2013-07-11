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
using System.IO;
using System.Net;
using EveAssetViewerHDMaxx.Classes;

namespace EveAssetViewerHDMaxx
{
    public partial class Form2 : Form
    {

        List<Skill> eveItems = new List<Skill>();

        public Form2()
        {
            InitializeComponent();

            eveItems = EveDb.generateEveSkillsList();
            List<MarketGroup> marketGroupIds = getMarketGroups();

            TreeNode skillNode = new TreeNode("Skills");

            foreach (MarketGroup group in marketGroupIds)
            {
                skillNode.Nodes.Add(group.name);
            }

            foreach (Skill skill in eveItems)
            {
                //skillNode.Nodes.Add(skill.name);
                foreach (TreeNode node in skillNode.Nodes)
                {
                    if (node.Text == skill.marketGroupName)
                    {
                        TreeNode newNode = new TreeNode();
                        newNode.Text = String.Format("{0} (Rank {1})", skill.name, skill.multiplier);
                        newNode.Tag = skill;
                        node.Nodes.Add(newNode);
                        lblSkillId.Text = String.Format("Skill ID: {0}", skill.typeId);
                    }
                }
            }

            treeView1.Nodes.Add(skillNode);
        }

        public List<MarketGroup> getMarketGroups()
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Integrated Security=SSPI;Initial Catalog=ebs_DATADUMP");
            List<MarketGroup> list = new List<MarketGroup>();
            con.Open();

            using (SqlCommand command = new SqlCommand("SELECT marketGroupID, marketGroupName, description FROM ebs_DATADUMP.dbo.invMarketGroups WHERE marketGroupID IN ( SELECT i.marketGroupID FROM ebs_DATADUMP.dbo.invTypes AS i INNER JOIN ebs_DATADUMP.dbo.dgmTypeAttributes AS a ON i.typeID = a.typeID WHERE (a.attributeID = 275) AND (i.published = 1) GROUP BY i.marketGroupID ) ORDER BY marketGroupName ASC", con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MarketGroup mg = new MarketGroup(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    list.Add(mg);
                }
            }

            return list;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if the node is not the root and not on the first level, load boilerplate text instead of the description.
            if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text != "Skills")
            {
                try
                {
                    Skill skill = (Skill)treeView1.SelectedNode.Tag;
                    tbDesc.Text = skill.description;
                }
                catch
                {
                    tbDesc.Text = "Tag of this Node is not a Skill!";
                }
            }
            else
            {
                tbDesc.Text = "Select a skill to view its description.";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void aPISettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApiSettingsPanel settings = new ApiSettingsPanel();
            settings.Show();
        }

        private void lblSkillId_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //spawn a Task to update the character sheet.
            toolStripStatusLabel1.Text = "Updating character sheet...";
            var updateCharSheetTask = new Task(() => updateEveCharacterSheet());
            updateCharSheetTask.Start();
        }

        //This takes place on a secondary thread so we need to Invoke things that affect the UI
        private void updateEveCharacterSheet()
        {
            string keyId = Properties.Settings.Default.apiKeyId;
            string vCode = Properties.Settings.Default.apiVcode;
            string charId = Properties.Settings.Default.apiCharId;

            CharacterSheet charSheet = new CharacterSheet(keyId, vCode, charId);
            updateCharSheetLabels(charSheet);

            updatePlayerSkills(charSheet);

            MessageBox.Show("Update complete.");
        }

        //This takes place on a secondary thread so we need to Invoke things that affect the UI
        private void updateCharSheetLabels(CharacterSheet charSheet)
        {
            lblCharName.Invoke(new MethodInvoker(delegate { lblCharName.Text = charSheet.charName; }));
            lblCharCreated.Invoke(new MethodInvoker(delegate { lblCharCreated.Text = charSheet.charCreated; }));
            lblRace.Invoke(new MethodInvoker(delegate { lblRace.Text = charSheet.charRace; }));
            lblCorporation.Invoke(new MethodInvoker(delegate { lblCorporation.Text = charSheet.charCorporation; }));
            lblAlliance.Invoke(new MethodInvoker(delegate { lblAlliance.Text = charSheet.charAlliance; }));
            //TODO: Why doesn't String.Format() seem to do anything?
            lblSkillPoints.Invoke(new MethodInvoker(delegate { lblSkillPoints.Text = String.Format("{0:#,###0}", charSheet.charSkillPoints); }));
            lblBalance.Invoke(new MethodInvoker(delegate { lblBalance.Text = String.Format("{0:C}", charSheet.charBalance); }));

            string pictureUrl = String.Format("http://image.eveonline.com/character/{0}_128.jpg", charSheet.characterId);
            pictureBox1.Invoke(new MethodInvoker(delegate { pictureBox1.Load(pictureUrl); }));
        }

        private void updatePlayerSkills(CharacterSheet charSheet)
        {
            lbPlayerSkills.Invoke(new MethodInvoker(delegate { lbPlayerSkills.DataSource = charSheet.charSkills; }));
            lbPlayerSkills.Invoke(new MethodInvoker(delegate { lbPlayerSkills.DisplayMember = "SkillInformation"; }));
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }

    namespace Toolset.Controls
    {
        public class CustomDrawListBox : ListBox
        {
            public CustomDrawListBox()
            {
                this.DrawMode = DrawMode.OwnerDrawVariable; // We're using custom drawing.
                this.ItemHeight = 40; // Set the item height to 40.
            }

            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                // Make sure we're not trying to draw something that isn't there.
                if (e.Index >= this.Items.Count || e.Index <= -1)
                    return;

                // Get the item object.
                object item = this.Items[e.Index];
                if (item == null)
                    return;

                // Draw the background color depending on 
                // if the item is selected or not.
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    // The item is selected.
                    // We want a blue background color.
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                }
                else
                {
                    // The item is NOT selected.
                    // We want a white background color.
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }

                // Draw the item.
                string text = item.ToString();
                SizeF stringSize = e.Graphics.MeasureString(text, this.Font);
                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.White),
                    new PointF(5, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2));
            }
        }
    }
}
