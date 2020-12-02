using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BACKEND.DAL;
using BACKEND.DAO;

namespace FRONTEND
{
    public partial class FrmProductos : Form
    {
        //id del empleado y la seleccion de la lista
        
        int id_usuario;
        int seleccion_eliminar;
        List<ProductosDAO> productos;
        public FrmProductos(int id_usuario)
        {
            InitializeComponent();
            CenterToScreen();
            this.id_usuario = id_usuario;
            productos = new ProductosDAL().listarProductos();
            dgv_productos.DataSource = productos;

            

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Elimina el producto, tomando la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            try
            {
                seleccion_eliminar = Convert.ToInt32(dgv_productos.CurrentCell.RowIndex.ToString());
            }
            catch{
                MessageBox.Show("Selecciona la fila del producto antes de continuar.");
            }


            if (new ProductosDAL().eliminarProducto(productos[seleccion_eliminar].codigo) > 0)
            {
                MessageBox.Show("Producto eliminado con éxito.");
                productos = new ProductosDAL().listarProductos();
                dgv_productos.DataSource = productos;


            }
            else {
                MessageBox.Show("No se pudo eliminar el producto.");
            }


        }
        /// <summary>
        /// Edita el producto tomandolo de la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                int seleccion_editar = Convert.ToInt32(dgv_productos.CurrentCell.RowIndex.ToString());
                FrmAgregarProducto F = new FrmAgregarProducto(1,productos[seleccion_editar],id_usuario);
                F.Show();
                this.Hide();
                
            }
            catch
            {
                MessageBox.Show("Selecciona la fila del producto antes de continuar.");
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto c = new FrmAgregarProducto(0,new ProductosDAO(), id_usuario);
            c.Show();
            this.Hide();
        }


        /// <summary>
        /// Abre una instancia de las ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            FrmVentas f = new FrmVentas(id_usuario);
            f.Show();
            this.Hide();
        }
    }
}
