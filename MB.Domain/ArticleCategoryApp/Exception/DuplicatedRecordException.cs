using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryApp.Exception
{
    public class DuplicatedRecordException : System.Exception
    {
        public DuplicatedRecordException()
        {
        }
        public DuplicatedRecordException(string Message) : base(Message)
        {
        }
    }
}
