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
        string name = "";
        int pv = 0;
        int force = 0;
        int agility = 0;
        int chance = 0;
        int idInventory = 0;
        int idPage = 0;

        SqlConnection sqlConnection;

        /// <summary>
        /// Connection to the DB in the constructor
        /// </summary>
        public ConnectionDB()
        {
            //string connectionString = @"Network Library=dbmssocn; Data Source=localhost, 1401; database=XarxariaDB; " + @"User id=xarxariaLogin; Password=Pa$$w0rd;";
            string connectionString = "Data Source=localhost; Initial Catalog=XarxariaDB; User ID=xarxariaLogin; Password=Pa$$w0rd";
            sqlConnection = new SqlConnection(connectionString);
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
            // Select data
            this.name = name;
            this.pv = hp;
            this.force = force;
            this.agility = agility;
            this.chance = chance;
            this.idInventory = idInventory;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO Player (pv, force, armor ,agility, name, idActualPage, idInventory) VALUES (pv, force, 1, agility, name, 1, idInventory)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            sqlConnection.Close();
        }

        #endregion

        #region Select query

        public string ReadPlayer()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Player";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            string text = "";

            while (reader.Read())
            {
                text += " ; "  + reader["name"].ToString();
            }

            sqlConnection.Close();

            return text;
        }

        // Sélectionner une seule page selon so id
        public Page ReadPage (int idPage)
        {
            Page readedPage = new Page();
            this.idPage = idPage;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Page WHERE id = " + idPage;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            string text = "";

            while (reader.Read())
            {
                text += " ; " + reader["title"].ToString() + reader["text"].ToString();
                readedPage = new Page(reader["title"].ToString(), reader["text"].ToString());
            }

            sqlConnection.Close();

            return readedPage;
        }

        #endregion
    }
}
