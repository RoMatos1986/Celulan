using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celulan.Aplication.Membro
{
    public class UsuarioMembroRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Telefone { get; set; }
        public decimal Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
