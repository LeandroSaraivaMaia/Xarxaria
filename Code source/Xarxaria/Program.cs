using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xarxaria
{
    static class Program
    {
        #region public static constant values
        public static string[] itemLists = {
            "Pièce d'or"
        };
        public enum actionId { pageChange, addItem, removeItem, changePlayerHp, changePlayerForce, changePlayerArmor, changePlayerAgility, changePlayerLuck};
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
