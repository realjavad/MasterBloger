using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryApp;
using MB.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Context
{
    public class MasterBloggerContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public  DbSet<Article> Articles { get; set; }
        public MasterBloggerContext()
        {

        }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
