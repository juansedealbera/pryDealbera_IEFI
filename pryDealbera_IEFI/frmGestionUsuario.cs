using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDealbera_IEFI
{
    public partial class frmGestionUsuario : Form
    {
        public frmGestionUsuario()
        {
            InitializeComponent();
        }

        clsConexionBD conexion = new clsConexionBD();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
              string Nombre = txtUsuario.Text;
              string Contraseña = txtContraseña.Text;
              string Correo = txtCorreo.Text;
              string Telefono = txtNumero.Text;

              clsUsuario nuevoUsuario = new clsUsuario(0, Nombre, Contraseña, Correo, Telefono);

              conexion.Agregar(nuevoUsuario);
              conexion.ListarBD(dgvGrilla);

              txtUsuario.Clear();
              txtContraseña.Clear();
              txtCorreo.Clear();
              txtNumero.Clear();

              btnModificar.Enabled = true;
              btnEliminar1.Enabled = true;
            
        }

        private void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            conexion.ConectarBD();
            conexion.ListarBD(dgvGrilla);
        }
    }
}
