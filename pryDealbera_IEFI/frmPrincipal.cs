using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDealbera_IEFI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Tiempo en que se inició sesión
        private DateTime tiempoInicio;
        public string UsuarioActivo { get; set; }
        public string CargoUsuario { get; set; }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Guardamos el momento en que se inició la sesión
            tiempoInicio = DateTime.Now;

            // Mostrar el nombre del usuario (debe haberse asignado antes de abrir este formulario)
            lblUser.Text = $"Usuario: {UsuarioActivo}";

            // Iniciar el Timer
            timer.Interval = 1000; // 1 segundo
            timer.Start();

            // Control de acceso por cargo
            if (CargoUsuario == "Operador")
            {
                administraciónToolStripMenuItem.Enabled = false;
            }

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionUsuario x = new frmGestionUsuario();
            x.ShowDialog();
        }

        private void auditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoria x = new frmAuditoria();
            x.ShowDialog();
        }

        private void registrarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTareas x = new frmTareas();
            x.ShowDialog();
        }

        private void historialTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaTareas x = new frmListaTareas();
            x.ShowDialog();
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            // Mostrar fecha y hora actual
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Calcular tiempo de sesión
            TimeSpan tiempoSesion = DateTime.Now - tiempoInicio;
            lblTiempo.Text = $"Tiempo activo: {tiempoSesion:hh\\:mm\\:ss}";
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                timer.Stop();
                GuardarRegistroSesion();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void GuardarRegistroSesion()
        {
            TimeSpan duracion = DateTime.Now - tiempoInicio;

            // Aquí podés guardar en la base de datos
            using (SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Auditoria;Trusted_Connection=True;"))
            {
                string query = "INSERT INTO Sesiones (Usuario, FechaInicio, FechaFin, Duracion) VALUES (@usuario, @inicio, @fin, @duracion)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", UsuarioActivo);
                cmd.Parameters.AddWithValue("@inicio", tiempoInicio);
                cmd.Parameters.AddWithValue("@fin", DateTime.Now);
                cmd.Parameters.AddWithValue("@duracion", duracion.ToString(@"hh\:mm\:ss"));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CargoUsuario == "Operador")
            {
                MessageBox.Show("No tienes acceso a esta sección. Siga con las tareas asignadas o contacte a un administrador si cree que esto es un error.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
