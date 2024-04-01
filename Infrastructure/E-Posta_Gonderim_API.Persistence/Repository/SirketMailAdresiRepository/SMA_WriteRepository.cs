using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using E_Posta_Gonderim_API.Domain.Entities;
using E_Posta_Gonderim_API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Persistence.Repository.SirketMailAdresiRepository
{
    public class SMA_WriteRepository : WriteRepository<SirketMailAdresi>, ISMA_WriteRepository
    {
        public SMA_WriteRepository(EPostaGonderimAPIDbContext context) : base(context)
        {
        }
    }
}
