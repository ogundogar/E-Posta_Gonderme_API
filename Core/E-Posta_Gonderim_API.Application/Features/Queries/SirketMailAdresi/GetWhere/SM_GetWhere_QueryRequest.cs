using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetWhere
{
    public class SM_GetWhere_QueryRequest:IRequest<SM_GetWhere_QueryResponse>
    {
        public string? displayName { get; set; }
        public string? mailAdresi { get; set; }
        public string? sifre { get; set; }
        public int? portNumarasi { get; set; }
        public string? host { get; set; }
        public bool Descending { get; set; }
    }
}
