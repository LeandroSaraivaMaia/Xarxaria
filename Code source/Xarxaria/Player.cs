using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xarxaria
{
    class Player
    {
        #region private attributes
        int id;
        int pv;
        int force;
        int armor;
        string name;
        int idActualPage;
        int idInventory;
        Inventory inventory;
        #endregion

        #region accessors
        public int IdInventory { get { return idInventory; } }
        #endregion

        #region constructor
        //Empty player constructor to compile
        public Player()
        {
            
        }

        //Player constructor
        public Player(int id, int pv, int force, int armor, string name, int idActualPage, int idInventory)
        {
            this.id = id;
            this.pv = pv;
            this.force = force;
            this.armor = armor;
            this.name = name;
            this.idActualPage = idActualPage;
            this.idInventory = idInventory;
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
        #endregion
    }
}
