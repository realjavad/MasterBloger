using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.ViewModels;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetArticles();
        void Create(CreateArticleViewModel Article);
        CreateArticleViewModel GetBy(long Id);
        void IsDeleted(long id);
    }
}
