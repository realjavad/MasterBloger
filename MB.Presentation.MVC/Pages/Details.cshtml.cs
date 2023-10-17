using MB.Application.Contracts.Comment;
using MB.Application.Contracts.ViewModels;
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
        public List<CommentViewModel> ConfirmComments { get; set; }

        public DetailsModel(IArticleQuary articleQuary,ICommentApp commentApp)
        {
            _articleQuary = articleQuary;
            _commentApp = commentApp;
        }

        public void OnGet(long Id)
        {
            ArticleDetails  = _articleQuary.GetBy(Id);
            //ConfirmComments = _commentApp.GetList().Where(x=>x.Status == 1 && x.Article == ArticleDetails.Title).ToList();

        }

        public IActionResult OnPost(CreateComment comment)
        {
            comment.ArticleId = ArticleDetails.Id;
            _commentApp.Create(comment);
            return Page();
        }

        public RedirectToPageResult OnPostCounter(long Id)
        {
            _commentApp.Vote(Id);
            //ArticleDetails = _articleQuary.GetBy(Vote.ArticleId);
            //ConfirmComments = _commentApp.GetList().Where(x => x.Status == 1 && x.Article == ArticleDetails.Title).ToList();
            return RedirectToPage("./Details");

        }
    }
}
