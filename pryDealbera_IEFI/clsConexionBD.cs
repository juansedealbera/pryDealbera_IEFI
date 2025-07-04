﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace pryDealbera_IEFI
{
    internal class clsConexionBD
    {
        //cadena de conexion
        string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=Auditoria;Trusted_Connection=True;";
        //Server=PC50;Database=Auditoria;Trusted_Connection=True;
        //Server=localhost\\SQLEXPRESS;Database=Auditoria;Trusted_Connection=True;
        private SqlConnection conexion;

        //conector
        SqlConnection coneccionBaseDatos;

        //comando
        SqlCommand comandoBaseDatos;

        public string nombreBaseDeDatos;

        //conexion
        public void ConectarBD()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                // Puedes quitar esto si no deseas mostrar siempre
                MessageBox.Show("Conectado a la base de datos Auditoria correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }

        }

        //mostrar bdd en grilla
        public void ListarBD(DataGridView grilla)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string query = "SELECT Id, IdCargo, Nombre AS Usuario, Correo, Telefono AS NumeroContacto FROM Usuarios ORDER BY Id ASC"; ;

                    SqlCommand comando = new SqlCommand(query, conn);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los usuarios correctamente: " + ex.Message);
            }
        }

        //CRUD
        public void CargarCargos(ComboBox comboBox)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT Id, Nombre FROM Cargos WHERE Nombre IN ('Administrador', 'Operario')";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    comboBox.DataSource = tabla;
                    comboBox.DisplayMember = "Nombre";
                    comboBox.ValueMember = "Id";  // <- ESTO ES CLAVE
                    comboBox.SelectedIndex = -1;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar cargos: " + error.Message);
            }
        }

        public void Agregar(clsUsuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "INSERT INTO Usuarios (IdCargo, Nombre, Contraseña, Correo, Telefono) VALUES (@cargo, @nombre, @contraseña, @correo, @numeroContacto)";

                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@cargo", usuario.cargo);
                    comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                    comando.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                    comando.Parameters.AddWithValue("@correo", usuario.correo);
                    comando.Parameters.AddWithValue("@numeroContacto", usuario.telefono);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Usuario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al agregar usuario: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar(clsUsuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "UPDATE Usuarios SET IdCargo = @cargo, Nombre = @nombre, Contraseña = @contraseña, Correo = @correo, Telefono = @numeroContacto WHERE Id = @id";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@cargo", usuario.cargo);
                    comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                    comando.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                    comando.Parameters.AddWithValue("@correo", usuario.correo);
                    comando.Parameters.AddWithValue("@numeroContacto", usuario.telefono);
                    comando.Parameters.AddWithValue("@id", usuario.Id);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar usuario: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Eliminar un usuario por ID
        public void Eliminar(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "DELETE FROM Usuarios WHERE Id = @id";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un usuario con ese ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar usuario: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fin CRUD


        // Buscar usuarios por nombre (LIKE)
        public void BuscarPorNombre(string nombre, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT Id, Nombre AS Usuario, Correo, Telefono AS NumeroContacto, IdCargo FROM Usuarios WHERE Nombre LIKE @nombre";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar usuarios: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void filtrarCargo(int cargo, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT Id, IdCargo, Nombre AS Usuario, Correo, Telefono AS NumeroContacto FROM Usuarios WHERE IdCargo = @cargo ORDER BY Id ASC";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@cargo", cargo);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar usuarios por cargo: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Metodos Para Auditar
        public void ListarSesiones(DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    u.Nombre AS Usuario,
                    s.Fecha,
                    s.HoraInicio,
                    s.HoraFin,
                    s.TiempoTranscurrido
                FROM 
                    Sesiones s
                INNER JOIN 
                    Usuarios u ON s.IdUsuario = u.Id
                ORDER BY 
                    s.Fecha DESC, s.HoraInicio DESC";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar las sesiones correctamente. Detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarSesionesPorFecha(DateTime fecha, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    u.Nombre AS Usuario,
                    s.Fecha,
                    s.HoraInicio,
                    s.HoraFin,
                    s.TiempoTranscurrido
                FROM 
                    Sesiones s
                INNER JOIN 
                    Usuarios u ON s.IdUsuario = u.Id
                WHERE 
                    CAST(s.Fecha AS DATE) = @Fecha
                ORDER BY 
                    s.Fecha DESC, s.HoraInicio DESC";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Fecha", fecha.Date);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void GuardarSesion(clsAuditoriaSesiones sesion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"INSERT INTO Sesiones 
                             (IdUsuario, Fecha, HoraInicio, HoraFin, TiempoTranscurrido) 
                             VALUES 
                             (@idUsuario, @fechaInicio, @horaInicio, @horaFin, @tiempoTranscurrido)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idUsuario", sesion.IdUsuario);
                        comando.Parameters.AddWithValue("@fechaInicio", sesion.Fecha.Date);
                        comando.Parameters.AddWithValue("@horaInicio", sesion.HoraInicio.TimeOfDay);
                        comando.Parameters.AddWithValue("@horaFin", sesion.HoraFin.TimeOfDay);
                        comando.Parameters.AddWithValue("@tiempoTranscurrido", sesion.TiempoTranscurrido);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al guardar sesión: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int ObtenerIdUsuario(string nombreUsuario)
        {
            int id = -1;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = "SELECT Id FROM Usuarios WHERE Nombre = @nombre";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombreUsuario);

                        object resultado = comando.ExecuteScalar();
                        if (resultado != null)
                        {
                            id = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;

        }
  
        //------------------TAREAS-----------------------------------------------------------------------------------------------------

        //Agregar Tarea a la grilla
        public void agregarTarea(clsRegistro registro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "INSERT INTO Registros (Fecha, IdTarea, IdLugar, Insumo, Vacaciones, Estudio, Salario, Recibo, Comentario) " +
                                      "VALUES (@Fecha, @IdTarea, @IdLugar, @Insumo, @Vacaciones, @Estudio, @Salario, @Recibo, @Comentario)";
                   
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                   
                    comando.Parameters.AddWithValue("@Fecha", registro.Fecha);
                    comando.Parameters.AddWithValue("@IdTarea", registro.IdTarea);
                    comando.Parameters.AddWithValue("@IdLugar", registro.IdLugar);
                    comando.Parameters.AddWithValue("@Insumo", registro.Insumo);
                    comando.Parameters.AddWithValue("@Vacaciones", registro.Vacaciones);
                    comando.Parameters.AddWithValue("@Estudio", registro.Estudio);
                    comando.Parameters.AddWithValue("@Salario", registro.Salario);
                    comando.Parameters.AddWithValue("@Recibo", registro.Recibo);
                    comando.Parameters.AddWithValue("@Comentario", registro.Comentario);
                    
                    //opcion de meter algo en comentario
                    
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar tarea: " + ex.Message);
            }
        }

        public void ListarTareas(DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = "SELECT r.Id, r.Fecha, t.Nombre AS Tarea, l.Nombre AS Lugar, " +
                                   "r.Insumo, r.Vacaciones, r.Estudio, r.Salario, r.Recibo, r.Comentario " +
                                   "FROM Registros r " +
                                   "INNER JOIN Tareas t ON r.IdTarea = t.Id " +
                                   "INNER JOIN Lugares l ON r.IdLugar = l.Id " +
                                   "ORDER BY r.Fecha DESC;";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al listar los registros: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Agrega las tareas a la grilla
        public DataTable obtenerTareas()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = @"
                SELECT 
                    r.Fecha, 
                    t.Nombre AS Tarea, 
                    l.Nombre AS Lugar, 
                    r.Insumo, 
                    r.Vacaciones, 
                    r.Estudio, 
                    r.Salario, 
                    r.Recibo, 
                    r.Comentario
                FROM Registros r
                INNER JOIN Tareas t ON r.IdTarea = t.Id
                INNER JOIN Lugares l ON r.IdLugar = l.Id";

                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las tareas: " + ex.Message);
            }

            return tabla;
        }

        public void cargarTareas(ComboBox Combo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT Id, Nombre FROM Tareas";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    Combo.DataSource = tabla;
                    Combo.DisplayMember = "Nombre";
                    Combo.ValueMember = "Id";
                    Combo.SelectedIndex = -1;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar categorías: " + error.Message);
            }

        }
        public void cargarLugares(ComboBox Combo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT Id, Nombre FROM Lugares";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    Combo.DataSource = tabla;
                    Combo.DisplayMember = "Nombre";
                    Combo.ValueMember = "Id";
                    Combo.SelectedIndex = -1;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar categorías: " + error.Message);
            }

        }

        public void BuscarPorTarea(string nombreTarea, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = "SELECT r.Id, r.Fecha, t.Nombre AS Tarea, l.Nombre AS Lugar, " +
                                   "r.Insumo, r.Vacaciones, r.Estudio, r.Salario, r.Recibo, r.Comentario " +
                                   "FROM Registros r " +
                                   "INNER JOIN Tareas t ON r.IdTarea = t.Id " +   // Relaciona con tabla Tareas
                                   "INNER JOIN Lugares l ON r.IdLugar = l.Id " + // Relaciona con tabla Lugares
                                   "WHERE t.Nombre LIKE @NombreTarea " +         // Filtro por nombre
                                   "ORDER BY r.Fecha DESC;";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@NombreTarea", "%" + nombreTarea + "%");

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por tarea: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarPorFecha(DateTime fecha, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = "SELECT r.Id, r.Fecha, t.Nombre AS Tarea, l.Nombre AS Lugar, " +
                                   "r.Insumo, r.Vacaciones, r.Estudio, r.Salario, r.Recibo, r.Comentario " +
                                   "FROM Registros r " +
                                   "INNER JOIN Tareas t ON r.IdTarea = t.Id " +
                                   "INNER JOIN Lugares l ON r.IdLugar = l.Id " +
                                   "WHERE CAST(r.Fecha AS DATE) = @Fecha " +  // Comparar solo la fecha sin hora
                                   "ORDER BY r.Fecha DESC;";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Fecha", fecha.Date); // Asegura que solo compare la fecha

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarSesionesPorFechaExacta(DateTime fecha, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    u.Nombre AS Usuario,
                    s.Fecha,
                    s.HoraInicio,
                    s.HoraFin,
                    s.TiempoTranscurrido
                FROM 
                    Sesiones s
                INNER JOIN 
                    Usuarios u ON s.IdUsuario = u.Id
                WHERE 
                    CAST(s.Fecha AS DATE) = @Fecha
                ORDER BY 
                    s.Fecha DESC, s.HoraInicio DESC";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Fecha", fecha.Date);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


