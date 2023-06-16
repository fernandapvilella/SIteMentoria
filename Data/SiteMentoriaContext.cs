using Microsoft.EntityFrameworkCore;
using SiteMentoria.Models;

namespace SiteMentoria.Data
{
    public class SiteMentoriaContext : DbContext
    {
        public SiteMentoriaContext(DbContextOptions<SiteMentoriaContext> options)
            : base(options)
        {
        }
        public DbSet<SiteMentoria.Models.Pessoa> Pessoa { get; set; }
        public DbSet<SiteMentoria.Models.Atividade> Atividade { get; set; }
    }
}
