using Entities.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class EntityBase : Notities
    {
        [Display(Name ="código")]
        public int Id { get; set; }

        [Display(Name = "nome")]
        public string Nome { get; set; }

    }
}
