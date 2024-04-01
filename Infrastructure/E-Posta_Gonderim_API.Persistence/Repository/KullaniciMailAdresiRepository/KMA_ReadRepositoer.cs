using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Domain.Entities;
using E_Posta_Gonderim_API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Persistence.Repository.KullaniciMailAdresiRepository
{
    public class KMA_ReadRepositoer : ReadRepository<KullaniciMailAdresi>, IKMA_ReadRepository
    {
        public KMA_ReadRepositoer(EPostaGonderimAPIDbContext context) : base(context)
        {
        }
    }
}
