using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Entities
{
    public class CotizacionDetalle
    {
        public int IdContizacionDetalle { get; set; }
        public int IdContizacion { get; set; }
        public int IdMaterial { get; set; }
        public decimal Valor { get; set; }
        public double Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Iva { get; set; }
    }
}
