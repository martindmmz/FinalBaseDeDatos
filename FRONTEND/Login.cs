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




namespace FRONTEND
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id_usuario = new UsuariosDAL().iniciarSesion(txt_user.Text, txt_password.Text);
            if (id_usuario != -1) { 
            
                FrmVentas ventas = new FrmVentas(id_usuario);
                ventas.Show();
                this.Hide();
                MessageBox.Show("Has ingresado correctamente.");




            }
            else
            {
               
                MessageBox.Show("No estás registrado, registrate de manera correcta en el botón de abajo.");

            }


        }
    }
}
