using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Delete
{
    public class SM_Delete_CommandRequest:IRequest<SM_Delete_CommandResponse>
    {
        public int Id { get; set; }
    }
}
