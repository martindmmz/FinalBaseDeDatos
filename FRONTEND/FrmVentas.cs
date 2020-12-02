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
    public partial class FrmVentas : Form
    {

        /// <summary>
        /// La lista de productos es la 
        /// </summary>
        int id_empleado;
        List<ProductosDAO> productos;
        List<ProductosDAO> productosvendidos = new List<ProductosDAO>();
        double total;
        public FrmVentas(int id_usuario)
        {
            InitializeComponent();
            productos = new ProductosDAL().listarProductos();
            dgv_productos.DataSource = productos;
            CenterToScreen();
            id_empleado = id_usuario;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /// se selecciona el producto.
                int seleccion = Convert.ToInt32(dgv_productos.CurrentCell.RowIndex.ToString());

                //se comprueba el tipo de precio que se dará 0=unitario 1=medio mayoreo 2 = mayoreo
                if (cbx_precio.SelectedIndex == 0)
                {
                    total = total + productos[seleccion].precioUnitario * Convert.ToInt32(txt_cantidad.Text);
                    lbl_total.Text = "" + total;
                    productos[seleccion].cantidad = Convert.ToInt32(txt_cantidad.Text);
                    productosvendidos.Add(productos[seleccion]);

          

                }
                else if (cbx_precio.SelectedIndex == 1)
                {
                    total = total + productos[seleccion].precioMedioMayoreo * Convert.ToInt32(txt_cantidad.Text);
                    lbl_total.Text = "" + total;
                    productos[seleccion].cantidad = Convert.ToInt32(txt_cantidad.Text);
                    productosvendidos.Add(productos[seleccion]);
                }
                else if (cbx_precio.SelectedIndex == 2)
                {
                    total = total + productos[seleccion].precioMayoreo * Convert.ToInt32(txt_cantidad.Text);
                    lbl_total.Text = "" + total;
                    productos[seleccion].cantidad = Convert.ToInt32(txt_cantidad.Text);
                    productosvendidos.Add(productos[seleccion]);
                }


            }
            catch
            {
                MessageBox.Show("Asegurate de seleccionar e ingresar datos correctos");

            }
         

        }
        /// <summary>
        /// Boton que genera la venta, reinicia los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VentaDAO v = new VentaDAO();
                v.total = total;
                v.idEmpleado = id_empleado;

                new VentasDAL().agregarVenta(v, productosvendidos);
                productosvendidos = new List<ProductosDAO>();
                total = 0;
                lbl_total.Text = "0";
                txt_cantidad.Text = "";
                MessageBox.Show("Venta generada de forma exitosa.");
            }
            catch
            {
                MessageBox.Show("No se pudo generar la venta.");
            }

        }
        /// <summary>
        /// Boton que genera los reportes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            Reportes c = new Reportes(id_empleado);
            c.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProductos v = new FrmProductos(id_empleado);
            v.Show();
            this.Hide();
        }
    }
}
