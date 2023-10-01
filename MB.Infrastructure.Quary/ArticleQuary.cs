using System.Globalization;
using MB.Domain.ArticleAgg;
using MB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Quary;

public class ArticleQuary : IArticleQuary
{
    private readonly MasterBloggerContext _context;

    public ArticleQuary(MasterBloggerContext context)
    {
        _context = context;
    }
    public List<ArticleQuaryView> GetArticles()
    {
        return _context.Articles.Include(c => c.ArticleCategory).Select(x => new ArticleQuaryView()
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Content = x.Content,
            Image = x.Image,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ArticleCategory = x.ArticleCategory.Title
        }).ToList();
    }

    public ArticleQuaryView GetBy(long Id)
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQuaryView()
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Content = x.Content,
            Image = x.Image,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ArticleCategory = x.ArticleCategory.Title
        }).FirstOrDefault(x => x.Id == Id);
    }
}