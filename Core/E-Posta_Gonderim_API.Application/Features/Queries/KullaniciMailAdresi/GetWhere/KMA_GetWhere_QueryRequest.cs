using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetWhere
{
    public class KMA_GetWhere_QueryRequest :IRequest<KMA_GetWhere_QueryResponse>
    {
        public string? ad { get; set; }
        public string? soyad { get; set; }
        public string? mailAdresi { get; set; }

        public bool? cinsiyet { get; set; }
        public DateTime? baslangicTarihi { get; set; }
        public DateTime? bitisTarihi { get; set; }
        public string? isYeri { get; set; }
        public string? unvan { get; set; }
        public bool Descending { get; set; }
    }
}
