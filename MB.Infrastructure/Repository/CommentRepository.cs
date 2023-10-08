using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.Comment;
using MB.Domain.CommentAgg;
using MB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public List<Comment> GetList()
        {
           return _context.Comments.Include(x => x.ArticleId).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
