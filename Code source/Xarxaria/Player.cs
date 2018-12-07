using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Name { get { return name; } }
        public int Force { get { return force; } }
        public int Agility { get { return agility; } }
        public int Armor { get { return armor; } }
        public int Luck { get { return luck; } }
        public int Pv { get { return pv; } }
        public int IdInventory { get { return idInventory; } }
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

        public void AddPv(int pvNumber)
        {
            pv += pvNumber;
        }

        public void RemovePv(int pvNumber)
        {
            pv -= pvNumber;
            if (pv < 0)
            {
                Console.WriteLine("La partie est terminée, le joueur n'as plus de points de vie");
            };
        }

        public void AddItem(int itemId, int numberOfItem)
        {
            inventory.AddItem(itemId, numberOfItem);
        }
        #endregion
    }
}
