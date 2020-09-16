using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RawMaterials.Models.Entities;

namespace RawMaterials.Data
{
    public class RawMaterialsContext : IdentityDbContext<User>
    {

        public DbSet<Advertizment> Advertizments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EndedDeal> EndedDeals { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<GlobalPrice> GlobalPrices { get; set; }
        public DbSet<ImporterCategory> ImporterCategory { get; set; }
        public DbSet<InterestMaterial> InterestMaterial { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationSetting> NotificationSettings { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
        public DbSet<PriceLog> PriceLog { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<SuplierCategory> SuplierCategory { get; set; }
        public DbSet<SuplierMaterial> SuplierMaterial { get; set; }
        public DbSet<TeamWork> TeamWork { get; set; }



        public RawMaterialsContext(DbContextOptions<RawMaterialsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advertizment>()
              .HasOne(e => e.TeamWork)
              .WithMany(e => e.Advertizments)
              .HasForeignKey(p => p.TeamWorkId);


            modelBuilder.Entity<PaymentInfo>()
              .HasOne(e => e.User)
              .WithMany(e => e.PaymentInfos);

            modelBuilder.Entity<SuplierCategory>()
            .HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<SuplierCategory>()
            .HasOne(e => e.Suplier)
            .WithMany(e => e.SuplierCategories)
            .HasForeignKey(p => p.SuplierId);

            // -----------------------------------

            modelBuilder.Entity<Notification>()
            .HasOne(e => e.User)
            .WithMany(e => e.Notifications)
            .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<FeedBack>()
            .HasOne(e => e.Importer)
            .WithMany(e => e.FeedBacks)
            .HasForeignKey(p => p.ImporterId);

            modelBuilder.Entity<FeedBack>()
            .HasOne(e => e.Suplier)
            .WithMany(e => e.FeedBacks)
            .HasForeignKey(p => p.SuplierId);

            modelBuilder.Entity<ImporterCategory>()
            .HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ImporterCategory>()
            .HasOne(e => e.Importer)
            .WithMany(e => e.ImporterCategories)
            .HasForeignKey(p => p.ImporterId);

            modelBuilder.Entity<Category>()
            .HasOne(e => e.SuperCategory)
            .WithMany(e => e.SubCategories)
            .HasForeignKey(p => p.SuperCategoryId);

            // -----------------------------

            modelBuilder.Entity<Material>()
             .HasOne(e => e.Category)
             .WithMany(e => e.Materials)
             .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<GlobalPrice>()
             .HasOne(e => e.Material)
             .WithMany()
             .HasForeignKey(p => p.MaterialId);

            modelBuilder.Entity<SuplierMaterial>()
            .HasOne(e => e.Material)
            .WithMany()
            .HasForeignKey(p => p.MaterialId);

            modelBuilder.Entity<SuplierMaterial>()
            .HasOne(e => e.Suplier)
            .WithMany(e => e.SuplierMaterials)
            .HasForeignKey(p => p.SuplierId);

            modelBuilder.Entity<SuplierMaterial>()
            .HasOne(e => e.City)
            .WithMany()
            .HasForeignKey(p => p.CityId);

            modelBuilder.Entity<EndedDeal>()
            .HasOne(e => e.SuplierMaterial)
            .WithMany(e => e.EndedDeals)
            .HasForeignKey(p => p.SuplierMaterialId);

            modelBuilder.Entity<EndedDeal>()
            .HasOne(e => e.Importer)
            .WithMany(e => e.EndedDeals)
            .HasForeignKey(p => p.ImporterId);

            modelBuilder.Entity<InterestMaterial>()
            .HasOne(e => e.SuplierMterial)
            .WithMany()
            .HasForeignKey(p => p.SuplierMterialId);

            modelBuilder.Entity<InterestMaterial>()
            .HasOne(e => e.Importer)
            .WithMany(e => e.InterestMaterials)
            .HasForeignKey(p => p.ImporterId);

            //----------------------------

            modelBuilder.Entity<PriceLog>()
            .HasOne(e => e.SuplierMaterial)
            .WithMany()
            .HasForeignKey(p => p.SuplierMaterialId);

            modelBuilder.Entity<City>()
            .HasOne(e => e.Province)
            .WithMany(e => e.Cities)
            .HasForeignKey(p => p.ProvinceId);

            modelBuilder.Entity<Province>()
            .HasOne(e => e.Country)
            .WithMany(e => e.Provinces)
            .HasForeignKey(p => p.CountryId);


            //------- one to one 

            modelBuilder.Entity<Advertizment>()
            .HasOne(e => e.PaymentInfo)
            .WithOne()
            .HasForeignKey<Advertizment>(p => p.PaymentInfoId);

            modelBuilder.Entity<User>()
            .HasOne(e => e.NotificationSetting)
            .WithOne(e => e.User)
            .HasForeignKey<NotificationSetting>(p => p.UserId);




            // ----------- Attributes properties
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique(true);


        }
    }
}
