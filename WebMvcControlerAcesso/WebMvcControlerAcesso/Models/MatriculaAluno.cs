using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMvcControlerAcesso.Models
{
    public class MatriculaAluno
    {
        public int RM { get; set; } //Não nvai ser gerado pelo sistema ???
        public string NOME { get; set; }

        [DataType(DataType.Date)]
        public DateTime DATA_NASCIMENTO { get; set; }
        public int COD_TURMA { get; set; } //Depois pega os outros dados apartir desse

    }
}