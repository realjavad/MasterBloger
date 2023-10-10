using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        List<Comment.Comment> GetList();
        void Create(Comment.Comment comment);
        Comment.Comment GetById(long id);
        void RejectStatus(Comment.Comment comment);
        void ConfirmStatus(Comment.Comment comment);
        void Save();
    }
}
