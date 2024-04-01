using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetWhere
{
    public class YM_GetWhere_QueryRequest:IRequest<YM_GetWhere_QueryResponse>
    {
        public string? sirketMailAdresi { get; set; }
        public string? baslik { get; set; }
        public DateTime? tarih { get; set; }
        public bool Descending { get; set; }
    }
}
