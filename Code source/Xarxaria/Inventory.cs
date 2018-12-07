using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xarxaria
{
    public class Inventory
    {
        #region private attributes
        int[] items = new int[Program.itemLists.Length];
        #endregion

        #region accessors
        public int[] Items { get { return items; } }
        #endregion

        #region constructor
        public Inventory()
        {

        }
        public Inventory(int[] items)
        {
            this.items = items;
        }
        #endregion

        #region public methods
        public void AddItem(int itemId, int numberOfItem)
        {
            items[itemId] += numberOfItem;
        }

        public void RemoveItem(int itemId, int numberOfItem)
        {
            items[itemId] -= numberOfItem;

            if (items[itemId] < 0)
            {
                items[itemId] = 0;
            }
        }
        #endregion
    }
}
