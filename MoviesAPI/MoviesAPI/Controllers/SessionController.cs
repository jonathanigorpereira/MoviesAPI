using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SessionController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/RegisterSession")]
        public IActionResult AddNewSession([FromBody] CreateSessionDTO sessionDTO)
        {
            Session session = _mapper.Map<Session>(sessionDTO);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessions), new { movieId = session.MovieId, movieTeatherId = session.MovieTeatherId}, session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDTO> GetSessions()
        {
            return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());
        }

        [HttpGet("{MovieId}/{MovieTheaterId}")]
        public IActionResult GetSessionById(int movieId, int movieTheaterId)
        {
            Session session = _context.Sessions.FirstOrDefault(x => x.MovieId == movieId && x.MovieTeatherId ==movieTheaterId);
            if (session == null) { return NotFound(); }

            ReadSessionDTO readSession = _mapper.Map<ReadSessionDTO>(session);

            return Ok(readSession);
        }

        [HttpDelete("{movieId}/{movieTeatherId}")]
        public IActionResult DeleteSession(int movieId, int movieTeatherId)
        {
            Session session = _context.Sessions.FirstOrDefault(x => x.MovieId == movieId && x.MovieTeatherId == movieTeatherId);
            if (session == null) { return NotFound(); }

            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
