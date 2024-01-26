using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class Cliente
    {
        public int clienteId { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
     
        public string telefono { set; get; }
        public string correo { set; get; }
        public string password { set; get; }
        public string direccion { set; get; }
        public string GetFullName()
        {
            return $"{nombre} {apellido}";
        }
        //public List<Vehiculo> Vehiculos { get; set; }
    }
}


