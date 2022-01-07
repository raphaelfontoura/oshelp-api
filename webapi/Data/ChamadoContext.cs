using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ChamadoContext : DbContext
    {
        public ChamadoContext(DbContextOptions<ChamadoContext> opt) : base (opt)
        {
            
        }

        public DbSet<Chamado> Chamados { get; set; }

    }
}