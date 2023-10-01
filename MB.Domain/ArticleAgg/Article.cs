using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryApp;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription{ get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId, IArticleValidatorService service)
        {
            service.CheckThisRecordAlredyExists(title);
            Validate(title, articleCategoryId);
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDelete = false;
            CreationDate = DateTime.Now;
        }

        private static void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException();
            if (articleCategoryId == 0)
                throw new ArgumentOutOfRangeException();
        }

        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Validate(title,articleCategoryId);
            this.Title = title;
            this.ShortDescription = shortDescription;
            this.Image = image;
            this.Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void IsDeleted(bool text)
        {
            this.IsDelete = text;
        }
    }
}
