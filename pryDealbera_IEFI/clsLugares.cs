using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDealbera_IEFI
{
    internal class clsLugares
    {
        public int IdLugar {  get; set; }
        public string Nombre { get; set;}

        public clsLugares(int IdLugar, string Nombre) 
        {
            this.IdLugar = IdLugar;
            this.Nombre = Nombre; 
        }
    }
}
