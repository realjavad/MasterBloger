using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<ArticleCategoryViewModel> ArticleCategoriesList { get; set; }
        [BindProperty]
        public long Id { get; set; }
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
            ArticleCategoriesList = _articleCategoryApplication.List();
        }
        public IActionResult OnPost(long id)
        {
            //var result = _articleCategoryApplication.GetBlogIdForDel(id);
            _articleCategoryApplication.Delelte(id);
            ArticleCategoriesList = _articleCategoryApplication.List();
            return Page();

        }
    }
}
