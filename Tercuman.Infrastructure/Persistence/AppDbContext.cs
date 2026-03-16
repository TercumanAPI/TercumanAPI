using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Entities;

namespace Tercuman.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingImage> ListingImages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ListingView> ListingViews { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Listing (1-N)
            modelBuilder.Entity<Listing>()
                .HasOne(l => l.User)
                .WithMany(u => u.Listings)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Listing - Images (1-N)
            modelBuilder.Entity<ListingImage>()
                .HasOne(i => i.Listing)
                .WithMany(l => l.Images)
                .HasForeignKey(i => i.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Message Sender
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Message Receiver
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Favorite
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Listing)
                .WithMany(l => l.Favorites)
                .HasForeignKey(f => f.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasIndex(f => new { f.UserId, f.ListingId })
                .IsUnique();

            modelBuilder.Entity<Listing>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.City)
                .WithMany(c => c.Listings)
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Listing>()
               .HasOne(l => l.SourceLanguage)
               .WithMany()
               .HasForeignKey(l => l.SourceLanguageId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.TargetLanguage)
                .WithMany()
                .HasForeignKey(l => l.TargetLanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Conversation
            modelBuilder.Entity<Conversation>()
               .HasOne(c => c.User1)
               .WithMany()
               .HasForeignKey(c => c.User1Id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.User2)
                .WithMany()
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Restrict);

            var createdDate = new DateTime(2026, 1, 1);

            modelBuilder.Entity<City>().HasData(

                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Adana", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Adıyaman", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Afyonkarahisar", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Ağrı", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Amasya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Ankara", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Antalya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Artvin", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Aydın", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Balıkesir", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Bilecik", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Bingöl", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Bitlis", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Bolu", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Burdur", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Bursa", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Çanakkale", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "Çankırı", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Name = "Çorum", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), Name = "Denizli", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000021"), Name = "Diyarbakır", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000022"), Name = "Edirne", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000023"), Name = "Elazığ", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000024"), Name = "Erzincan", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000025"), Name = "Erzurum", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000026"), Name = "Eskişehir", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000027"), Name = "Gaziantep", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000028"), Name = "Giresun", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000029"), Name = "Gümüşhane", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000030"), Name = "Hakkari", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000031"), Name = "Hatay", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000032"), Name = "Isparta", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000033"), Name = "Mersin", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000034"), Name = "İstanbul", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000035"), Name = "İzmir", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000036"), Name = "Kars", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000037"), Name = "Kastamonu", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000038"), Name = "Kayseri", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000039"), Name = "Kırklareli", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000040"), Name = "Kırşehir", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000041"), Name = "Kocaeli", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000042"), Name = "Konya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000043"), Name = "Kütahya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000044"), Name = "Malatya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000045"), Name = "Manisa", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000046"), Name = "Kahramanmaraş", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000047"), Name = "Mardin", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000048"), Name = "Muğla", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000049"), Name = "Muş", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000050"), Name = "Nevşehir", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000051"), Name = "Niğde", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000052"), Name = "Ordu", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000053"), Name = "Rize", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000054"), Name = "Sakarya", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000055"), Name = "Samsun", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000056"), Name = "Siirt", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000057"), Name = "Sinop", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000058"), Name = "Sivas", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000059"), Name = "Tekirdağ", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000060"), Name = "Tokat", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000061"), Name = "Trabzon", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000062"), Name = "Tunceli", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000063"), Name = "Şanlıurfa", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000064"), Name = "Uşak", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000065"), Name = "Van", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000066"), Name = "Yozgat", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000067"), Name = "Zonguldak", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000068"), Name = "Aksaray", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000069"), Name = "Bayburt", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000070"), Name = "Karaman", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000071"), Name = "Kırıkkale", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000072"), Name = "Batman", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000073"), Name = "Şırnak", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000074"), Name = "Bartın", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000075"), Name = "Ardahan", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000076"), Name = "Iğdır", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000077"), Name = "Yalova", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000078"), Name = "Karabük", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000079"), Name = "Kilis", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000080"), Name = "Osmaniye", CreatedDate = createdDate, IsDeleted = false },
                new City { Id = Guid.Parse("00000000-0000-0000-0000-000000000081"), Name = "Düzce", CreatedDate = createdDate, IsDeleted = false }

            );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Türkçe", Code = "tr" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Arapça", Code = "ar" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "İngilizce", Code = "en" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Almanca", Code = "de" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Fransızca", Code = "fr" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "İspanyolca", Code = "es" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "İtalyanca", Code = "it" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Rusça", Code = "ru" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Çince", Code = "zh" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Japonca", Code = "ja" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Korece", Code = "ko" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Portekizce", Code = "pt" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Hollandaca", Code = "nl" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Yunanca", Code = "el" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Farsça", Code = "fa" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Hintçe", Code = "hi" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Urduca", Code = "ur" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "İbranice", Code = "he" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Name = "İsveççe", Code = "sv" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), Name = "Norveççe", Code = "no" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000021"), Name = "Danca", Code = "da" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000022"), Name = "Fince", Code = "fi" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000023"), Name = "Lehçe", Code = "pl" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000025"), Name = "Macarca", Code = "hu" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000026"), Name = "Romence", Code = "ro" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000027"), Name = "Bulgarca", Code = "bg" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000028"), Name = "Sırpça", Code = "sr" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000029"), Name = "Hırvatça", Code = "hr" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000030"), Name = "Boşnakça", Code = "bs" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000031"), Name = "Arnavutça", Code = "sq" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000032"), Name = "Ukraynaca", Code = "uk" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000033"), Name = "Gürcüce", Code = "ka" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000034"), Name = "Ermenice", Code = "hy" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000035"), Name = "Tayca", Code = "th" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000036"), Name = "Vietnamca", Code = "vi" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000037"), Name = "Malayca", Code = "ms" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000038"), Name = "Endonezce", Code = "id" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000039"), Name = "Svahili", Code = "sw" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000040"), Name = "Afrikanca", Code = "af" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000041"), Name = "Amharca", Code = "am" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000042"), Name = "Azerice", Code = "az" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000043"), Name = "Kazakça", Code = "kk" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000044"), Name = "Özbekçe", Code = "uz" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000045"), Name = "Türkmence", Code = "tk" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000046"), Name = "Kürtçe", Code = "ku" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000047"), Name = "Peştuca", Code = "ps" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000048"), Name = "Bengalce", Code = "bn" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000049"), Name = "Tamilce", Code = "ta" },
                new Language { Id = Guid.Parse("00000000-0000-0000-0000-000000000050"), Name = "Teluguca", Code = "te" }
               );
        }   
        }
    }
    

