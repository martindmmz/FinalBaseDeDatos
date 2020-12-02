using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BACKEND.DAO;
using BACKEND.DAL;

namespace FRONTEND
{
    public partial class FrmAgregarProducto : Form
    {
        int id_usuario; 
        int funcion;
        String codigo_p;
        public FrmAgregarProducto(int funcion, ProductosDAO p, int id_usuario)
        {
            InitializeComponent();
            this.funcion = funcion;
            CenterToScreen();
            this.codigo_p= p.codigo;
            this.id_usuario = id_usuario;
            /// Si se recibe un uno el formulario llena los datos del producto para realizar su edición
            if (funcion == 1)
            {

                lbl_titulo.Text = "Editar producto";
                button2.Text = "Editar";

                txt_codigo.Text = p.codigo;
                txt_existencia.Text = "" + p.existencia;
                txt_mayoreo.Text = "" + p.precioMayoreo;
                txt_nombre.Text = p.nombre;
                txt_punitario.Text = "" + p.precioUnitario;
                txt_pmmayoreo.Text = "" + p.precioMedioMayoreo;


            }

        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                /// Si la funcion es 0 se realizar una insersión.
                if (funcion == 0)
                {

                    if (txt_codigo.Text.Length > 4)
                    {
                        MessageBox.Show("El código debe tener una longitud de máximo 4 digitos.");
                    }
                    else
                    {
                        /// Se crea el producto y se envia a la funcion para se agregada
                        ProductosDAO p = new ProductosDAO();
                        p.codigo = txt_codigo.Text;
                        p.nombre = txt_nombre.Text;
                        p.precioMayoreo = Convert.ToDouble(txt_mayoreo.Text);
                        p.precioMedioMayoreo = Convert.ToDouble(txt_pmmayoreo.Text);
                        p.precioUnitario = Convert.ToDouble(txt_punitario.Text);
                        p.existencia = Convert.ToInt32(txt_existencia.Text);

                        if (new ProductosDAL().registrarProducto(p) > 0)
                        {

                            MessageBox.Show("Producto registrado correctamente");
                            this.Dispose();
                            FrmProductos f = new FrmProductos(id_usuario);
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("No fue posible agregar el producto.");
                        }
                    }

                }
                else {

                    /// Se crea el producto y se envia a la funcion para ser editado
                    ProductosDAO p = new ProductosDAO();
                    p.codigo = txt_codigo.Text;
                    p.nombre = txt_nombre.Text;
                    p.precioMayoreo = Convert.ToDouble(txt_mayoreo.Text);
                    p.precioMedioMayoreo = Convert.ToDouble(txt_pmmayoreo.Text);
                    p.precioUnitario = Convert.ToDouble(txt_punitario.Text);
                    p.existencia = Convert.ToInt32(txt_existencia.Text);

                    if (new ProductosDAL().editarProducto(codigo_p, p) > 0)
                    {

                        MessageBox.Show("Producto actualizado correctamente");
                        this.Dispose();
                        FrmProductos f = new FrmProductos(id_usuario);
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible editar el producto.");
                    }




                }
            }
            catch
            {
                MessageBox.Show("Has ingresado un dato erronéo");
            }


        }
    }
}
