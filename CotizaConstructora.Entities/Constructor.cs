using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Entities
{
    public class Constructor
    {
        // Propiedades de Constructor
        public int Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }

        // Propiedad para representar el Cliente asociado
        public Cliente ClienteAsociado { get; set; }
    }
}
