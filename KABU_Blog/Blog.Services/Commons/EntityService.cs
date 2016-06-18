using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Common.Extensions;
using Blog.Models.Commons;
using Blog.Repositories.Commons;
using Blog.Services.UnitOfWork;

namespace Blog.Services.Commons
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Create(T entity)
        {
            entity.ThrowIfNull(nameof(entity));

            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            entity.ThrowIfNull(nameof(entity));

            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void Update(T entity)
        {
            entity.ThrowIfNull(nameof(entity));

            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _repository.Get(predicate, includes); ;
        }

        public Task<IQueryable<T>> Get( params Expression<Func<T, object>>[] includes)
        {
            return _repository.Get(includes); ;
        }

        public Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _repository.FindBy(predicate, includes);
        }
    }


}
