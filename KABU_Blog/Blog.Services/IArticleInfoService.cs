﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IArticleInfoService : IEntityService<ArticleInfo>
    {
        Task<ArticleInfo> FindById<TProperty>(int id, params Expression<Func<ArticleInfo, TProperty>>[] includes);
    }
}