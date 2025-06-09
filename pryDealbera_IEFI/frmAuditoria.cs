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
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
        }

        clsConexionBD conexion = new clsConexionBD();
        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            conexion.ConectarBD();
            conexion.ListarSesiones(dgvGrilla);
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            conexion.ListarBD(dgvGrilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtBuscarLog.Text.Trim();

            if (string.IsNullOrEmpty(nombreBuscado))
            {
                MessageBox.Show("Por favor ingrese un nombre para realizar la búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conexion.BuscarPorNombre(nombreBuscado, dgvGrilla);

            txtBuscarLog.Text = " ";
        }
    }
}
