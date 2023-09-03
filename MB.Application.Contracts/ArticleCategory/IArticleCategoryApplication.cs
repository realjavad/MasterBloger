using MB.Application.Contracts.ViewModel;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArtcleCategory command);
        void Edit(EditArticleCategory command);
        void Delelte(long id);
        EditArticleCategory GetBlogBy(long id);
    }
}
