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
        int[] items;
        #endregion

        #region accessors
        public int[] Items { get { return items; } }
        #endregion

        #region constructor
        //Empty inventory constructor to compile
        public Inventory(int numberOfItems)
        {
            InitliaizeItemList(numberOfItems);
        }

        //Inventory constructor
        public Inventory(int numberOfItems, int[] items)
        {
            InitliaizeItemList(numberOfItems);
            this.items = items;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Initialize number of items if it is not initalized
        /// </summary>
        void InitliaizeItemList(int numberOfItems)
        {
            if (items == null)
            {
                //Initialize array
                items = new int[numberOfItems];

                //Fill the array with 0
                for (int i = 0; i < numberOfItems - 1; i++)
                    items[i] = 0;
                
            }
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
