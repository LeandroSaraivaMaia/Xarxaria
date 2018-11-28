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
        SqlConnection sqlConnection;

        /// <summary>
        /// Connection to the DB in the constructor
        /// </summary>
        public ConnectionDB()
        {
            string connectionString = @"Network Library=dbmssocn; Data Source=localhost, 1401; database=XarxariaDB; " + @"User id=xarxariaLogin; Password=Pa$$w0rd;";
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
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            sqlConnection.Close();
        }

        #endregion

        #region Selete query

        #endregion
    }
}
