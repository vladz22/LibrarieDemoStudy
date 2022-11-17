using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarieDemo.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Numele produsului este obligatoriu")]
        [DisplayName("Numele produsului")]
        public string Nume { get; set; }
        public string Autor { get; set; }
        [Required(ErrorMessage = "Descrierea produsului este obligatoriu")]
        public string Descriere { get; set; }
        public int Cod { get; set; }
        public int Cantitate { get; set; }
        [DisplayName("Imaginea")]
        [ValidateNever]
        public string ImagineUrl { get; set; }

    }
}
