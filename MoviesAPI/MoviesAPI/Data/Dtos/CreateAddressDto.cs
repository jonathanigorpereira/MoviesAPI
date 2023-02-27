using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class CreateAddressDto
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
