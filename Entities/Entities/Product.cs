using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Product : EntityBase
    {
        [Display(Name ="Preço")]
        [Column("Preco", TypeName ="decimal")]
        public decimal Preco { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
