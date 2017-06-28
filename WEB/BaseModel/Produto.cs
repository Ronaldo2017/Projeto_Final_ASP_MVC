

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
        public DateTime Data { get; set; }


        public int? MaquinaID { get; set; }

        [Display(Name = "Máquina")]        
        public virtual Maquina _Maquina { get; set; }
    }
}
