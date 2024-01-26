using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class Cita
    {
        public int citaId { set; get; }
        public DateOnly fecha { set; get; }
        public TimeOnly hora { set; get; }
        public string problema { set; get; }
        public int vehiculoId { set; get; }
        public int tallerId { set; get; }

    }
}
