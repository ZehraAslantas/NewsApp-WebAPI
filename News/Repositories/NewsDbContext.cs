using Microsoft.EntityFrameworkCore;
using News.Models;
using News.Repositories.Config;

namespace News.Repositories;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
    {
        
    }
    public DbSet<NewsArticle> NewsArticles => Set<NewsArticle>();
    //tablo adı NewsArticles
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new NewsArticleConfiguration()); 
    }
}
