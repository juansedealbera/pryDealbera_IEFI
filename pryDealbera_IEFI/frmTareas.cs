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
    public partial class frmTareas : Form
    {
        public frmTareas()
        {
            InitializeComponent();
        }

        clsConexionBD conexion = new clsConexionBD();

        private void frmTareas_Load(object sender, EventArgs e)
        {
            conexion.cargarTareas(cmbTareas);
            conexion.cargarLugares(cmbLugares);
            dtpFecha.MaxDate = DateTime.Today;
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                clsRegistro registro = new clsRegistro();

                registro.Fecha = dtpFecha.Value;
                registro.IdTarea = Convert.ToInt32(cmbTareas.SelectedValue);
                registro.IdLugar = Convert.ToInt32(cmbLugares.SelectedValue);
                registro.Insumo = chkInsumo.Checked;
                registro.Vacaciones = chkVacaciones.Checked;
                registro.Estudio = chkEstudio.Checked;
                registro.Salario = chkSalarial.Checked;
                registro.Recibo = chkRecibo.Checked;
                registro.Comentario = txtComentario.Text;

                clsConexionBD conexion = new clsConexionBD();
                conexion.agregarTarea(registro);

                MessageBox.Show("Tarea agregada correctamente.");
                CargarGrilla();
                LimpiarControles(); // Si tenés un método para limpiar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la tarea: " + ex.Message);
            }
        }

        private void CargarGrilla()
        {
            DataTable tabla = conexion.obtenerTareas();
            dgvGrilla.DataSource = tabla;
        }

        private void LimpiarControles()
        {
            dtpFecha.Value = DateTime.Today;
            cmbTareas.SelectedIndex = -1;
            cmbLugares.SelectedIndex = -1;
            chkInsumo.Checked = false;
            chkVacaciones.Checked = false;
            chkEstudio.Checked = false;
            chkSalarial.Checked = false;
            chkRecibo.Checked = false;
            txtComentario.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
