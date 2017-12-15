using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fornecedores.Models
{
    public class IndexRegiao
    {
        public IList<DAL.Fornecedor> Fornecedores { get; set; }
        public IList<RegiaoEstado> RegioesEstado { get; set; }
        public IList<DAL.Estado> Estados { get; set; }
        public long? IdFornecedor { get; set; }

        public int IdEstado { get; set; }      
        public string DescricaoRegiao { get; set; }

    }
     
}