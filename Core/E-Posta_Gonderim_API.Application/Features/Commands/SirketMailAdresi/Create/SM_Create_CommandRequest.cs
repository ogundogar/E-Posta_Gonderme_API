using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Create
{
    public class SM_Create_CommandRequest: IRequest<SM_Create_CommandResponse>
    {
        public string DisplayName { get; set; }
        public string MailAdresi { get; set; }
        public string Sifre { get; set; }
        public int PortNumarasi { get; set; }
        public string Host { get; set; }
        public string Aciklama { get; set; }
    }
}
