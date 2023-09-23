using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVC.Pages.Admin.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public List<SelectListItem> ArticleCategory { get; set; }
        public CreateModel(IArticleCategoryApplication articleCategory,IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategory;
            _articleApplication = articleApplication;
        }
        public void OnGet()
        {
            ArticleCategory = _articleCategoryApplication.List().Select(e=> new SelectListItem(e.Title,e.Id.ToString())).ToList();
        }

        public void OnPost(CreateArticleViewModel CreateArticleViewModel)
        {
            _articleApplication.Create(CreateArticleViewModel);
        }
    }
}
