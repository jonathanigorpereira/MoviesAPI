using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using MoviesAPI.Data;
using MoviesAPI.Models;
using AutoMapper;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTeatherController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieTeatherController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/AddMovieTheater")]
        public IActionResult AddMovieTeather([FromBody] CreateMovieTeatherDTO movieTheaterDto)
        {
            MovieTeather movieTheater = _mapper.Map<MovieTeather>(movieTheaterDto);

            _context.MovieTheater.Add(movieTheater);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieTheaterById), new { Id = movieTheater.Id }, movieTheaterDto);
        }

        [HttpGet]
        public IEnumerable<ReadMovieTeatherDTO> RescueMovieTheater()
        {
            return _mapper.Map<List<ReadMovieTeatherDTO>>(_context.MovieTheater.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterById(int id)
        {
            MovieTeather movieTheater = _context.MovieTheater.FirstOrDefault(x => x.Id == id);
            if (movieTheater != null)
            {
                ReadMovieTeatherDTO movieTheaterDto = _mapper.Map<ReadMovieTeatherDTO>(movieTheater);
                return Ok(movieTheaterDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTeatherDTO movieTheaterDto)
        {
            MovieTeather movieTeather = _context.MovieTheater.FirstOrDefault(x => x.Id == id);
            if (movieTeather == null) { return NotFound(); }
            _mapper.Map(movieTheaterDto, movieTeather);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {
            MovieTeather movieTheater = _context.MovieTheater.FirstOrDefault(x => x.Id == id);
            if (movieTheater == null) { return NotFound(); }
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
