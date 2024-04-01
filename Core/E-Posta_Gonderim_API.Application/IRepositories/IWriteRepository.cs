﻿using E_Posta_Gonderim_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<bool> RemoveAsync(int id);

        bool Update(T model);
        Task<int> SaveAsync();
    }
}
