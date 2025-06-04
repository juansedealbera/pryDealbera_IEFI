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

        private void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            conexion.ConectarBD();
            conexion.ListarBD(dgvGrilla);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
              int cargo = Convert.ToInt32(cmbCargo.SelectedValue);
              string Nombre = txtUsuario.Text;
              string Contraseña = txtContraseña.Text;
              string Correo = txtCorreo.Text;
              string Telefono = txtNumero.Text;

              clsUsuario nuevoUsuario = new clsUsuario(0, cargo, Nombre, Contraseña, Correo, Telefono);

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
                clsUsuario usuario = new clsUsuario(
                    Convert.ToInt32(dgvGrilla.SelectedRows[0].Cells["Id"].Value),
                    Convert.ToInt32(cmbCargo.SelectedValue),
                    txtUsuario.Text,
                    txtContraseña.Text,
                    txtCorreo.Text,
                    txtNumero.Text
                );

                clsConexionBD objConexion = new clsConexionBD();
                objConexion.Modificar(usuario);

                objConexion.ListarBD(dgvGrilla);
            }
            else
            {
                MessageBox.Show("Seleccioná un producto para modificar.");
            }
            limpiarCampos();
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentRow != null)
            {
                //valor del código desde la fila seleccionada
                int codigoSeleccionado = Convert.ToInt32(dgvGrilla.CurrentRow.Cells["Id"].Value);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    clsConexionBD conexion = new clsConexionBD();

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
