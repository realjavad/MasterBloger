using MB.Application.Contracts.Article;
using MB.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages.Admin.Articles
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public CreateArticleViewModel CreateArticleViewModel { get; set; }

        public EditModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        public void OnGet(long id)
        {
            CreateArticleViewModel = _articleApplication.GetBy(id);
        }
    }
}
