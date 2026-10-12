using Microsoft.EntityFrameworkCore;
using News.Controllers;
using News.Models;

namespace News.Repositories.Config
{
    public class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle> //bu IEntityTypeConfiguration<NewsArticle>'e ctrl . yap implement interface ile alttaki konfigürasyonları yazacağımız metot gelsin
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NewsArticle> builder)
        { //configurasyon işlemlerini yazacağımız metot
            /*FluentApı ile birlikte Models klasöründe yazdığımız validasyon işlemlerinin aynısını burada da veritabanı işlemlerinide configure edecek şekilde yazdık*/

            builder.HasKey(article => article.Id);

            builder.Property(article => article.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(article => article.Slug)
                .IsRequired()
                .HasMaxLength(220);

            builder.HasIndex(article => article.Slug)
                .IsUnique(); //ilgili alanı benzersiz yapacak çünkü her haber için URL benzersiz olmalı

            builder.Property(article => article.Summary)
                .HasMaxLength(500);

            builder.Property(article => article.Content)
                .IsRequired();

            builder.Property(article => article.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(article => article.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.HasData(//bu HasData yapısı params.yani virgüllerle ayırarak istediğin kadar article eleyebilirsin
                new NewsArticle()
                {
                    Id = 1,
                    Title = "Yapay Zeka Destekli Haber Üretimi",
                    Slug = "yapay-zeka-destekli-haber-uretimi",
                    Summary = "Yapay zeka destekli iş akışları dijital haber odalarını nasıl döndürüyor",
                    Content = "<p> Yapay zeka, medya kuruluşlarında içerik üretimini hızlandırmaya başladı",
                    PublishedAt = new DateTime(2025, 1, 5, 9, 30, 0, DateTimeKind.Utc),
                    Status=NewsStatus.Published,
                    AuthorName="Btk Akademi"
                },
                 new NewsArticle()
                 {
                     Id = 2,
                     Title = "ASP.NET Core 9.0'daki yenilikler",
                     Slug = "aspnet-core-9-0-yenilikler",
                     Summary = "<p>ASP.NET Core 9.0 güncellemesinde performans iyileştirmeleri",
                     Content = "",
                     PublishedAt = new DateTime(2025, 2, 12, 14, 0, 0, DateTimeKind.Utc),
                     Status = NewsStatus.Published,
                     AuthorName = "Zafer Yazar"
                 },
                 new NewsArticle()
                 {
                     Id = 3,
                     Title = "Editör Notları",
                     Slug = "editor-notlari",
                     Summary = "Haftalık editoryal öne çıkanlar ve yaklaşan içerik planları",
                     Content = "<p>Bu hafta öne çıkan konulara odaklanıyor ve üretim planımızın dışını yönetiyor",
                     PublishedAt = null,
                     Status = NewsStatus.Draft,
                     AuthorName = "Genel Yayın Yönetmeni"
                 });
        }
    }
}
