using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryApp;
using MB.Domain.Exception;

namespace MB.Domain.ArticleCategoryApp.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThisRecordAlredyExists(string title);
    }
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
        public void CheckThisRecordAlredyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new DuplicatedRecordException("Error1: Your blog Title is Alredy..! Please Change It");
        }
    }
}
