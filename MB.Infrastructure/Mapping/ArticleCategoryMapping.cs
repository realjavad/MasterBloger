using MB.Domain.ArticleCategoryApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now.ToString());
            builder.Property(x => x.IsDeleted).HasDefaultValue("false");
            builder.HasMany(x => x.Articles).WithOne(x => x.ArticleCategory).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
