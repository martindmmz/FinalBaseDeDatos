using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND.DAO;
using MySql.Data.MySqlClient;

namespace BACKEND.DAL
{
    public class ProductosDAL
    {
        public ProductosDAL() { }

        /// <summary>
        /// Metodo para listar todos los productos
        /// </summary>
        /// <returns>Lista de los productos</returns>
        public List<ProductosDAO> listarProductos() {
            MySqlConnection conexion = new conexion().conectar();

            List<ProductosDAO> productos = new List<ProductosDAO>();

            String consulta = "select * from productos";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);


            MySqlDataReader lector = cm.ExecuteReader();
            while (lector.Read())
            {
                ProductosDAO p = new ProductosDAO();

                p.codigo = lector.GetValue(0).ToString();
                p.nombre = lector.GetValue(1).ToString();
                p.existencia = Convert.ToInt32(lector.GetValue(2));
                p.precioUnitario = Convert.ToDouble(lector.GetValue(3).ToString());
                p.precioMedioMayoreo = Convert.ToDouble(lector.GetValue(4).ToString());
                p.precioMayoreo = Convert.ToDouble(lector.GetValue(5).ToString());

                productos.Add(p);



            }



            return productos;
        }

        /// <summary>
        /// Metodo con un procedimiento almacenado para eliminar un producto
        /// </summary>
        /// <param name="codigo">codigo del producto a eliminar</param>
        /// <returns>1 si se ejecutó correctamente 0 sino se pudo eliminar</returns>
        public int eliminarProducto(String codigo){
            MySqlConnection conexion = new conexion().conectar();

            List<ProductosDAO> productos = new List<ProductosDAO>();

            String consulta = "call EliminarProducto('" + codigo + "');";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);
            return cm.ExecuteNonQuery();

        }


        /// <summary>
        /// Metodo con un procedimiento almacenado para agregar un producto
        /// </summary>
        /// <param name="codigo">producto a insertar en la tabla</param>
        /// <returns>1 si se ejecutó correctamente 0 sino se pudo agregar</returns>
        public int registrarProducto(ProductosDAO p)
        {
            MySqlConnection conexion = new conexion().conectar();
           
            List<ProductosDAO> productos = new List<ProductosDAO>();

            String consulta = "call agregarProducto('" + p.codigo + "','"+p.nombre+"',"+p.existencia+","+p.precioUnitario+","+p.precioMedioMayoreo+","+p.precioMayoreo+");";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);
            return cm.ExecuteNonQuery();

        }

        /// <summary>
        /// Metodo con un procedimiento almacenado para editar un producto
        /// </summary>
        /// <param name="codigo">producto a insertar en la tabla y su codigo anterior.</param>
        /// <returns>1 si se ejecutó correctamente 0 sino se pudo editar</returns>
        public int editarProducto(String codigo, ProductosDAO p)
        {
            MySqlConnection conexion = new conexion().conectar();

            List<ProductosDAO> productos = new List<ProductosDAO>();

            String consulta = "call actualizarProducto('" + codigo + "','" + p.codigo + "','" + p.nombre + "'," + p.existencia + "," + p.precioUnitario + "," + p.precioMedioMayoreo + "," + p.precioMayoreo + ");";
            MySqlCommand cm = new MySqlCommand(consulta, conexion);
            return cm.ExecuteNonQuery();

        }

    }
}
