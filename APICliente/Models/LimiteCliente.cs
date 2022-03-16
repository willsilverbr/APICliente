using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICliente.Models
{
    public class LimiteCliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double LimiteCredito { get; set; }
    }
}