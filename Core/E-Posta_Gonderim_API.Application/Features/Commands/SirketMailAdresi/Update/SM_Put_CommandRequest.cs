using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Update
{
    public class SM_Put_CommandRequest:IRequest<SM_Put_CommandResponse>
    {
        public int Id { get; set; }
        public string MailAdresi { get; set; }
        public string Sifre { get; set; }
        public int PortNumarasi { get; set; }
        public string MailSunucuAdresi { get; set; }
        public string Host { get; set; }
        public string Aciklama { get; set; }
    }
}
