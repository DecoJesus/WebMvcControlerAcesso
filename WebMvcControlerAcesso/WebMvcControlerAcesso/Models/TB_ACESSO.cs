//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMvcControlerAcesso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_ACESSO
    {
        public int COD_ACESSO { get; set; }
        public string DATA { get; set; }
        public System.TimeSpan HORA_ENTRADA { get; set; }
        public System.TimeSpan HORA_SAIDA { get; set; }
        public Nullable<int> COD_ALUNO { get; set; }
    
        public virtual TB_ALUNO TB_ALUNO { get; set; }
    }
}
