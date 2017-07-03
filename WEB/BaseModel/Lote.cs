

using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class Lote
    {
        [Key]
        public int LoteID { get; set; }

        [Display(Name = "Lote Ferramenta")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string LoteFerramenta { get; set; }

        public int FerramentaID { get; set; }

        public virtual Ferramenta _Ferramenta { get; set; }

        public int CriarLoteID { get; set; }

        [Display(Name ="Criar Lote")]
        public virtual CriarLote _CriarLote { get; set; }
    }
}
