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

        public void Create(CreateArticleViewModel Article)
        {
            var result = new Article(Article.Title, Article.ShortDescription, Article.Image, Article.Content,
                Article.ArticleCategoryId);
            _articleRepository.CreateArticle(result);
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetAll().Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDelete,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
        }

        public CreateArticleViewModel GetBy(long Id)
        {
            var result = _articleRepository.GetById(Id);
            return new CreateArticleViewModel() {Title = result.Title,Image = result.Image,Content = result.Content,ShortDescription = result.ShortDescription,ArticleCategoryId = result.ArticleCategoryId};
        }

        public void IsDeleted(long id)
        {
            var userArticle = _articleRepository.GetById(id);
            if (userArticle.IsDelete)
            {
                userArticle.IsDeleted(false);
            }
            else
            {
                userArticle.IsDeleted(true);
            }
            _articleRepository.Save();
        }
    }
}


//create method to get id and return article category tiltle