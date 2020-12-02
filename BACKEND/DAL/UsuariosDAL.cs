using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BACKEND.DAO;

namespace BACKEND.DAL
{
    public class UsuariosDAL
    {


        public UsuariosDAL() { }


        /// <summary>
        /// Este metodo comprueba que existe un usuario en la base de datos, en caso de que lo haya regresa un valor verdadero. 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenasegura"></param>
        /// <returns>id del empleado</returns>
        public int iniciarSesion(String usuario, String contrasenasegura) {
            MySqlConnection conexion = new conexion().conectar();

            MySqlCommand cmd = new MySqlCommand("select * from empleados where Nombre = '" + usuario + "' and password = md5('" + contrasenasegura + "');", conexion);
            MySqlDataReader lector = cmd.ExecuteReader();

            int id = 0;
            String res = null;
            while (lector.Read())
            {
               id = Convert.ToInt32(lector.GetValue(0).ToString());
               res  = lector.GetValue(1).ToString();
              

            }


            if (res==null)
            {
                return -1;
            }
            else
            {
                return id;
            }


        }



        /// <summary>
        /// Metodo para traer todos los empleados registrados.
        /// </summary>
        /// <returns>Lista de todos los empleados</returns>

        public List<EmpleadoDAO> LlenarEmpleados()
        {
            MySqlConnection conexion = new conexion().conectar();
            List<EmpleadoDAO> empleados = new List<EmpleadoDAO>();
            String consulta = "select * from empleados;";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);


            MySqlDataReader lector = cm.ExecuteReader();
            while (lector.Read())
            {
                EmpleadoDAO e = new EmpleadoDAO();
                e.id = Convert.ToInt32(lector.GetValue(0));
                e.nombre = lector.GetValue(1).ToString();
                e.password = lector.GetValue(2).ToString();
                e.privilegios = Convert.ToInt32(lector.GetValue(3));


                empleados.Add(e);
            }

            return empleados;

        }


        /// <summary>
        /// metodo para buscar un empleado mediante su id.
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <returns>Retorna el empleado que coincide con la entrada</returns>

        public EmpleadoDAO getOne(int id)
        {
            MySqlConnection conexion = new conexion().conectar();
            List<EmpleadoDAO> empleados = new List<EmpleadoDAO>();
            String consulta = "select * from empleados where idempleados = "+id+";";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);

            EmpleadoDAO e = new EmpleadoDAO();
            MySqlDataReader lector = cm.ExecuteReader();
            while (lector.Read())
            {
           
                e.id = Convert.ToInt32(lector.GetValue(0));
                e.nombre = lector.GetValue(1).ToString();
                e.password = lector.GetValue(2).ToString();
                e.privilegios = Convert.ToInt32(lector.GetValue(3));

                empleados.Add(e);
            }
            return e;
            

        }



    }
}
