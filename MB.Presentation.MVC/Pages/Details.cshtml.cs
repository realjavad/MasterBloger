using MB.Application.Contracts.Comment;
using MB.Infrastructure.Quary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IArticleQuary _articleQuary;
        private readonly ICommentApp _commentApp;
        [BindProperty]
        public ArticleQuaryView ArticleDetails { get; set; }
        [BindProperty]
        public CreateComment comment { get; set; }
        public DetailsModel(IArticleQuary articleQuary,ICommentApp commentApp)
        {
            _articleQuary = articleQuary;
            _commentApp = commentApp;
        }

        public void OnGet(long Id)
        {
            ArticleDetails  = _articleQuary.GetBy(Id);
        }

        public IActionResult OnPost(CreateComment comment)
        {
            comment.ArticleId = ArticleDetails.Id;
            _commentApp.Create(comment);
            return Page();
        }
    }
}
