﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ILanguageService:IEntityService<Language>
    {
        Task<Language> FindById(string id, params Expression<Func<Language, object>>[] includes);
    }
}