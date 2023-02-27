using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public virtual Filme Movie { get; set; }
        public int? MovieTeatherId { get; set; }
        public virtual MovieTeather MovieTeather { get; set; }
    }
}
