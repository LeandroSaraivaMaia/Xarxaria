/**
* \file      Enemy.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      Jannuary 10. 2019
* \brief     Enemy class.
*
* \details   This class represent an enemy. An enemy has the same caracteristic that the player (Health, armor, force, agility, luck).
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
    class Enemy
    {
        #region private attributes
        int id;
        int hp;
        int force;
        int agility;
        int armor;
        int luck;
        string name;
        string image;
        #endregion

        #region public accessors
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public int Force { get { return force; } }
        public int Agility { get { return agility; } }
        public int Armor { get { return armor; } }
        public int Luck { get { return luck; } }
        public int Hp { get { return hp; } }
        public string Image { get { return image; } }
        #endregion

        #region constructor
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Enemy()
        {

        }

        //Enemy constructor
        /// <summary>
        /// Constructor with enemy's caracteristics and image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hp"></param>
        /// <param name="force"></param>
        /// <param name="agility"></param>
        /// <param name="armor"></param>
        /// <param name="luck"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        public Enemy(int id, int hp, int force, int agility, int armor, int luck, string name, string image)
        {
            this.id = id;
            this.hp = hp;
            this.force = force;
            this.agility = agility;
            this.armor = armor;
            this.luck = luck;
            this.name = name;
            this.image = image;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Set enemy's hp.
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
        /// Set enemy's armor.
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
        /// Set enemy's force.
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
        /// Set enemy's agility.
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
        /// Set enemy's luck.
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
        #endregion
    }
}
