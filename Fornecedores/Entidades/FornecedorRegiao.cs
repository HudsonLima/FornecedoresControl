//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class FornecedorRegiao
    {
        public long IdFornecedorRegiao { get; set; }
        public long IdFornecedor { get; set; }
        public long IdRegiao { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Regiao Regiao { get; set; }
    }
}
