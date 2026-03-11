using Microsoft.EntityFrameworkCore;
using TaskCats.Models;

namespace TaskCats.Storage;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Cat> Cats { get; set; }
    
}