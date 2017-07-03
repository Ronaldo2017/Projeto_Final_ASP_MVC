

using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Manutencao
    {
        [Key]
        public int ManutencaoID { get; set; }


        [Required]
        [Display(Name = "Custo Manutenção ")]
        [DataType(DataType.Currency)]
        public decimal CustoManutencao { get; set; }

        public int FerramentaID { get; set; }

        public virtual Ferramenta _Ferramenta { get; set; }

        [Display(Name = "Data de Envio")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data Estimada de Retorno")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataSaida { get; set; }
    }
}
