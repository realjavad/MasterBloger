﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article GetById(long id);
        void CreateArticle(Article entity);
        bool Exist(string title);
        void Save();
    }
}
