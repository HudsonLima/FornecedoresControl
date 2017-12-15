using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedores.Models
{
    public class RegiaoEstado
    {
        public long IdRegiao { get; set; }
        public int IdEstado { get; set; }
        public long IdFornecedorFormulario { get; set; }        
        public string DescricaoRegiao { get; set; }
        public byte Ativo { get; set; }
        public string DescricaoEstado { get; set; }
        public bool relacionadoComFornecedor { get; set; }


    }
}