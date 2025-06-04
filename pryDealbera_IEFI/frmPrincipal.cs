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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Tiempo en que se inició sesión
        private DateTime tiempoInicio;
        public string UsuarioActivo { get; set; }

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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Guardamos el momento en que se inició la sesión
            tiempoInicio = DateTime.Now;

            // Mostrar el nombre del usuario (debe haberse asignado antes de abrir este formulario)
            lblUser.Text = $"Usuario: {UsuarioActivo}";

            // Iniciar el Timer
            timer.Interval = 1000; // 1 segundo
            timer.Start();
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            // Mostrar fecha y hora actual
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Calcular tiempo de sesión
            TimeSpan tiempoSesion = DateTime.Now - tiempoInicio;
            lblTiempo.Text = $"Tiempo activo: {tiempoSesion:hh\\:mm\\:ss}";
        }
    }
}
