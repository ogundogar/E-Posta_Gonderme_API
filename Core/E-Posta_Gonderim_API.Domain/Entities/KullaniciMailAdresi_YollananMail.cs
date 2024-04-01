using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Domain.Entities
{
    public class KullaniciMailAdresi_YollananMail
    {
        public int KullaniciMailAdresiId { get; set; }
        public int YollananMailId { get; set; }

        public KullaniciMailAdresi KullaniciMailAdresi { get; set; }
        public YollananMail YollananMail { get; set; }
    }
}
