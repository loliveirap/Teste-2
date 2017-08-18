using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebApiContatos.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsParente { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }
    }
}