using _01_Feactures;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryApp;
using MB.Domain.ArticleCategoryApp.Services;
using MB.Domain.Exception;

namespace MB.Domain.ArticleCategoryApp
{
    public class ArticleCategory : DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
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
