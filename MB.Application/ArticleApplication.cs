using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ViewModels;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorService _ValidatorService;
        public ArticleApplication(IArticleRepository articleRepository,IArticleValidatorService validatorService)
        {
            _articleRepository = articleRepository;
            _ValidatorService = validatorService;
        }

        public void Create(CreateArticleViewModel Article)
        {
            var result = new Article(Article.Title, Article.ShortDescription, Article.Image, Article.Content,
                Article.ArticleCategoryId,_ValidatorService);
            _articleRepository.CreateArticle(result);
        }

        public void Edit(ArticleViewModel Article)
        {
            var result = _articleRepository.GetById(Article.Id);

            result.Edit(Article.Title,Article.ShortDescription,Article.Image,Article.Content,Article.ArticleCategoryId);

            _articleRepository.Save();
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

        public ArticleViewModel GetBy(long Id)
        {
            var result = _articleRepository.GetById(Id);
            return new ArticleViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Image = result.Image,
                Content = result.Content,
                ShortDescription = result.ShortDescription,
                ArticleCategoryId = result.ArticleCategoryId,
                CategoryTitle = result.ArticleCategory.Title
            };
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