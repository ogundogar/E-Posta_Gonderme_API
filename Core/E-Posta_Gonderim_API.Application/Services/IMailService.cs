using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string[] km_adresleri,string km_ad,string km_soyad, string displayName,string sm_adresi,string sifre,int port,string host, string baslik, string mesaj);
        Task SendMessageAsync(string km_adresi, string km_ad, string km_soyad, string displayName, string sm_adresi, string sifre, int port, string host, string baslik, string mesaj);

    }
}
