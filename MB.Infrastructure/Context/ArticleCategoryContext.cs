using MB.Domain.ArticleCategoryApp;
using MB.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Context
{
    public class ArticleCategoryContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public ArticleCategoryContext()
        {

        }
        public ArticleCategoryContext(DbContextOptions<ArticleCategoryContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
