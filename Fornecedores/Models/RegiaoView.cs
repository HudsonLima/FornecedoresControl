using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedores.Models
{
    public class RegiaoView
    {
        public long IdRegiao { get; set; }

        public string Descricao { get; set; }
        public byte Ativo { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado EstadoRegiao { get; set; }
        public IList<DAL.Estado> Estados { get; set; }
    }
}