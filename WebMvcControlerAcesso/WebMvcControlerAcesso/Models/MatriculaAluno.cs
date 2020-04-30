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

        //internal TB_ALUNO TB_ALUNO;


        public string NOME { get; set; }
        public string RM { get; set; } //Não não vai ser gerado pelo sistema ???


        [DataType(DataType.Date)]
        public DateTime DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public int COD_TURMA { get; set; } //Depois pega os outros dados apartir desse

        public TB_ALUNO TB_ALUNO
        {
            get
            {
                return new TB_ALUNO
                {
                    NOME = this.NOME,
                    RM = this.RM,
                    SEXO = this.SEXO,
                    DATA_NASCIENTO = this.DATA_NASCIMENTO,


                };

            }
        }

    }
}