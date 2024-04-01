using E_Posta_Gonderim_API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Domain.Entities
{
    public class SirketMailAdresi:BaseEntity
    {
        public string? DisplayName { get; set; }
        public string? MailAdresi { get; set; }
        public string? Sifre { get; set; }
        public int PortNumarasi { get; set; }
        public string? Host { get; set; }
        public string? Aciklama { get; set; }
        public ICollection<YollananMail>? YollananMailler { get; set; }
    }
}
