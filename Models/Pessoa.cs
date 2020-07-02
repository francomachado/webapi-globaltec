using System;
using System.ComponentModel.DataAnnotations;

namespace Globaltec.Models
{
    //As validações das informações preenchidas serão realizadas aqui
    public class Pessoa
    {
        //Informações não serão persistidas no banco
        //Código é uma chave com autoincremento
        [Key]
        public int Codigo {get; set;}

        [Required(ErrorMessage="O nome é obrigatório")]
        [MinLength(2,ErrorMessage="O nome deve conter no mínimo dois caracteres")]
        [MaxLength(256,ErrorMessage="O nome deve ter no máximo 256 caracteres")]
        public string Nome {get;set;}

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MinLength(11, ErrorMessage ="CPF deve conter 11 caracteres. Retire outros caracteres como . - ou /")]
        [MaxLength(11, ErrorMessage ="CPF deve conter 11 caracteres. Retire outros caracteres como . - ou /")]
        public string CPF {get; set;}

        [Required(ErrorMessage = "A UF é obrigatória")]
        [MinLength(2,ErrorMessage="A UF deve ser informada no padrão de sigla com duas letras. Ex.: GO")]
        [MaxLength(2,ErrorMessage="A UF deve ser informada no padrão de sigla com duas letras. Ex.: GO")]
        public string UF {get;set;}

        [Required(ErrorMessage="A data de nascimento é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime DataNascimento {get;set;}

    }
}