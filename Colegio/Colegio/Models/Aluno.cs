using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class Aluno
    {
        /*
         Anottations :
         Display : Renomeia o nome para view
         Key: Chave
         Required: obrigatório , com validação tanto back quanto front
             
             */

        [Display(Name ="Código do aluno")] 
        [Key]
        public int AlunoId { get; set; }
        [Required]
        [Display(Name="Nome do aluno")]
        public string AlunoNome { get; set; }
        [Required]
        [Display(Name ="RG do Aluno")]
        public string AlunoRg { get; set; }
        
    }
}