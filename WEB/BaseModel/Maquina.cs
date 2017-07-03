

using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Maquina
    {
        [Key]
        public int MaquinaID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Código Máquina")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
    }
}
