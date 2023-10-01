using MB.Infrastructure.Quary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IArticleQuary _articleQuary;
        public ArticleQuaryView ArticleDetails { get; set; } 
        public DetailsModel(IArticleQuary articleQuary)
        {
            _articleQuary = articleQuary;
        }

        public void OnGet(long Id)
        {
            ArticleDetails  = _articleQuary.GetBy(Id);
        }
    }
}
