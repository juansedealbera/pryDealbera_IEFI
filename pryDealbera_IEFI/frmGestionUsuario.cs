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
        private int IdSeleccionado = 0;

        private void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            conexion.ConectarBD();
            conexion.ListarBD(dgvGrilla);
            conexion.CargarCargos(cmbCargo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cargo.");
                return;
            }

            int idCargo = Convert.ToInt32(cmbCargo.SelectedValue);
            string nombre = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            string correo = txtCorreo.Text;
            string telefono = txtNumero.Text;

            clsUsuario nuevoUsuario = new clsUsuario(0, idCargo, nombre, contraseña, correo, telefono);

            conexion.Agregar(nuevoUsuario);
            conexion.ListarBD(dgvGrilla);
            limpiarCampos();

            btnModificar.Enabled = true;
            btnEliminar1.Enabled = true;
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count > 0)
            {

                if (cmbCargo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un cargo.");
                    return;
                }

                int idCargo = Convert.ToInt32(cmbCargo.SelectedValue);
                string nombre = txtUsuario.Text;
                string contraseña = txtContraseña.Text;
                string correo = txtCorreo.Text;
                string telefono = txtNumero.Text;

                clsUsuario usuario = new clsUsuario(IdSeleccionado, idCargo, nombre, contraseña, correo, telefono);

                conexion.Modificar(usuario);
                conexion.ListarBD(dgvGrilla);
            }
            else
            {
                MessageBox.Show("Seleccioná un usuario de la grilla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentRow != null)
            {
                int codigoSeleccionado = Convert.ToInt32(dgvGrilla.CurrentRow.Cells["Id"].Value);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    conexion.Eliminar(codigoSeleccionado);
                    conexion.ListarBD(dgvGrilla);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccioná una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            limpiarCampos();
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(nombreBuscado))
            {
                MessageBox.Show("Por favor ingrese un nombre para realizar la búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conexion.BuscarPorNombre(nombreBuscado, dgvGrilla);

            txtBuscar.Text = " ";
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            conexion.ListarBD(dgvGrilla);
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvGrilla.Rows[e.RowIndex];

                IdSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

                cmbCargo.SelectedValue = fila.Cells["IdCargo"].Value;
                txtUsuario.Text = fila.Cells["Nombre"].Value.ToString();
                txtContraseña.Text = fila.Cells["Contraseña"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtNumero.Text = fila.Cells["NumeroContacto"].Value.ToString();

            }
        }
        
        public void limpiarCampos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtCorreo.Clear();
            txtNumero.Clear();
        }
    
    }
}
