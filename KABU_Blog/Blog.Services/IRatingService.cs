﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IRatingService : IEntityService<Rating>
    {
        Task<Rating> FindById(string id, params Expression<Func<Rating, object>>[] includes);
    }
}