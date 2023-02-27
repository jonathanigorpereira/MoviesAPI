using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateAddressDTO
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
