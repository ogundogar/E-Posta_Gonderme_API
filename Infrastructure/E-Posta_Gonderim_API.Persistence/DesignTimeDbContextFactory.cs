using E_Posta_Gonderim_API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace E_Posta_Gonderim_API.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EPostaGonderimAPIDbContext>
    {
        public EPostaGonderimAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EPostaGonderimAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
