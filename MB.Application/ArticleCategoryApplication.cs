using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.ViewModel;
using MB.Domain.ArticleCategoryApp;
using System.Globalization;
using MB.Domain.ArticleCategoryApp.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _categoryRepository;
        private readonly  IArticleCategoryValidatorService _validatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository categoryRepository, IArticleCategoryValidatorService validatorService)
        {
            _categoryRepository = categoryRepository;
            _validatorService = validatorService;
        }

        public void Create(CreateArtcleCategory command)
        {
            var result = new ArticleCategory(command.Title, _validatorService);
            _categoryRepository.Create(result);
        }

        public void Edit(EditArticleCategory command)
        {
            var result = _categoryRepository.GetId(command.Id);
            result.Edit(command.Title);
            _categoryRepository.Save();
        }

        public EditArticleCategory GetBlogBy(long id)
        {
            var result = _categoryRepository.GetId(id);
            return new EditArticleCategory { Id = result.Id, Title = result.Title };

        }

        public List<ArticleCategoryViewModel> List()
        {
            var result = _categoryRepository.GetAll().Select(x => new ArticleCategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                creationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = x.IsDeleted
            }).ToList();
            return result;
        }

        public void Delelte(long id)
        {
            var userBlog = _categoryRepository.GetId(id);
            if (userBlog.IsDeleted == true)
            {
                userBlog.isDeletedStatus(false);
            }
            else
            {
                userBlog.isDeletedStatus(true);
            }
            _categoryRepository.Save();
        }
    }
}
