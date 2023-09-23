using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;
using MB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repository
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public List<Article> GetAll()
        {
            return _context.Articles.Include(x => x.ArticleCategory).ToList();
        }

        public Article GetById(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
