using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using EveAssetViewerHDMaxx.Classes;

namespace EveAssetViewerHDMaxx.Classes
{
    class EveApi
    {
        /* EveApi
         * 
         * Interaction with the CCP Eve API occurs here. God help us all.
         */

        private CharacterSheet activeCharacter;

        public static string getCharacterName(string charId)
        {
            string charName;

            try
            {
                string xmlString = StringGet.GetPageAsString(new Uri(String.Format("https://api.eveonline.com/eve/CharacterInfo.xml.aspx?characterID={0}", charId)));

                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    reader.ReadToFollowing("result");
                    reader.ReadToFollowing("characterName");
                    charName = reader.ReadElementContentAsString();
                }
            } catch {
                return "Error";
            }
            return charName;
        }

        public static string retrieveApiCharSheet(string keyId, string vCode, string charId)
        {
            string url = String.Format("https://api.eveonline.com/char/CharacterSheet.xml.aspx?keyID={0}&vCode={1}&characterID={2}", keyId, vCode, charId);
            string xmlString = StringGet.GetPageAsString(new Uri(url));

            return xmlString;
        }

        public void setActiveCharacter(CharacterSheet sheet)
        {
            activeCharacter = sheet;
        }

        public CharacterSheet getActiveCharacter()
        {
            return activeCharacter;
        }
    }

    public class CharacterSheet
    {
        //An Eve character sheet. The representation of the CharacterSheet API result.
        public string characterId;
        public string charName;
        public string charCreated;
        public string charCorporation;
        public string charAlliance;
        public string charRace;
        public string charSkillPoints;
        public string charBalance;
        public List<PlayerSkill> charSkills;

        public CharacterSheet(string keyId, string vCode, string charId)
        {
            string xmlCharSheet = EveApi.retrieveApiCharSheet(keyId, vCode, charId);

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlCharSheet)))
            {
                reader.ReadToFollowing("result");
                characterId = charId;
                reader.ReadToFollowing("name");
                charName = reader.ReadElementContentAsString();
                reader.ReadToFollowing("DoB");
                charCreated = reader.ReadElementContentAsString();
                reader.ReadToFollowing("race");
                charRace = reader.ReadElementContentAsString();
                reader.ReadToFollowing("corporationName");
                charCorporation = reader.ReadElementContentAsString();
                reader.ReadToFollowing("allianceName");
                charAlliance = reader.ReadElementContentAsString();
                reader.ReadToFollowing("balance");
                charBalance = reader.ReadElementContentAsString();

                charSkillPoints = tabulateSkillPoints(xmlCharSheet);
                charSkills = retrievePlayerSkills(xmlCharSheet);
            }

        }

        private List<PlayerSkill> retrievePlayerSkills(string xmlCharSheet)
        {
            List<Skill> masterSkillsList = EveDb.generateEveSkillsList();
            List<PlayerSkill> skills = new List<PlayerSkill>();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlCharSheet);

            XmlNode root = doc.FirstChild;
            XmlNodeList skillsList = doc.SelectNodes("eveapi/result/rowset");

            skillsList = skillsList[0].ChildNodes;

            foreach (XmlNode node in skillsList)
            {
                skills.Add(new PlayerSkill(Convert.ToInt32(node.Attributes[0].Value), Convert.ToInt32(node.Attributes[1].Value), Convert.ToInt16(node.Attributes[2].Value), getSkillName(masterSkillsList, Convert.ToInt32(node.Attributes[0].Value)), getSkillGroup(masterSkillsList, Convert.ToInt32(node.Attributes[0].Value))));
            }

            //List<PlayerSkill> sortedSkills = skills.OrderBy()
            IEnumerable<PlayerSkill> sortedPlayerSkills =
                from skill in skills
                orderby skill.marketGroupId ascending, skill.name ascending
                select skill;

            skills = sortedPlayerSkills.ToList();

            return skills;

        }

        private string getSkillName(List<Skill> skills, Int32 typeId)
        {
            Skill skill = skills.Find(delegate(Skill searchSkill) { return searchSkill.typeId == typeId; });
            return skill.name;
        }

        private string getSkillGroup(List<Skill> skills, Int32 typeId)
        {
            Skill skill = skills.Find(delegate(Skill searchSkill) { return searchSkill.typeId == typeId; });
            return skill.marketGroupName;
        }

        private string tabulateSkillPoints(string xmlCharSheet)
        {
            //This function finds all skill nodes in a CharacterSheet and adds up the skill points.
            Int32 sp = 0;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlCharSheet);

            XmlNode root = doc.FirstChild;
            XmlNodeList skillsList = doc.SelectNodes("eveapi/result/rowset");

            skillsList = skillsList[0].ChildNodes;

            foreach (XmlNode node in skillsList)
            {
                sp += Convert.ToInt32(node.Attributes[1].Value);
            }

            return sp.ToString();
        }

    }

    public class StringGet
    {
        //Get a web page as a string. Useful for XML and JSON pages.
        public static string GetPageAsString(Uri address)
        {
            string result = "";

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();
            }

            return result;
        }
    }  
}
