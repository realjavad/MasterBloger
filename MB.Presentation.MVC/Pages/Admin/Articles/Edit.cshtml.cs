using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVC.Pages.Admin.Articles
{
    public class EditModel : PageModel
    {

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public List<SelectListItem> ArticleCategoryTitle { get; set; }
        [BindProperty]
        public ArticleViewModel ArticleViewModel { get; set; }

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = categoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleViewModel = _articleApplication.GetBy(id);
            ArticleCategoryTitle = _articleCategoryApplication.List()
                .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost(long id)
        {
            //ArticleViewModel.Id = id;
            _articleApplication.Edit(ArticleViewModel);
            return RedirectToPage("/Admin/Articles/Index");
        }
    }
}
