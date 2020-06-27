using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AdvertApi.Models
{
    public class AdvertApiContext : DbContext
    {

        public AdvertApiContext()
        {
                
        }

        public AdvertApiContext(DbContextOptions<AdvertApiContext> options) : base(options)
        {

        }


        public DbSet<Banner> Banners { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Kiedy byśmy mieli więcej klas rozdzielibłym to do oddielnych klasy

            modelBuilder.Entity<Banner>(opt =>
            {

                opt.HasKey(k => k.IdAdvertisement);
                opt.Property(k => k.IdAdvertisement).ValueGeneratedOnAdd();

                opt.Property(m => m.Price).HasColumnType("decimal(6,2)");
                opt.Property(m => m.Area).HasColumnType("decimal(6,2)");

              
            });


            modelBuilder.Entity<Building>(opt => {

                opt.HasKey(k => k.IdBuilding);
                opt.Property(k => k.IdBuilding).ValueGeneratedOnAdd();

                opt.Property(m => m.Street).HasMaxLength(100).IsRequired();
                opt.Property(m => m.City).HasMaxLength(100).IsRequired();

                opt.Property(m => m.Height).HasColumnType("decimal(6,2)");


            });


            modelBuilder.Entity<Client>(opt => {

                opt.HasKey(k => k.IdClient);
                opt.Property(k => k.IdClient).ValueGeneratedOnAdd();

                opt.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
                opt.Property(m => m.LastName).HasMaxLength(100).IsRequired();
                opt.Property(m => m.Email).HasMaxLength(100).IsRequired();
                opt.Property(m => m.Phone).HasMaxLength(100).IsRequired();
                opt.Property(m => m.Login).HasMaxLength(100).IsRequired();
                opt.Property(m => m.Password).HasMaxLength(100).IsRequired();
                opt.Property(m => m.Salt).HasMaxLength(200).IsRequired();
                opt.Property(m => m.RefreshToken).HasMaxLength(300);


            });


            modelBuilder.Entity<Campaign>(opt => {

                opt.HasKey(k => k.IdCampaign);

                opt.Property(m => m.PricePerSquareMeter).HasColumnType("decimal(6,2)");

                opt.HasOne(m => m.BuildingFromId).WithMany(m => m.CampaignsFromIdBuilding).HasForeignKey(k => k.FromIdBuilding).OnDelete(DeleteBehavior.ClientSetNull);
                opt.HasOne(m => m.BuildingToId).WithMany(m => m.CampaignsToIdBuilding).HasForeignKey(k => k.ToIdBuilding).OnDelete(DeleteBehavior.ClientSetNull);

                opt.HasOne(m => m.Client).WithMany(m => m.Campaigns).HasForeignKey(k => k.IdClient).OnDelete(DeleteBehavior.ClientSetNull);

                opt.HasMany(m => m.Banners).WithOne(m => m.IdCampaignBanner).HasForeignKey(k => k.IdCampaing).OnDelete(DeleteBehavior.ClientSetNull);

            });





        }



    }
}
