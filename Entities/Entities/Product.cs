using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Product : EntityBase
    {
        [Display(Name ="Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
