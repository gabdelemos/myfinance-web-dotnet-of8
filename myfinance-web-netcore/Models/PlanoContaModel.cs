using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }        
    }
}