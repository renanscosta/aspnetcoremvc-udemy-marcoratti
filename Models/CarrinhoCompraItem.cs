using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class CarrinhoCompraItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarrinhoCompraItemId { get; set; }
        public virtual Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}