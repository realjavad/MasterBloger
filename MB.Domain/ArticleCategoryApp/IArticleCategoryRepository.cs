namespace MB.Domain.ArticleCategoryApp
{
    public interface IArticleCategoryRepository
    {
        void Create(ArticleCategory entity);
        List<ArticleCategory> GetAll();
        ArticleCategory GetId(long Id);
        void Save();
        bool Exists(string title);
    }
}
