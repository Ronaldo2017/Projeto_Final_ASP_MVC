

using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Código Produto")]
        public string Codigo { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }


        public int? MaquinaID { get; set; }

        [Display(Name = "Máquina")]        
        public virtual Maquina _Maquina { get; set; }
    }
}
