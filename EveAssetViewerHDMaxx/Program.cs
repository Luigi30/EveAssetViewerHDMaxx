using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EveAssetViewerHDMaxx.Classes;

/* AssetViewerHDMaxx
 *
 * https://api.eveonline.com/char/CharacterSheet.xml.aspx?keyID=909875&vCode=lDThq3GNeMZsqNo1NP3fcmkvEvOBp9vER2JHVhUlr1uyglISbQUb13hVn2Ln1jAJ&characterID=860227105
 * the typeIDs match up with the typeID of the skill in the invTypes table
 * connect to SQL Server 2010 and figure out which is which.
 * 
 */

namespace EveAssetViewerHDMaxx
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }

    }
}
