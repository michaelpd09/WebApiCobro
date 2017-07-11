using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiCobro.Models
{
    public class Cobros
    {
        [Key]

        public int IdCobro { get; set; }
        public DateTime Fecha { get; set; }
        public string Referencia { get; set; }
        public int IdRemoto { get; set; }
        public int IdRuta { get; set; }
        public decimal Mora { get; set; }
        public decimal Monto { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public bool EsNulo { get; set; }
    }
}