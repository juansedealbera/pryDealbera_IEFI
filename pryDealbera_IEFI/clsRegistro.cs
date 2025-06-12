using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDealbera_IEFI
{
    public class clsRegistro
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTarea { get; set; }
        public int IdLugar { get; set; }
        public bool Insumo { get; set; }
        public bool Vacaciones { get; set; }
        public bool Estudio { get; set; }
        public bool Salario { get; set; }
        public bool Recibo { get; set; }
        public string Comentario { get; set; }

        // Constructor vacío (soluciona el error CS7036)
        public clsRegistro() { }

        // Constructor completo (opcional si querés inicializar todo de una)
        public clsRegistro(int Id, DateTime Fecha, int IdTarea, int IdLugar, bool Insumo, bool Vacaciones, bool Estudio, bool Salario, bool Recibo, string Comentario)
        {
            this.Id = Id;
            this.Fecha = Fecha;
            this.IdTarea = IdTarea;
            this.IdLugar = IdLugar;
            this.Insumo = Insumo;
            this.Vacaciones = Vacaciones;
            this.Estudio = Estudio;
            this.Salario = Salario;
            this.Recibo = Recibo;
            this.Comentario = Comentario;
        }
    }
}
