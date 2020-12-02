using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BACKEND.DAL
{

    /// <summary>
    /// clase de conexion a la base de datos. 
    /// </summary>
   public class conexion
    {
        string servidor = "localhost";
        string bd = "finalbd";
        string usuario = "root";
        string password = "root";
        string datos = null;

        public conexion()
        {

        }
        /// <summary>
        /// Método para iniciar la conexión con la base de datos y devolverla. 
        /// </summary>
        public MySqlConnection conectar()
        {

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            conexion.Open();

            return conexion;
        }

    }
}
