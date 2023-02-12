using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.IO;
using System.Linq;


namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: ControllerBase
    {
        private static List<Filme> movies = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult InsertMovie([FromBody] Filme movie)
        {
            movie.ID = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieByID), new { id = movie.ID}, movie);

        }

        [HttpGet]
        public IEnumerable<Filme> Get([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieByID(int id)
        {
            var movieByid = movies.FirstOrDefault(x => x.ID == id);
            if (movieByid == null) return NotFound();
            return Ok(movieByid);
        }




    }
}
