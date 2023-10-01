using MB.Domain.ArticleAgg;
using MB.Infrastructure.Quary;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleQuary _articleQuary;
        public ArticleQuaryView GetFirst { get; set; }
        public List<ArticleQuaryView> Articles { get; set; }
        public IndexModel(ILogger<IndexModel> logger,IArticleQuary articleQuary)
        {
            _logger = logger;
            _articleQuary = articleQuary;
        }

        public void OnGet()
        {
            Articles = _articleQuary.GetArticles();
            GetFirst = Articles.FirstOrDefault();
            Articles.Remove(Articles.FirstOrDefault());
            
        }
    }
}