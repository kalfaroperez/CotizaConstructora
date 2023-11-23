using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Models
{
    public class MaterialRequestDto
    {
        public int IdMaterial { get; set; }
        public decimal Valor { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public decimal IVA { get; set; }

    }
}
