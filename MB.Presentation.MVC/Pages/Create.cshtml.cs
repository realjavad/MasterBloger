using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        [TempData]
        public string ErrorMessage { get; set; }
        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateArtcleCategory create)
        {
            if (ModelState.IsValid)
            {
                _articleCategoryApplication.Create(create);
                return RedirectToPage("./Admin/index");
            }
            else
            {
                ErrorMessage = "Please Insert Your Blog Name..!";
                return null;
            }
        }
    }
}
