using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos
{
    public class ReadMovieTeatherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadAddressDto Address { get; set; }
        public ICollection<ReadSessionDTO> Sessions { get; set; }
    }
}
