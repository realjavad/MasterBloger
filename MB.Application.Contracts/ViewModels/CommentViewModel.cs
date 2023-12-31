﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ViewModels
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Creationdate { get; set; }
        public int Status { get; set; }
        public int Vote { get; set; }
        public string Article { get; set; }
        public long  ArticleId { get; set; }
    }
}
