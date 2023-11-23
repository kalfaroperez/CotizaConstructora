using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Models
{
    public class MaterialDto
    {
        // Propiedades de Materiales
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public int CostoUnidad { get; set; }
        
    }
}
