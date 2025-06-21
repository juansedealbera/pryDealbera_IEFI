using System;
using System.Collections;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '●';
            //btnVer.Image = Properties.Resources.imgOjoCerrado;
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Auditoria;Trusted_Connection=True;";
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @Usuario AND Contraseña = @Contraseña";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                    comando.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = contraseña;

                    conexion.Open();
                    int coincidencias = (int)comando.ExecuteScalar();

                    if (coincidencias > 0)
                    {
                        // Consultamos el IdCargo
                        string queryCargo = "SELECT IdCargo FROM Usuarios WHERE Nombre = @Usuario AND Contraseña = @Contraseña";
                        using (SqlCommand cmdCargo = new SqlCommand(queryCargo, conexion))
                        {
                            cmdCargo.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                            cmdCargo.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = contraseña;

                            object result = cmdCargo.ExecuteScalar();

                            if (result != null)
                            {
                                int idCargo = Convert.ToInt32(result);

                                MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Creamos y mostramos el formulario principal
                                frmPrincipal principal = new frmPrincipal();
                                principal.UsuarioActivo = usuario;
                                principal.cargoUsuario = idCargo;
                                principal.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo obtener el cargo del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '●')
            {
                txtContraseña.PasswordChar = '\0';
                btnVer.Image = Properties.Resources.;
            }
            else
            {
                txtContraseña.PasswordChar = '●';
                btnVer.Image = Properties.Resources.imgOjoCerrado;
            }
        }
    }
}
