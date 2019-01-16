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

            //Update player caracteristics
            cmd.CommandText = "UPDATE Player SET " +
                                "pv = " + player.Pv +
                                ", force = " + player.Force +
                                ", armor = " + player.Armor +
                                ", agility = " + player.Agility +
                                ", luck = " + player.Luck +
                                ", name = " + "'" + player.Name +
                                "', idActualPage = " + player.IdActualPage +
                                " WHERE id = " + player.Id;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();

            //Get player inventory
            Inventory playerInventory = player.GetInventory;

            for (int i = 0; i < playerInventory.Items.Count(); i++)
            {
                //Update player's inventory
                cmd.CommandText = "UPDATE Player SET " +
                                    "quantity = " + playerInventory.Items[i] +
                                    " WHERE id = " + i;

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        #endregion

        #region Select query
        /// <summary>
        /// Get all the players in the database
        /// </summary>
        /// <returns>A list of all the players</returns>
        public List<Player> GetPlayers()
        {
            //Create empty inventory
            Inventory playerInventory = new Inventory(GetNumberOfItems());

            //List that will contain all the players
            List<Player> players = new List<Player>();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Player";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            int id, pv, force, agility, armor, luck, idActualPage;
            string name;

            while (reader.Read())
            {
                //Create empty player
                Player selectedPlayer = new Player();

                //Get all data of the player
                id = int.Parse(reader["id"].ToString());
                pv = int.Parse(reader["pv"].ToString());
                force = int.Parse(reader["force"].ToString());
                agility = int.Parse(reader["agility"].ToString());
                armor = int.Parse(reader["armor"].ToString());
                luck = int.Parse(reader["luck"].ToString());
                name = reader["name"].ToString();
                idActualPage = int.Parse(reader["idActualPage"].ToString());

                //Add the player to the list of players
                players.Add(new Player(id, pv, force, agility, armor, luck, name, idActualPage, playerInventory));
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
        /// Get the number of different items
        /// </summary>
        /// <returns>Number of different items</returns>
        public int GetNumberOfItems()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            int numberOfItems = 0;

            cmd.CommandText = "SELECT * FROM Item";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfItems++;
            }

            sqlConnection.Close();

            return numberOfItems;
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
            Inventory playerInventory = GetInventoryByPlayerId(selectedPlayer.Id);

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
                selectedPlayer = new Player(id, pv, force, agility, armor, luck, name, idActualPage, playerInventory);
            }

            if (!isPlayerFound)
                throw new Exception("Player with id " + playerId + " not found in database");
            
            sqlConnection.Close();

            return selectedPlayer;
        }

        /// <summary>
        /// Get inventory values according to player id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Inventory object</returns>
        public Inventory GetInventoryByPlayerId(int playerId)
        {
            Inventory selectedInventory = new Inventory(GetNumberOfItems());

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Player_Item WHERE idPlayer = " + playerId;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                selectedInventory.SetItem(int.Parse(reader["idItem"].ToString()), int.Parse(reader["quantity"].ToString()));
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
