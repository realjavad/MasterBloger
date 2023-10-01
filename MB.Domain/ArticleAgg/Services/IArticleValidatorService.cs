using MB.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThisRecordAlredyExists(string title);
    }

    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void CheckThisRecordAlredyExists(string title)
        {
            if (_articleRepository.Exist(title))
            throw new DuplicatedRecordException("Error: Your Title is Alredy..! Please Change It");
        }
    }
}
