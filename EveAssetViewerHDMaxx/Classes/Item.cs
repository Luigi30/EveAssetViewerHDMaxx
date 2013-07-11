using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveAssetViewerHDMaxx
{
    public class Item
    {
        /* Item
         * 
         * An Eve item. Represents the invItem database object.
         */

        //attribute ID 275 = skill multiplier

        public int typeId;
        public string name;
        public string description;
        public int marketGroupID;
        public string marketGroupName;
        public List<Attribute> attributes;

        public Item()
        {
            typeId = -1;
            name = "unknown item";
            description = "unknown description";
            marketGroupID = -1;
        }

        public Item(int _typeId, string _name, string _description, int _marketGroupID, double _multiplier, string _marketGroupName)
        {
            typeId = _typeId;
            name = _name;
            description = _description;
            marketGroupID = _marketGroupID;
            marketGroupName = _marketGroupName;
        }

        public string DisplayName
        {
            get
            {
                return name;
            }
        }

        override public string ToString()
        {
            return String.Format("Skill {0}: {1}", typeId, name);
        }

    }

    public class Attribute
    {
        /* Attribute
           An attribute of an Eve item and its values. */

        public int attributeID;
        public int valueInt;
        public float valueFloat;

        public Attribute(int _id, int _valueInt, float _valueFloat)
        {
            attributeID = _id;
            valueInt = _valueInt;
            valueFloat = _valueFloat;
        }
    }
}
