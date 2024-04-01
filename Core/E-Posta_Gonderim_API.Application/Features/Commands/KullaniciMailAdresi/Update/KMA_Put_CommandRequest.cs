using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Update
{
    public class KMA_Put_CommandRequest :IRequest<KMA_Put_CommandResponse>
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? MailAdresi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public string? TelefonNumarasi { get; set; }
        public string? IsYeri { get; set; }
        public string? Unvan { get; set; }
    }
}
