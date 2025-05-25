using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDealbera_IEFI
{
    internal class clsConexionBD
    {
        //cadena de conexion
        string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=Auditoria;Trusted_Connection=True;";
        //"Server=localhost\SQLEXPRESS;Database=Comercio;Trusted_Connection=True;"
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        //Server=PC50;Database=Comercio;Trusted_Connection=True;


        //conector
        SqlConnection coneccionBaseDatos;

        //comando
        SqlCommand comandoBaseDatos;

        public string nombreBaseDeDatos;


        public void ConectarBD()
        {
            try
            {
                coneccionBaseDatos = new SqlConnection(cadenaConexion);

                nombreBaseDeDatos = coneccionBaseDatos.Database;

                coneccionBaseDatos.Open();

                MessageBox.Show("Conectado a " + nombreBaseDeDatos);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }

        }

        public void ListarBD(DataGridView Grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM RegistroLogin ORDER BY Codigo ASC";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    Grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudieron cargar los productos correctamente.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*public void Agregar(clsUsuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId) VALUES (@nombre, @descripcion, @precio, @stock, @categoriaId)";

                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                    comando.Parameters.AddWithValue("@", usuario.descripcion);
                    comando.Parameters.AddWithValue("@precio", usuario.precio);
                    comando.Parameters.AddWithValue("@stock", usuario.stock);
                    comando.Parameters.AddWithValue("@categoriaId", usuario.categoria);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al agregar producto: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar(clsUsuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "UPDATE Productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock, CategoriaId = @categoriaId WHERE Codigo = @codigo";

                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@nombre", producto.nombre);
                    comando.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    comando.Parameters.AddWithValue("@precio", producto.precio);
                    comando.Parameters.AddWithValue("@stock", producto.stock);
                    comando.Parameters.AddWithValue("@categoriaId", producto.categoria);
                    comando.Parameters.AddWithValue("@codigo", producto.codigo);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar producto: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Eliminar(int codigo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "DELETE FROM Productos WHERE Codigo = @codigo";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@codigo", codigo);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un producto con ese código.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar producto: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void BuscarPorNombre(string nombre, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = "SELECT * FROM Productos WHERE Nombre LIKE @nombre";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    // Mostrar resultados
                    grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar productos: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void BuscarPorCategoria(int categoriaId, DataGridView grilla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Productos WHERE CategoriaId = @categoriaId";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@categoriaId", categoriaId);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar por categoría: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


    }
}
