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

        clsConexionBD conexionBD = new clsConexionBD();

        // Tiempo en que se inició sesión
        private DateTime tiempoInicio;
        public string UsuarioActivo { get; set; }
        private clsUsuario usuarioLog;

        private string nombreUsuario;
        private int cargoUsuario;
        private DateTime Fecha;
        private DateTime horaInicio;
        private DateTime horaFin;
        private TimeSpan tiempoTranscurrido;

        private int tiempoActual = 0;

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            horaInicio = DateTime.Now;
            Fecha = horaInicio.Date;
            nombreUsuario = UsuarioActivo;
            timer.Start();

            // Guardamos el momento en que se inició la sesión
            tiempoInicio = DateTime.Now;

            lblUser.Text = $"Usuario: {UsuarioActivo}";

            timer.Interval = 1000; // 1 segundo
            timer.Start();

            if(usuarioLog.cargo == 2)
            {
                mnuUsuarios.Visible = false;
                mnuAuditoria.Visible = false;
            }

        }

        //Opciones Menu
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

        //control tiempo
        private void timer_Tick_1(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            //Calcular tiempo de sesión
            TimeSpan tiempoSesion = DateTime.Now - tiempoInicio;
            lblTiempo.Text = $"Tiempo activo: {tiempoSesion:hh\\:mm\\:ss}";
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            nombreUsuario = UsuarioActivo;

            timer.Enabled = false;

            horaFin = DateTime.Now;
            tiempoTranscurrido = horaFin - horaInicio;

            int idUsuario = conexionBD.ObtenerIdUsuario(nombreUsuario);

            clsAuditoriaSesiones sesion = new clsAuditoriaSesiones(
                0,
                idUsuario,
                Fecha,
                horaInicio,
                horaFin,
                tiempoTranscurrido
            );

            conexionBD.GuardarSesion(sesion);
        }
    
    }
}
