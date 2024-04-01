﻿using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using E_Posta_Gonderim_API.Domain.Entities;
using E_Posta_Gonderim_API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Persistence.Repository.YollananMailRepository
{
    public class YM_WriteRepository : WriteRepository<YollananMail>, IYM_WriteRepository
    {
        public YM_WriteRepository(EPostaGonderimAPIDbContext context) : base(context)
        {
        }
    }
}
