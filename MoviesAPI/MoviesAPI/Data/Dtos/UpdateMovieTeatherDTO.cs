using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateMovieTeatherDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Name { get; set; }
    }
}
