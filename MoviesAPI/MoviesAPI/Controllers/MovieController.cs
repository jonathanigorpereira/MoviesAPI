using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
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

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="movieDTO">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] CreateMovieDTO movie)
        {
            var movies = _context.Movies.FirstOrDefault(x => x.ID == id);
            if (movies == null) return NotFound();

            //update data equal json transfer
            _mapper.Map(movie, movies);
            _context.SaveChanges();

            //Code used to update datas
            return NoContent();
        }


        /* body to do patch from item in .Net
         [
            {
                "op":"replace",
                "path":"/title",
                "value":"patch"
            }
         ]
         */
        [HttpPatch("{id}")]
        public IActionResult UpdateMoviePatch(int id, JsonPatchDocument<CreateMovieDTO> patch) {

            var movies = _context.Movies.FirstOrDefault(x => x.ID == id);
            if (movies == null) return NotFound();

            var movieUpdatePatch = _mapper.Map<CreateMovieDTO>(movies);
            patch.ApplyTo(movieUpdatePatch, ModelState);

            if (!TryValidateModel(movieUpdatePatch))
            {
                return ValidationProblem(ModelState);
            }
            //update data equal json transfer
            _mapper.Map(movieUpdatePatch, movies);
            _context.SaveChanges();

            //Code used to update datas
            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteMovie(int id) {
            var movie = _context.Movies.FirstOrDefault(x => x.ID == id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok("Movie Deleted"); 
        }


    }
}
