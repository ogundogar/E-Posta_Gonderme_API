using E_Posta_Gonderim_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Domain.Entities
{
    public class KullaniciMailAdresi:BaseEntity
    {
       
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? MailAdresi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool? Cinsiyet { get; set; }
        public string? TelefonNumarasi { get; set; }
        public string? IsYeri { get; set; }
        public string? Unvan { get; set; }
        public ICollection<KullaniciMailAdresi_YollananMail> YollananMailler { get; set; }
    }
}
