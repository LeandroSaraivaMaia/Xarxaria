/**
* \file      Item.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      January 16. 2019
* \brief     Item class.
*
* \details   This class represent an item in the database.
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
    class Item
    {
        #region private attributes
        int id;
        int hp;
        int force;
        int agility;
        int armor;
        int luck;
        string name;
        #endregion

        #region accessor
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public int Force { get { return force; } }
        public int Agility { get { return agility; } }
        public int Armor { get { return armor; } }
        public int Luck { get { return luck; } }
        public int Hp { get { return hp; } }
        #endregion

        #region constructor
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Item()
        {

        }
        
        /// <summary>
        /// Constructor with caracteristics initialization.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hp"></param>
        /// <param name="force"></param>
        /// <param name="agility"></param>
        /// <param name="armor"></param>
        /// <param name="luck"></param>
        /// <param name="name"></param>
        public Item(int id, int hp, int force, int agility, int armor, int luck, string name)
        {
            this.id = id;
            this.hp = hp;
            this.force = force;
            this.agility = agility;
            this.armor = armor;
            this.luck = luck;
            this.name = name;
        }
        #endregion
    }
}
