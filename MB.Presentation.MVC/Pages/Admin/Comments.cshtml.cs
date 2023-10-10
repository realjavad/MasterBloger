using MB.Application.Contracts.Comment;
using MB.Application.Contracts.ViewModels;
using MB.Domain.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages.Admin
{
    public class CommentsModel : PageModel
    {
        private readonly ICommentApp _commentApp;
        [BindProperty]
        public List<CommentViewModel> Comment { get; set; }
        public CommentsModel(ICommentApp commentApp)
        {
            _commentApp = commentApp;
        }
        public void OnGet()
        {
            Comment = _commentApp.GetList();
        }

        public IActionResult OnPostConfirme(long id)
        {
            var result = _commentApp.GetBy(id);
            _commentApp.ConfirmStatus(result);
            Comment = _commentApp.GetList();
            return Page();
        }
        public IActionResult OnPostReject(long id)
        {
            var result = _commentApp.GetBy(id);
            _commentApp.RejectStatus(result);
            Comment = _commentApp.GetList();
            return Page();
        }
    }
}
