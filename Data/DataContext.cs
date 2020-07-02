using Globaltec.Models;
using Microsoft.EntityFrameworkCore;

namespace Globaltec.Data
{
    //Banco de dados somente em memória
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
            {
            } 
        public DbSet<Pessoa> Pessoas {get; set; }
    }
}