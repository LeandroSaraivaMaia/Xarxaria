/**
* \file      Player.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      December 6. 2018
* \brief     Player class.
*
* \details   This class represent a player and contains all the value in the database for a player.
* There are public methods to interact with the player's inventory and caracteristics.
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
    public class Player
    {
        #region private attributes
        int id;
        int hp;
        int force;
        int agility;
        int armor;
        int luck;
        string name;
        int idActualPage;
        uint inactiveLinksInActualPage;
        Inventory inventory;
        #endregion

        #region public accessors
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public int Force { get { return force; } }
        public int Agility { get { return agility; } }
        public int Armor { get { return armor; } }
        public int Luck { get { return luck; } }
        public int Hp { get { return hp; } }
        public int IdActualPage { get { return idActualPage; } }
        public uint InactiveLinksInActualPage { get { return inactiveLinksInActualPage; } set { inactiveLinksInActualPage = value; } }
        public Inventory GetInventory { get { return inventory; } }
        #endregion

        #region constructor
        /// <summary>
        /// Empty player constructor.
        /// </summary>
        public Player()
        {

        }
        /// <summary>
        /// Player constructor with caracteristics.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hp"></param>
        /// <param name="force"></param>
        /// <param name="agility"></param>
        /// <param name="armor"></param>
        /// <param name="luck"></param>
        /// <param name="name"></param>
        /// <param name="idActualPage"></param>
        /// <param name="InactiveLinksInActualPage"></param>
        /// <param name="inventory"></param>
        public Player(int id, int hp, int force, int agility, int armor, int luck, string name, int idActualPage, uint InactiveLinksInActualPage, Inventory inventory)
        {
            this.id = id;
            this.hp = hp;
            this.force = force;
            this.agility = agility;
            this.armor = armor;
            this.luck = luck;
            this.name = name;
            this.idActualPage = idActualPage;
            this.InactiveLinksInActualPage = InactiveLinksInActualPage;
            this.inventory = inventory;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Get the player's inventory in database.
        /// </summary>
        public void LoadInventory()
        {
            inventory = Program.connection.GetInventoryByPlayerId(Id);
        }

        /// <summary>
        /// Set item in player's inventory.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="numberOfItem"></param>
        public void SetItem(int itemId, int numberOfItem)
        {
            inventory.SetItem(itemId, numberOfItem);
        }

        /// <summary>
        /// Set player's hp.
        /// </summary>
        /// <param name="val"></param>
        public void SetHp(int val)
        {
            hp += val;

            if (hp < 0)
            {
                hp = 0;
            };
        }

        /// <summary>
        /// Set player's armor.
        /// </summary>
        /// <param name="val"></param>
        public void SetArmor(int val)
        {
            armor += val;

            if (armor < 0)
            {
                armor = 0;
            };
        }

        /// <summary>
        /// Set player's force.
        /// </summary>
        /// <param name="val"></param>
        public void SetForce(int val)
        {
            force += val;

            if (force < 0)
            {
                force = 0;
            };
        }

        /// <summary>
        /// Set player's agility.
        /// </summary>
        /// <param name="val"></param>
        public void SetAgility(int val)
        {
            agility += val;

            if (agility < 0)
            {
                agility = 0;
            };
        }

        /// <summary>
        /// Set player's luck.
        /// </summary>
        /// <param name="val"></param>
        public void SetLuck(int val)
        {
            luck += val;

            if (luck < 0)
            {
                luck = 0;
            };
        }

        /// <summary>
        /// Set player's actual page.
        /// </summary>
        /// <param name="id"></param>
        public void SetActualPage(int id)
        {
            idActualPage = id;
        }

        /// <summary>
        /// Override ToString method.
        /// In frmLoadSelection, there is a control list containing player object.
        /// When an object is contained in a control list, the list automatically uses the ToString method of the object to be the string displayed in the list.
        /// This methods returns the player name and the actual page title, so the user that load the save know where he was.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + ", " + Program.connection.GetPage(IdActualPage).Title;
        }
        #endregion
    }
}
