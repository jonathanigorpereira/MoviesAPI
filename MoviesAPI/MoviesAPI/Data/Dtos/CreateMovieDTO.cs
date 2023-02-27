using MoviesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class CreateMovieDTO
    {
        
        [Required(ErrorMessage = "O Título do filme não foi informado.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O Gênero do filme não foi informado.")]
        [StringLength(50, ErrorMessage = "O tamanho do Gênero não pode ultrapassar 50 caracteres.")]
        public string Gender { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração do filme deve ter entre 70 e 600 minutos.")]
        public int Duration { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
