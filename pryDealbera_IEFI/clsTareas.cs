using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDealbera_IEFI
{
    internal class clsTareas
    {
        public int IdTarea { get; set; }
        public string Nombre { get; set; }

        public clsTareas(int IdTarea, string Nombre) 
        {
            this.IdTarea = IdTarea;
            this.Nombre = Nombre;
        }
    }
}
