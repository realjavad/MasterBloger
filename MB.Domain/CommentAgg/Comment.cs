using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;
using MB.Domain.Helper;

namespace MB.Domain.Comment
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int Status { get; private set; }
        public long ArticleId { get; private set; }
        public Article Articles { get; private set; }


        protected Comment()
        {
        }

        public Comment(string name, string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate = DateTime.Now;
            Status = StatusHelper.New;
        }

        public void RejectStatus()
        {
            Status = StatusHelper.Canceled;
        }
        public void ConfirmStatus()
        {
            Status = StatusHelper.Confirmed;
        }
    }
}
