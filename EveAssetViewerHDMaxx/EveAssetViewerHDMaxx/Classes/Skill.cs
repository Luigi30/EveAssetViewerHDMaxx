using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveAssetViewerHDMaxx.Classes
{
    public class Skill : Item
    {
        /* Skill
         * 
         * An Eve skill. An Item that we store the skill point multiplier attribute for.
         */
        public double multiplier;

        public Skill()
        {
            typeId = -1;
            name = "unknown skill";
            description = "unknown skill";
            marketGroupID = -1;
            multiplier = -1;
        }

        public Skill(int _typeId, string _name, string _description, int _marketGroupID, double _multiplier, string _marketGroupName)
        {
            typeId = _typeId;
            name = _name;
            description = _description;
            marketGroupID = _marketGroupID;
            multiplier = _multiplier;
            marketGroupName = _marketGroupName;
        }
    }
}
