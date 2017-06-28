

using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Ferramenta
    {
        [Key]
        public int FerramentaID { get; set; }

        [Display(Name = "Código Ferramenta")]
        [Required(ErrorMessage = "campo obrigatório!")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição Ferramenta")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }


        
    }
}
