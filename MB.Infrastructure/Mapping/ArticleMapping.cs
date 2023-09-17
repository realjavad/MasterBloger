using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Content);
            builder.Property(x=>x.IsDelete);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.Image);
            builder.Property(x => x.ShortDescription);
            builder
                .HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
