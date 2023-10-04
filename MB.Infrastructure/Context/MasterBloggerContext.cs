using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryApp;
using MB.Domain.Comment;
using MB.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Context
{
    public class MasterBloggerContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public  DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public MasterBloggerContext()
        {

        }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var assembly = typeof(ArticleMapping).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //or
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
