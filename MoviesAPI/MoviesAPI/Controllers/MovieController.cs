using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;
using System;
using System.IO;
using System.Linq;


namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

       public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertMovie([FromBody] CreateMovieDTO movieDTO)
        {
            //Maps the DTO according to the data of class Filmes
            Filme movie = _mapper.Map<Filme>(movieDTO);

            //Management the database using code
           _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieByID), new { id = movie.ID }, movie);

        }

        [HttpGet]
        public IEnumerable<Filme> Get([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _context.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieByID(int id)
        {
            var movieByid = _context.Movies.FirstOrDefault(x => x.ID == id);
            if (movieByid == null) return NotFound();
            return Ok(movieByid);
        }




    }
}
