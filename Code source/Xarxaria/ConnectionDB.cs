/**
 * \file      ConnectionDB.cs
 * \author    Johan Voland
 * \version   1.0
 * \date      November 28. 2018
 * \brief     Set of methods to interact with the database
 *
 * \details   This file contains all the necessary attributes and methods to interact with the database.
 */

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Xarxaria
{
    class ConnectionDB
    {
        #region private attributes
        //Object needed for database operation
        SqlConnection sqlConnection;
        #endregion

        #region constructor
        /// <summary>
        /// Connection to the DB in the constructor
        /// Uses the "xarxariaLogin" user in the "XarxariaDB" database
        /// </summary>
        public ConnectionDB()
        {
            string connectionString = "Data Source=localhost; Initial Catalog=XarxariaDB; User ID=xarxariaLogin; Password=Pa$$w0rd";
            sqlConnection = new SqlConnection(connectionString);
        }
        #endregion

        #region Modify query
        /// <summary>
        /// Add a player in the database
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="hp">Number of Health Points</param>
        /// <param name="force">Number of force</param>
        /// <param name="armor">Number of armor</param>
        /// <param name="agility">Number of force</param>
        /// <param name="luck">Number of force</param>
        /// <param name="idActualPage">Id of the actual page</param>
        /// <param name="idInventory">Inventory id of the player</param>
        public void AddPlayer(string name, int hp, int force, int armor, int agility, int luck, int idActualPage, int idInventory)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Player (pv, force, armor , agility, luck, name, idActualPage, idInventory) VALUES ("+hp+", "+force+", "+armor+", "+agility+", "+luck+", '"+name+"', "+idActualPage+", "+idInventory+")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        /// <summary>
        /// Adds an empty inventory
        /// </summary>
        public void AddEmptyInventory()
        {
            //Generate a query ot insert an empty inventory
            string query = "INSERT INTO Inventory (";

            for (int i = 0; i < Program.itemLists.Length; i++)
            {
                //Add the name of the item in the query
                query += Program.itemLists[i];

                //If it is the last item, don't add a comma
                if (i != Program.itemLists.Length - 1)
                {
                    query += ",";
                }
            }

            //Open values parenthesis
            query += ") VALUES (";

            //Add actual item value (which is 0 because the inventory is empty)
            for (int i = 0; i < Program.itemLists.Length; i++)
            {
                //Add the value of the item in the query
                query += "0";

                //If it is the last item, don't add a comma
                if (i != Program.itemLists.Length - 1)
                {
                    query += ",";
                }
            }

            //Close the query
            query += ")";

            //Those lines create the query, execute it and close the connection
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        /// <summary>
        /// Save the player progression
        /// </summary>
        /// <param name="player">player's datas</param>
        public void SavePlayer(Player player)
        {
            SqlCommand cmd = new SqlCommand();

            Player actualPlayer = player;

            cmd.CommandText = "UPDATE Player SET " +
                                "pv = " + actualPlayer.Hp +
                                ", force = " + actualPlayer.Force +
                                ", armor = " + actualPlayer.Armor +
                                ", agility = " + actualPlayer.Agility +
                                ", luck = " + actualPlayer.Luck +
                                ", name = " + "'" + actualPlayer.Name +
                                "', idActualPage = " + actualPlayer.IdActualPage +
                                ", idInventory = " + actualPlayer.IdInventory +
                                " WHERE id = " + actualPlayer.Id;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
        #endregion

        #region Select query
        /// <summary>
        /// Get all the players in the database
        /// </summary>
        /// <returns>A list of all the players</returns>
        public List<Player> GetPlayers()
        {
            //List that will contain all the players
            List<Player> players = new List<Player>();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Player";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            int id, pv, force, agility, armor, luck, idActualPage, idInventory;
            string name;

            while (reader.Read())
            {
                //Create empty player
                Player selectedPlayer = new Player();

                //Create empty inventory
                Inventory playerInventory = new Inventory();

                //Get all data of the player
                id = int.Parse(reader["id"].ToString());
                pv = int.Parse(reader["pv"].ToString());
                force = int.Parse(reader["force"].ToString());
                agility = int.Parse(reader["agility"].ToString());
                armor = int.Parse(reader["armor"].ToString());
                luck = int.Parse(reader["luck"].ToString());
                name = reader["name"].ToString();
                idActualPage = int.Parse(reader["idActualPage"].ToString());
                idInventory = int.Parse(reader["idInventory"].ToString());

                //Add the player to the list of players
                players.Add(new Player(id, pv, force, agility, armor, luck, name, idActualPage, idInventory, playerInventory));
            }

            sqlConnection.Close();

            //Get all the inventories
            foreach (Player player in players)
            {
                player.LoadInventory();
            }

            return players;
        }
        
        /// <summary>
        /// Get the number of player in the database
        /// </summary>
        /// <returns>Number of player in the database</returns>
        public int GetNumberOfPlayer()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            int numberOfPlayer = 0;

            cmd.CommandText = "SELECT * FROM Player";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfPlayer++;
            }

            sqlConnection.Close();

            return numberOfPlayer;
        }

        /// <summary>
        /// Get the number of player in the database
        /// </summary>
        /// <returns>Number of player in the database</returns>
        public int GetNumberOfInventory()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            int numberOfInventory = 0;

            cmd.CommandText = "SELECT * FROM Inventory";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfInventory++;
            }

            sqlConnection.Close();

            return numberOfInventory;
        }

        /// <summary>
        /// Get all the player values from the database
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Player object with the values in the database</returns>
        public Player GetPlayerById(int playerId)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            Player selectedPlayer = new Player();
            Inventory playerInventory = GetInventory(selectedPlayer.IdInventory);

            cmd.CommandText = "SELECT * FROM Player WHERE id = " + playerId;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            //Check if player was found
            bool isPlayerFound = false;

            while (reader.Read())
            {
                isPlayerFound = true;
                //Get all data of the player
                int id = int.Parse(reader["id"].ToString());
                int pv = int.Parse(reader["pv"].ToString());
                int force = int.Parse(reader["force"].ToString());
                int agility = int.Parse(reader["agility"].ToString());
                int armor = int.Parse(reader["armor"].ToString());
                int luck = int.Parse(reader["luck"].ToString());
                string name = reader["name"].ToString();
                int idActualPage = int.Parse(reader["idActualPage"].ToString());
                int idInventory = int.Parse(reader["idInventory"].ToString());
                selectedPlayer = new Player(id, pv, force, agility, armor, luck, name, idActualPage, idInventory, playerInventory);
            }

            if (!isPlayerFound)
                throw new Exception("Player with id " + playerId + " not found in database");
            
            sqlConnection.Close();

            return selectedPlayer;
        }

        /// <summary>
        /// Get inventory values according to Id
        /// </summary>
        /// <param name="idInventory"></param>
        /// <returns>Inventory object with the value in the database</returns>
        public Inventory GetInventory(int idInventory)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            Inventory selectedInventory = new Inventory();

            cmd.CommandText = "SELECT * FROM Inventory WHERE id = " + idInventory;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int[] inventoryValues = new int[Program.itemLists.Length];

                //Get all data of the inventroy
                for (int i = 0; i < Program.itemLists.Length - 1; i++)
                {
                    inventoryValues[i] = int.Parse(reader[Program.itemLists[i]].ToString());
                }

                //Create a new inventory and give it the readed values
                selectedInventory = new Inventory(inventoryValues);
            }

            sqlConnection.Close();

            return selectedInventory;
        }

        /// <summary>
        /// Get page values according to Id
        /// </summary>
        /// <param name="idPage"></param>
        /// <returns>Page object with the value in the database</return
        public Page GetPage (int idPage)
        {
            Page readedPage = new Page();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Page WHERE id = " + idPage;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                readedPage = new Page(Convert.ToInt32(reader["id"]), reader["title"].ToString(), reader["text"].ToString(), reader["image"].ToString());
            }

            sqlConnection.Close();

            return readedPage;
        }
        #endregion
    }
}
