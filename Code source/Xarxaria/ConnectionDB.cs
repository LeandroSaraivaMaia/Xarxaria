using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Xarxaria
{
    class ConnectionDB
    {
        string[] itemLists;
        SqlConnection sqlConnection;

        /// <summary>
        /// Connection to the DB in the constructor
        /// </summary>
        public ConnectionDB(string[] itemLists)
        {
            //string connectionString = @"Network Library=dbmssocn; Data Source=localhost, 1401; database=XarxariaDB; " + @"User id=xarxariaLogin; Password=Pa$$w0rd;";
            string connectionString = "Data Source=localhost; Initial Catalog=XarxariaDB; User ID=xarxariaLogin; Password=Pa$$w0rd";
            sqlConnection = new SqlConnection(connectionString);

            this.itemLists = itemLists;
        }

        #region Add query
        /// <summary>
        /// Add a player in the database
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="hp">Number of Health Points</param>
        /// <param name="force">Number of force</param>
        /// <param name="agility">Number of force</param>
        /// <param name="chance">Number of force</param>
        /// <param name="idInventory">Inventory id of the player</param>
        public void AddPlayer(string name, int hp, int force, int agility, int chance, int idInventory)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Player (pv, force, armor ,agility, name, idActualPage, idInventory) VALUES ("+hp+", "+force+", "+1+", "+agility+", "+name+", "+1+", "+idInventory+")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
        #endregion

        #region Select query
        //Get player according to his id
        public Player GetPlayer(int playerId)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            Player selectedPlayer = new Player();

            cmd.CommandText = "SELECT * FROM Player WHERE id = " + playerId;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Get all data of the player
                int id = int.Parse(reader["id"].ToString());
                int pv = int.Parse(reader["pv"].ToString());
                int force = int.Parse(reader["force"].ToString());
                int armor = int.Parse(reader["armor"].ToString());
                string name = reader["name"].ToString();
                int idActualPage = int.Parse(reader["idActualPage"].ToString());
                int idInventory = int.Parse(reader["idInventory"].ToString());
                selectedPlayer = new Player(id, pv, force, armor, name, idActualPage, idInventory);
            }
            
            sqlConnection.Close();

            //Get the inventory of the player
            GetInventory(selectedPlayer.IdInventory);

            return selectedPlayer;
        }

        //Get an inventory according to his id
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
                int[] inventoryValues = new int[itemLists.Length];

                //Get all data of the inventroy
                for (int i = 0; i < itemLists.Length - 1; i++)
                {
                    inventoryValues[i] = int.Parse(reader[itemLists[i]].ToString());
                }

                selectedInventory = new Inventory(inventoryValues);
            }

            sqlConnection.Close();

            return selectedInventory;
        }

        //Get a page according to his id
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
                readedPage = new Page(reader["title"].ToString(), reader["text"].ToString());
            }

            sqlConnection.Close();

            return readedPage;
        }
        #endregion
    }
}
