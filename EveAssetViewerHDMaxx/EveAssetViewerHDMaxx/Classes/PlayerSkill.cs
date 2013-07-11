using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveAssetViewerHDMaxx.Classes
{
    public class PlayerSkill
    {
        Int32 typeId;
        public int level;
        public Int32 skillPoints;
        public string name;
        public string marketGroupId;

        public PlayerSkill(int _typeId, Int32 _skillPoints, int _level, string _name, string _marketGroupId)
        {
            typeId = _typeId;
            level = _level;
            skillPoints = _skillPoints;
            name = _name;
            marketGroupId = _marketGroupId;
        }

        public string SkillInformation
        {
            get
            {
                return String.Format("{0} - {1} - Level {2} ({3} SP)", marketGroupId, name, level, skillPoints);
            }
        }

    }
}
