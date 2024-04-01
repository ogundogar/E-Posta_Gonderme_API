using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using E_Posta_Gonderim_API.Persistence.Contexts;
using E_Posta_Gonderim_API.Persistence.Repository.KullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Persistence.Repository.SirketMailAdresiRepository;
using E_Posta_Gonderim_API.Persistence.Repository.YollananMailRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EPostaGonderimAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<ISMA_ReadRepository, SMA_ReadRepository>();
            services.AddScoped<ISMA_WriteRepository, SMA_WriteRepository>();

            services.AddScoped<IKMA_ReadRepository, KMA_ReadRepositoer>();
            services.AddScoped<IKMA_WriteRepository, KMA_WriteRepository>();

            services.AddScoped<IYM_ReadRepository, YM_ReadRepository>();
            services.AddScoped<IYM_WriteRepository, YM_WriteRepository>();
        }
    }
}
