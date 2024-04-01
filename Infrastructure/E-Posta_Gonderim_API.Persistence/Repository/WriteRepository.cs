using E_Posta_Gonderim_API.Application.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Posta_Gonderim_API.Persistence.Contexts;
using E_Posta_Gonderim_API.Domain.Entities.Common;

namespace E_Posta_Gonderim_API.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private EPostaGonderimAPIDbContext _context;
        public WriteRepository(EPostaGonderimAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            T? model = await Table.FirstOrDefaultAsync(p => p.Id == id);
            if (model != null)
                return Remove(model);
            return false;
        }
        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
