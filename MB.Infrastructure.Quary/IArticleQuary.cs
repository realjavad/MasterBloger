using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.Quary
{
    public interface IArticleQuary
    {
        List<ArticleQuaryView> GetArticles();
        ArticleQuaryView GetBy(long Id);
    }
}
