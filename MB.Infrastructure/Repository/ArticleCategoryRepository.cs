﻿using MB.Domain.ArticleCategoryApp;
using MB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }
        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }

        public ArticleCategory GetId(long Id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
