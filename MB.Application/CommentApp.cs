using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Application.Contracts.ViewModels;
using MB.Domain.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApp : ICommentApp
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApp(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Create(CreateComment comment)
        {
            var result = new Comment(comment.Name,comment.Email,comment.Message,comment.ArticleId);
            _commentRepository.Create(result);
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList().Select(x => new CommentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Creationdate = x.CreationDate.ToString(),
                Status = x.Status,
                Article = x.Articles.ToString()
            }).ToList();
        }
    }
}
