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
using BACKEND;
using BACKEND.DAO;

namespace FRONTEND
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /// Se elecciona el periodo y se le da el formato necesario

            try
            {

                String[] fecha_final = date_final.Value.ToString().Split(' ');
                String[] fecha_inicio = date_inicio.Value.ToString().Split(' ');
                string[] fechainicial = fecha_inicio[0].Split('/');
                string[] fechafinal = fecha_final[0].Split('/');


                new generarReportes().reporteVentasPeriodo(fechainicial[2] + "-" + fechainicial[1] + "-" + fechainicial[0], fechafinal[2] + "-" + fechafinal[1] + "-" + fechafinal[0]);
                MessageBox.Show("Reporte generado con éxito.");

            }
            catch
            {
                MessageBox.Show("No se pudo generar el reporte..");

            }




        }
    }
}
