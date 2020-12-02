using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BACKEND.DAO;
using BACKEND.DAL;
using System.Data;

namespace BACKEND.DAL
{
    public class VentasDAL
    {
        /// <summary>
        /// Método que registra la venta y los detalles de esta mediante una transacción
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="productos"></param>
        /// <returns>Retorta un booleano para confirmar que se pudo ingresar la venta y sus detalles</returns>
        public bool agregarVenta(VentaDAO venta, List<ProductosDAO> productos)
        {
            MySqlConnection conexion = new conexion().conectar();
            MySqlCommand cm = new MySqlCommand();

            MySqlTransaction transaction = null;
          
                
                transaction = conexion.BeginTransaction();
                cm.Connection = conexion;
                cm.Transaction = transaction;
                cm.CommandText = "insert into ventas values(@id,@total,@idempleado,@fecha);";
                cm.Parameters.AddWithValue("@total", venta.total);
                cm.Parameters.AddWithValue("@idempleado", venta.idEmpleado);
                cm.Parameters.AddWithValue("@fecha", obtenerFecha());
            cm.Parameters.AddWithValue("@id", ventaUltimoID()+1);
            cm.ExecuteNonQuery();


         

            foreach (ProductosDAO p in productos)
                {
                
                    cm.CommandText = "insert into detalleventas values(null," + ventaUltimoID() + ",'" + p.codigo + "'," + p.cantidad + ");";
                    cm.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;


        }

        /// <summary>
        /// Se Usa para obtener el tiempo actual e insertarlo en la venta
        /// </summary>
        /// <returns>Fecha y hora actuales</returns>
        public String obtenerFecha()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

       /// <summary>
       /// Busca las ventas de cada empleado durante un mes y año fijos
       /// </summary>
       /// <param name="id_empleado">id del emppleado</param>
       /// <param name="mes">Mes de las ventas</param>
       /// <param name="anio">año de las ventas</param>
       /// <returns>Lista de las ventas realizadas</returns>
       
        public List<VentaDAO> reporteVentasAnio(int id_empleado, int mes, int anio)
        {
            MySqlConnection conexion = new conexion().conectar();
            List<VentaDAO> ventas  = new List<VentaDAO>();
            String consulta = "select * from ventas where idEmpleado ="+id_empleado+" and month(dia) ='"+mes+"'"+"and year(dia)='"+anio+ "';";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);


            MySqlDataReader lector = cm.ExecuteReader();
            while (lector.Read())
            {
                VentaDAO v = new VentaDAO();
                v.id_venta = Convert.ToInt32(lector.GetValue(0));
                v.total = Convert.ToDouble(lector.GetValue(1));
                v.idEmpleado = Convert.ToInt32(lector.GetValue(2));
                v.fecha = Convert.ToDateTime(lector.GetValue(3));

                ventas.Add(v);
                
            }

            return ventas;

        }




        /// <summary>
        /// Se usa para ver el ultimo ID de la venta y agregarlo al detalle.
        /// </summary>
        /// <returns>Ultimo ID de las ventas</returns>

    
        public int ventaUltimoID()
        {
            MySqlConnection con = new conexion().conectar();
            try
            {
             
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select IDVentas from ventas order by IdVentas DESC;";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                DataRow row = tabla.Rows[0];
                int id = int.Parse(row["idVentas"].ToString());
                con.Close();
                return id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Metodo usado para generar el reporte de las ventas en un perido
        /// </summary>
        /// <param name="inicio">La fecha inicial del periodo.</param>
        /// <param name="final">La fecha final del periodo.</param>
        /// <returns>Lista de las ventas</returns>
        public List<VentaDAO> reporteVentasPeriodo(String inicio,String final)
        {
            MySqlConnection conexion = new conexion().conectar();
            List<VentaDAO> ventas = new List<VentaDAO>();
            String consulta = "select * from ventas where dia between '" + inicio + "' and '"+final+"';";


            MySqlCommand cm = new MySqlCommand(consulta, conexion);


            MySqlDataReader lector = cm.ExecuteReader();
            while (lector.Read())
            {
                VentaDAO v = new VentaDAO();
                v.id_venta = Convert.ToInt32(lector.GetValue(0));
                v.total = Convert.ToDouble(lector.GetValue(1));
                v.idEmpleado = Convert.ToInt32(lector.GetValue(2));
                v.fecha = Convert.ToDateTime(lector.GetValue(3));

                ventas.Add(v);

            }

            return ventas;

        }










    }

}
