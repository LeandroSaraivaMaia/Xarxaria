using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xarxaria
{
    class Inventory
    {
        #region private attributes
        int goldenPiece = 0;
        #endregion

        #region constructor
        public Inventory()
        {

        }
        public Inventory(int[] inventoryValues)
        {
            goldenPiece = inventoryValues[0];
        }
        #endregion
    }
}
