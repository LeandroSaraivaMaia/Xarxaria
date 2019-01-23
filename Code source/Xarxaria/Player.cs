/**
 * \file      Player.cs
 * \author    Johan Voland & Leandro Saraiva Maia
 * \version   1.0
 * \date      December 6. 2018
 * \brief     Player class
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
        //Empty player constructor to compile
        public Player()
        {
            
        }

        //Player constructor
        public Player(int id, int hp, int force, int agility, int armor, int luck, string name, int idActualPage, Inventory inventory, uint InactiveLinksInActualPage = 0)
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
        public void LoadInventory()
        {
            inventory = Program.connection.GetInventoryByPlayerId(Id);
        }

        public void SetItem(int itemId, int numberOfItem)
        {
            inventory.SetItem(itemId, numberOfItem);
        }

        public void SetHp(int val)
        {
            hp += val;

            if (hp < 0)
            {
                hp = 0;
            };
        }

        public void SetArmor(int val)
        {
            armor += val;

            if (armor < 0)
            {
                armor = 0;
            };
        }

        public void SetForce(int val)
        {
            force += val;

            if (force < 0)
            {
                force = 0;
            };
        }

        public void SetAgility(int val)
        {
            agility += val;

            if (agility < 0)
            {
                agility = 0;
            };
        }

        public void SetLuck(int val)
        {
            luck += val;

            if (luck < 0)
            {
                luck = 0;
            };
        }

        public void SetActualPage(int id)
        {
            idActualPage = id;
        }

        public override string ToString()
        {
            return Name + ", " + Program.connection.GetPage(IdActualPage).Title;
        }
        #endregion
    }
}
