using BruteWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BruteWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}