using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using Bedrock.Application.Services.Abstract.Sample;
using Bedrock.Application.Model;
using Bedrock.Domain.Abstract.UoW;
using Bedrock.Domain.Abstract.Repositories;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Application.Services.Sample
{
    public class TodoService : DataServiceBase, ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           IMemoryCache cache,
                           ITodoRepository repository) 
            : base(mapper, unitOfWork, cache)
        {
            this._repository = repository;
        }

        public TodoModel GetById(Guid id)
        {
            return Mapper.Map<TodoModel>(this._repository.GetById(id));
        }

        public IList<TodoModel> GetAll()
        {
            IList<TodoModel> todos;
            //if (!Cache.TryGetValue(, out todos))
            //{
                // Key not in cache, so get data.
                todos = Mapper.Map<IEnumerable<TodoModel>>(_repository.GetAll()).ToList();

                // Set cache options.
            //    var cacheEntryOptions = new MemoryCacheEntryOptions()
            //        // Keep in cache for this time, reset time if accessed.
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            //    // Save data in cache.
            //    Cache.Set(CacheKeys.Entry, todos, cacheEntryOptions);
            //}

            return todos;
        }

        public void Add(TodoModel todo)
        {
            _repository.Add(Mapper.Map<TodoEntity>(todo));
            this.UnitOfWork.Commit();
        }

        public void Update(TodoModel todo)
        {
            _repository.Update(Mapper.Map<TodoEntity>(todo));
            this.UnitOfWork.Commit();
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            this.UnitOfWork.Commit();
        }

        public void SetStatus(Guid id, bool isActive)
        {
            _repository.SetStatus(id, isActive);
            this.UnitOfWork.Commit();
        }
    }
}
