
using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Estoque
    {
        [Key]
        public int EstoqueID { get; set; }

        public int LoteID { get; set; }

        public virtual Lote _Lote { get; set; }

        [Required]
        [Display(Name ="Ferramenta Nova")]
        public bool FerramentaNova { get; set; }

        [Required]
        [Display(Name ="Ferramenta Remanufaturada")]
        public bool FerramentaRemanufaturada { get; set; }

        [Display(Name = "Data de Entrada")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data de Saída")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataSaida { get; set; }

    }
}
