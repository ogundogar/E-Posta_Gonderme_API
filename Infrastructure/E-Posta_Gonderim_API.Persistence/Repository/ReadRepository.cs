using E_Posta_Gonderim_API.Application.Repositories;
using E_Posta_Gonderim_API.Domain.Entities.Common;
using E_Posta_Gonderim_API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace E_Posta_Gonderim_API.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private EPostaGonderimAPIDbContext _context;
        public ReadRepository(EPostaGonderimAPIDbContext context){
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetByIdAsync(int id, bool tracking = true) => await Table.FindAsync(id);
    }
}
