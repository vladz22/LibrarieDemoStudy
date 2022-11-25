using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarieDemo.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        [DisplayName("Numele categoriei")]
        public string Nume { get; set; }

    }
}
