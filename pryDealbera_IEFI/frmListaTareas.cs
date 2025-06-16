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
    public partial class frmListaTareas : Form
    {
        public frmListaTareas()
        {
            InitializeComponent();
        }

        clsConexionBD conexion = new clsConexionBD();

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            //conexion.ListarBD(dgvGrilla);
            conexion.ListarTareas(dgvGrilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tareaBuscada = txtBuscarTarea.Text.Trim();

            if (string.IsNullOrEmpty(tareaBuscada))
            {
                MessageBox.Show("Por favor ingrese un nombre para buscar.");
                return;
            }

            conexion.BuscarPorTarea(tareaBuscada, dgvGrilla);
            txtBuscarTarea.Clear(); // Limpia el campo luego de buscar
        }

        private void frmListaTareas_Load(object sender, EventArgs e)
        {
            conexion.ListarTareas(dgvGrilla);
        }

        private void txtBuscarTarea_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
