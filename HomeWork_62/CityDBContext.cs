using HomeWork_62.City_Tables;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_62;

public class CityDBContext:DbContext
{
    public CityDBContext()
    {
        
    }

    public CityDBContext(DbContextOptions<CityDBContext> dbContextOptions):base(dbContextOptions)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = CityDB");
    }
    
    public DbSet<Educational_Institutions> Educational_Institutions { get; set; }
    public DbSet<FactoriesInfo> FactoriesInfo { get; set; }
    public DbSet<CinemaInfo> CinemaInfo { get; set; }
    public DbSet<Transpots> Transpots { get; set; }
    public DbSet<Shops> Shops { get; set; }

}
