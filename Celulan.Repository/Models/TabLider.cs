using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celulan.Repository.Models
{
    public class TabLider
    {
        public int id { get; set; }
        public string Lider { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celula { get; set; }
        public decimal Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
