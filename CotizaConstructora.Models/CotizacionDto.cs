using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Models
{
    public class CotizacionDto
    {
        // Propiedades de CotizacionDto
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public ClienteRequestDto Cliente { get; set; }
        public List<MaterialRequestDto> Materiales { get; set; }


        // Método para calcular el Subtotal de la cotización
        public decimal CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (var material in Materiales)
            {
                subtotal += material.Valor;
            }
            return subtotal;
        }

        // Método para calcular el IVA de la cotización (porcentaje especificado)
        public decimal CalcularIVA(decimal porcentajeIVA)
        {
            decimal subtotal = CalcularSubtotal();
            return subtotal * (porcentajeIVA / 100);
        }

        // Método para calcular el Total de la cotización (Subtotal + IVA)
        public decimal CalcularTotal(decimal porcentajeIVA)
        {
            decimal subtotal = CalcularSubtotal();
            decimal iva = CalcularIVA(porcentajeIVA);
            return subtotal + iva;
        }
    }
}


