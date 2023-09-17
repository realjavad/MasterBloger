using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ViewModels;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetAll().Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDelete,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.ToString()
            }).ToList();
        }
    }
}
