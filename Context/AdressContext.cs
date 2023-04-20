using Desafio_NO.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_NO.Models
{
    public class AdressContext : DbContext
    {
        public AdressContext(DbContextOptions<AdressContext> options)
        :base(options)
        {
        }

        public DbSet<AdressTable> adress_rl {get; set;}
    }
}