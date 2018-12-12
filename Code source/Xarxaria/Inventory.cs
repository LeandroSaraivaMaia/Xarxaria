/**
 * \file      Inventory.cs
 * \author    Johan Voland & Leandro Saraiva Maia
 * \version   1.0
 * \date      December 6. 2018
 * \brief     Inventory class
 *
 * \details   This class represent contains the an int array containing indexing all the item of the game by id.
 * There are public methods to interract with the inventory.
 */

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Xarxaria
{
    public class Inventory
    {
        #region private attributes
        //Contains all object of the game indexing by id
        int[] items = new int[Program.itemLists.Length];
        #endregion

        #region accessors
        public int[] Items { get { return items; } }
        #endregion

        #region constructor
        //Empty inventory constructor to compile
        public Inventory()
        {

        }

        //Inventory constructor
        public Inventory(int[] items)
        {
            this.items = items;
        }
        #endregion

        #region public methods
        public void SetItem(int itemId, int numberOfItem)
        {
            items[itemId] += numberOfItem;

            if (items[itemId] < 0)
            {
                items[itemId] = 0;
            }
        }
        #endregion
    }
}
