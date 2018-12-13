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
        int pv;
        int force;
        int agility;
        int armor;
        int luck;
        string name;
        int idActualPage;
        int idInventory;
        Inventory inventory;
        #endregion

        #region accessors
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public int Force { get { return force; } }
        public int Agility { get { return agility; } }
        public int Armor { get { return armor; } }
        public int Luck { get { return luck; } }
        public int Pv { get { return pv; } }
        public int IdInventory { get { return idInventory; } }
        public int IdActualPage { get { return idActualPage; } }
        public Inventory getInventory { get { return inventory; } }
        #endregion

        #region constructor
        //Empty player constructor to compile
        public Player()
        {
            
        }

        //Player constructor
        public Player(int id, int pv, int force, int agility, int armor, int luck, string name, int idActualPage, int idInventory, Inventory inventory)
        {
            this.id = id;
            this.pv = pv;
            this.force = force;
            this.agility = agility;
            this.armor = armor;
            this.luck = luck;
            this.name = name;
            this.idActualPage = idActualPage;
            this.idInventory = idInventory;
            this.inventory = inventory;
        }
        #endregion

        #region public methods
        public void SetItem(int itemId, int numberOfItem)
        {
            inventory.SetItem(itemId, numberOfItem);
        }

        public void SetPv(int val)
        {
            pv += val;

            if (pv < 0)
            {
                Console.WriteLine("La partie est terminée, le joueur n'as plus de points de vie");
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
        #endregion
    }
}
