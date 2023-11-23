using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizaConstructora.Entities
{
    public class Cotizacion
    {
        // Propiedades de CotizacionDto
        public int IdCotizacion { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public int IdCliente { get; set; }

        //// Método para calcular el Subtotal de la cotización
        //public decimal CalcularSubtotal()
        //{
        //    decimal subtotal = 0;
        //    foreach (var material in ListaMateriales)
        //    {
        //        subtotal += material.CostoUnidad;
        //    }
        //    return subtotal;
        //}

        //// Método para calcular el IVA de la cotización (porcentaje especificado)
        //public decimal CalcularIVA(decimal porcentajeIVA)
        //{
        //    decimal subtotal = CalcularSubtotal();
        //    return subtotal * (porcentajeIVA / 100);
        //}

        //// Método para calcular el Total de la cotización (Subtotal + IVA)
        //public decimal CalcularTotal(decimal porcentajeIVA)
        //{
        //    decimal subtotal = CalcularSubtotal();
        //    decimal iva = CalcularIVA(porcentajeIVA);
        //    return subtotal + iva;
        //}
    }
}


