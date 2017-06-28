

using System.ComponentModel.DataAnnotations;

namespace BaseModel
{
    public class CriarLote
    {
        [Key]
        public int CriarLoteID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Lote { get; set; }


    }
}
