using System.Globalization;
using MB.Domain.ArticleAgg;
using MB.Domain.Comment;
using MB.Domain.Helper;
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
            ArticleCategory = x.ArticleCategory.Title,
            CommentCount = x.Comments.Count(c=>c.Status == StatusHelper.Confirmed)
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
            ArticleCategory = x.ArticleCategory.Title,
            Comments = MapComents(x.Comments.Where(c=>c.Status == StatusHelper.Confirmed))
        }).FirstOrDefault(x => x.Id == Id);
    }

    private static List<CommentQueryView> MapComents(IEnumerable<Comment> Comments)
    {
        var result = new List<CommentQueryView>();
        foreach (var comment in Comments)
        {
            result.Add(new CommentQueryView()
            {
                Id = comment.Id,
                Name = comment.Name,
                Message = comment.Message,
                CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                Vote = comment.Vote
            });
        }
        return result;
    }
}