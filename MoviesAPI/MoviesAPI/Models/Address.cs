using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Street { get; set; }

        [Required]
        public int Number { get; set; }
        public virtual MovieTeather MovieTeather { get; set; }

    }
}
