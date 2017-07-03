

using System;
using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Producao
    {
        [Key]
        public int ProducaoID { get; set; }

        [Display(Name = "Data de Empréstimo")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }

        public int LoteID { get; set; }
        public virtual Lote _Lote { get; set; }

        public int MaquinaID { get; set; }
        public virtual Maquina _Maquina { get; set; }

        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}
