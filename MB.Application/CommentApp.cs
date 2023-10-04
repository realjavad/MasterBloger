using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
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
    }
}
