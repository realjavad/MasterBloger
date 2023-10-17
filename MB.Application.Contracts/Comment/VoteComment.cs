using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Comment
{
    public class VoteComment
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
    }
}
