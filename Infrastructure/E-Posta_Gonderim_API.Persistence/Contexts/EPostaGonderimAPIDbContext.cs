using E_Posta_Gonderim_API.Domain.Entities;
using E_Posta_Gonderim_API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace E_Posta_Gonderim_API.Persistence.Contexts
{
    public class EPostaGonderimAPIDbContext:DbContext
    {
        public EPostaGonderimAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<KullaniciMailAdresi> KullanıcıMailAdresleri { get; set; }
        public DbSet<SirketMailAdresi> SirketMailAdresleri { get; set; }
        public DbSet<YollananMail> YollananMailler { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreateDate= DateTime.Now;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YollananMail>()
                .HasOne(x => x.SirketMailAdresleri)
                .WithMany(y => y.YollananMailler)
                .HasForeignKey(x => x.SirketMailId);

            //KullanıcıMailAdresi ile Yollanan Mail Arasında çoka çok ilişki kuruldu.
            modelBuilder.Entity<KullaniciMailAdresi_YollananMail>()
                .HasKey(x => new { x.YollananMailId, x.KullaniciMailAdresiId });

            modelBuilder.Entity<KullaniciMailAdresi_YollananMail>()
                .HasOne(x => x.KullaniciMailAdresi)
                .WithMany(y => y.YollananMailler)
                .HasForeignKey(x => x.KullaniciMailAdresiId);
            
            modelBuilder.Entity<KullaniciMailAdresi_YollananMail>()
                .HasOne(x => x.YollananMail)
                .WithMany(y => y.KullaniciMailAdresleri)
                .HasForeignKey(x => x.YollananMailId);
        }

    }
}
