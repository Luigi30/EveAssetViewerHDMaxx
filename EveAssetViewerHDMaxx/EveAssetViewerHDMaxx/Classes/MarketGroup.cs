using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveAssetViewerHDMaxx.Classes
{
    public class MarketGroup
    {
        /* MarketGroup
         * 
         * A marketgroup. I don't think this is used.
         */

        public int id;
        public string name;
        public string description;

        public MarketGroup(int _id, string _name, string _description)
        {
            id = _id;
            name = _name;
            description = _description;
        }

    }
}
