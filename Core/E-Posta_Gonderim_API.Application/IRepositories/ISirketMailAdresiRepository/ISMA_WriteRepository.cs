using E_Posta_Gonderim_API.Application.Repositories;
using E_Posta_Gonderim_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository
{
    public interface ISMA_WriteRepository:IWriteRepository<SirketMailAdresi>
    {
    }
}
