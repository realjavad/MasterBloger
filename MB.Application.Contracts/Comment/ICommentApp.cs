﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.ViewModels;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApp
    {
        List<CommentViewModel> GetList();
        void Create(CreateComment comment);
    }
}
