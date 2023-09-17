using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryApp.Exception;
using MB.Domain.ArticleCategoryApp.Services;

namespace MB.Domain.ArticleCategoryApp
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(string title, IArticleCategoryValidatorService service)
        {
            service.CheckThisRecordAlredyExists(title);
            GuadAgainsEmptyTitle(title);

            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }

        public void GuadAgainsEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DuplicatedRecordException("Error2: Your blog Title is Alredy..! Please Change It");
            }
        }

        public void Edit(string title)
        {
            Title = title;
        }

        public void isDeletedStatus(bool text)
        {
            this.IsDeleted = text;
        }
    }
}
