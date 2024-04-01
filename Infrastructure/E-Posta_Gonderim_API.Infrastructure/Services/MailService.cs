using E_Posta_Gonderim_API.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_Posta_Gonderim_API.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public async Task SendMessageAsync(string[] km_adresleri, string km_ad,string km_soyad, string displayName, string sm_adresi, string sifre, int port, string host,  string baslik, string mesaj)
        {
            mesaj = "Sayın  <span style='text-transform: capitalize;'>" + km_ad + "</span>  <span style='text-transform: uppercase;'>" + km_soyad+ "</span> <br><br>" + mesaj;
            MailMessage mail = new();
            mail.IsBodyHtml = true;
            foreach (var kma in km_adresleri)
                mail.To.Add(kma);
            mail.Subject = baslik;
            mail.Body = mesaj;
            mail.From = new(sm_adresi, displayName, System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(sm_adresi, sifre);
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.Host = host;
            await smtp.SendMailAsync(mail);
        }

        public async Task SendMessageAsync(string km_adresi, string km_ad, string km_soyad, string displayName, string sm_adresi, string sifre, int port, string host, string baslik, string mesaj)
        {
            await SendMessageAsync(new[] { km_adresi }, km_ad, km_soyad, displayName, sm_adresi, sifre, port, host, baslik, mesaj);
        }
    }
}
