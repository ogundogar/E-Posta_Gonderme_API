using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetAll
{
    public class SM_GetAll_QueryRequest:IRequest<SM_GetAll_QueryResponse>
    {
        public bool Descending { get; set; }
    }
}
