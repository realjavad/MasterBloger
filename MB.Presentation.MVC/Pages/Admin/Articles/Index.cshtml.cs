using MB.Application.Contracts.Article;
using MB.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages.Admin
{
    public class ArticlesModel : PageModel
    {
        public List<ArticleViewModel> articles { get; set; }
        private readonly IArticleApplication _articleApplication;
        [BindProperty]
        public long id { get; set; }
        public ArticlesModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        public void OnGet()
        {
            articles = _articleApplication.GetArticles();
        }

        public IActionResult OnPost()
        {
            _articleApplication.IsDeleted(id);
            articles = _articleApplication.GetArticles();
            return Page();
        }
    }
}
