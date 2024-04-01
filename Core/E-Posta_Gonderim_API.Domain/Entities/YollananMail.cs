using E_Posta_Gonderim_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Domain.Entities
{
    public class YollananMail:BaseEntity
    {
        public int SirketMailId { get; set; }
        public string? Baslik { get; set; }
        public string? Mesaj { get; set; }
        public ICollection<KullaniciMailAdresi_YollananMail> KullaniciMailAdresleri { get; set; }
        public SirketMailAdresi SirketMailAdresleri { get; set; }
    }
}
