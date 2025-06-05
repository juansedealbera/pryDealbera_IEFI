using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDealbera_IEFI
{
    public class clsAuditoriaSesiones
    {
        public int Id {  get; set; }
        public int IdUsuario {  get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public TimeSpan TiempoTranscurrido { get; set; }

        public clsAuditoriaSesiones(int Id, int IdUsuario, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin, TimeSpan TiempoTranscurrido) 
        {
            this.Id = Id;
            this.IdUsuario = IdUsuario;
            this.Fecha = Fecha;
            this.HoraInicio = HoraInicio;
            this.HoraFin = HoraFin;
            this.TiempoTranscurrido = TiempoTranscurrido;
        }
    }
}
