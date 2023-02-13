using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) 
        {

        }
        public DbSet<Filme> Movies { get; set; }
    }
}
