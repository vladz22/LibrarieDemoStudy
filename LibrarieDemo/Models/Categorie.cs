using System.ComponentModel.DataAnnotations;

namespace LibrarieDemo.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }

    }
}
