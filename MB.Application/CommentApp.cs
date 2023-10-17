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
         
        public void ConfirmStatus(CommentViewModel comment)
        {
            var result = _commentRepository.GetById(comment.Id);
            _commentRepository.ConfirmStatus(result);
        }

        public void Create(CreateComment comment)
        {
            var result = new Comment(comment.Name,comment.Email,comment.Message,comment.ArticleId);
            _commentRepository.Create(result);
        }

        public CommentViewModel GetBy(long id)
        {
            var result = _commentRepository.GetById(id);
            return new CommentViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Email = result.Email,
                Message = result.Message,
                Status = result.Status,
                Vote = result.Vote,
                Article = result.Articles.ToString(),
                ArticleId = result.ArticleId,
                Creationdate = result.CreationDate.ToString()
            };
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
                Vote = x.Vote,
                ArticleId = x.ArticleId,
                Article = x.Articles.Title.ToString()
            }).ToList();
        }

        public void RejectStatus(CommentViewModel comment)
        {
            var result = _commentRepository.GetById(comment.Id);
            _commentRepository.RejectStatus(result);
        }

        public void Vote(long Id)
        {
            var result = _commentRepository.GetById(Id);
            _commentRepository.Vote(result);
        }
    }
}
