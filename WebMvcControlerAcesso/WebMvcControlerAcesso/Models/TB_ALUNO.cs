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
    
    public partial class TB_ALUNO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_ALUNO()
        {
            this.TB_ACESSO = new HashSet<TB_ACESSO>();
            this.TB_AUTORIZACAO = new HashSet<TB_AUTORIZACAO>();
            this.TB_ALUNO_TURMA = new HashSet<TB_ALUNO_TURMA>();
        }
    
        public int COD_ALUNO { get; set; }
        public string NOME { get; set; }
        public string RM { get; set; }
        public System.DateTime DATA_NASCIENTO { get; set; }
        public string SEXO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ACESSO> TB_ACESSO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_AUTORIZACAO> TB_AUTORIZACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_ALUNO_TURMA> TB_ALUNO_TURMA { get; set; }
    }
}
