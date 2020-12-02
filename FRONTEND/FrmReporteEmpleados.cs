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
using BACKEND;
namespace FRONTEND
{
    public partial class FrmReporteEmpleados : Form
    {
        List<EmpleadoDAO> empleados;
        
        public FrmReporteEmpleados()
        {
            InitializeComponent();
            CenterToScreen();
            empleados = new UsuariosDAL().LlenarEmpleados();

            //Se llenan los nombre de los empleados en la combobox

            for (int i=0; i<empleados.Count;i++)
            {
                cbx_empleado.Items.Add(empleados[i].nombre);
            }
            cbx_mes.SelectedIndex = 0;
            cbx_empleado.SelectedIndex = 0;


        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            ///se llena el reporte de la venta con los datos del combobox

            try {
                new generarReportes().reporteVentasEmpleadoMes(empleados[cbx_empleado.SelectedIndex], (cbx_mes.SelectedIndex + 1), Convert.ToInt32(txt_anio.Text));
                MessageBox.Show("Reporte generado con éxito");
            } catch
            {
                MessageBox.Show("Ingresa un año válido.");
            }
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
