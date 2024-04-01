using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetAll
{
    public class YM_GetAll_QueryRequest:IRequest<YM_GetAll_QueryResponse>
    {
        public bool Descending { get; set; }
    }
}
