using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class Vehiculo
    {
        public int vehiculoId { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public int anio { set; get; }
        public string placa { set; get; }
        public int clienteId { set; get; }
   
    }
}
