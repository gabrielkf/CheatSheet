using CheatSheet.Models;
using Microsoft.EntityFrameworkCore;

namespace CheatSheet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<Command> Commands { get; set; }
    }
}