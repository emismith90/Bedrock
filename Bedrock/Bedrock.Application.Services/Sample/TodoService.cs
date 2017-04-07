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
using Bedrock.Infrastructure.Caching.Abstract;
using Bedrock.Infrastructure.Configuration.Options;
using Bedrock.Infrastructure.Caching.Keys;
using System.Text;

namespace Bedrock.Application.Services.Sample
{
    public class TodoService : DataServiceBase, ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly CachingOptions _cachingOptions;

        public TodoService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           IBedrockCache cache,
                           CachingOptions cachingOptions,
                           ITodoRepository repository) 
            : base(mapper, unitOfWork, cache)
        {
            this._cachingOptions = cachingOptions;
            this._repository = repository;
        }

        public TodoModel GetById(Guid id)
        {
            return Mapper.Map<TodoModel>(this._repository.GetById(id)); 
        }

        public IList<TodoModel> GetAll()
        {
            IList<TodoModel> todos;

            if (Cache.TryGet(Entities.TodoEntities, out todos))
            {
                return todos;
            }

            try
            {
                todos = Mapper.Map<IEnumerable<TodoModel>>(_repository.GetAll()).ToList();
                Cache.Set(Entities.TodoEntities, todos, TimeSpan.FromMinutes(_cachingOptions.ExpiredInMinute));
                return todos;
            }
            catch
            {
                Cache.Set(Entities.TodoEntities, new List<TodoModel>(), TimeSpan.FromSeconds(_cachingOptions.RetryInSecond));
                return null;
            }
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

            Cache.Flush(Entities.TodoEntities);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            this.UnitOfWork.Commit();

            Cache.Flush(Entities.TodoEntities);
        }

        public void SetStatus(Guid id, bool isActive)
        {
            _repository.SetStatus(id, isActive);
            this.UnitOfWork.Commit();

            Cache.Flush(Entities.TodoEntities);
        }
    }
}
