

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
        public DateTime Data { get; set; }
    }
}
