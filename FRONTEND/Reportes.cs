using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRONTEND
{
    public partial class Reportes : Form
    {
        int id_usuario;
        public Reportes(int id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmReporteEmpleados f = new FrmReporteEmpleados();
            f.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteVentas v = new FrmReporteVentas();
            v.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmVentas d = new FrmVentas(id_usuario);
            d.Show();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }
    }
}
