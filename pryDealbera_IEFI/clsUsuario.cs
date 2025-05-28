using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDealbera_IEFI
{
    public class clsUsuario
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }

        public clsUsuario(int Id, string nombre, string contraseña, string correo, string telefono)
        {
            this.Id = Id;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.correo = correo;
            this.telefono = telefono;
        }

    }
}
