using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) 
        {
            
        }
        //Relacionamento N:N no banco de dados entre filme e cinema
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.MovieTeatherId });//Cria a chave composta

            builder.Entity<Session>()
                .HasOne(session => session.MovieTeather)
                .WithMany(movieTheater=> movieTheater.Sessions)
                .HasForeignKey(session => session.MovieTeatherId);

            builder.Entity<Session>()
               .HasOne(session => session.Movie)
               .WithMany(movie => movie.Sessions)
               .HasForeignKey(session => session.MovieId);

            //Criar a deleção de um registro sem afetar os demais registros relacionados
            builder.Entity<Address>()
                .HasOne(address => address.MovieTeather)
                .WithOne(movieTheater => movieTheater.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Filme> Movies { get; set; }
        public DbSet<MovieTeather> MovieTheater { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
