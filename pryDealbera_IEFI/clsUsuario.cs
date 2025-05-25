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
        public int contraseña { get; set; }

        public clsUsuario(int Id, string nombre, int contraseña)
        {
            this.Id = Id;
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

    }
}
