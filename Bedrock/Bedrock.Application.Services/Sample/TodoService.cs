using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Bedrock.Application.Services.Abstract.Sample;
using Bedrock.Application.Model;
using Bedrock.Domain.Abstract.UoW;
using Bedrock.Domain.Abstract.Repositories;
using Bedrock.Domain.Data.Models;
using Bedrock.Infrastructure.Caching.Abstract;
using Bedrock.Infrastructure.Configuration.Options;
using Bedrock.Infrastructure.Caching.Keys;

namespace Bedrock.Application.Services.Sample
{
    public class TodoService : DataServiceBase, ITodoService
    {
        private readonly ITodoRepository _repository;
        private readonly CachingOptions _cachingOptions;
        private readonly ILogger _logger;

        public TodoService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           ITodoRepository repository,
                           IBedrockCache cache,
                           CachingOptions cachingOptions,
                           ILogger<TodoService> logger) 
            : base(mapper, unitOfWork, cache)
        {
            this._logger = logger;
            this._cachingOptions = cachingOptions;
            this._repository = repository;
        }

        public TodoModel GetById(Guid id)
        {
            _logger.LogInformation("Querying todo item {todoid}...", id);
            var todo = Mapper.Map<TodoModel>(this._repository.GetById(id));

            if(todo == null)
            {
                _logger.LogWarning("Not found todo {todoid}...", id);
            }
            else
            {
                _logger.LogInformation("Found todo {todoid}...", id);
            }

            return todo;
        }

        public IList<TodoModel> GetAll()
        {
            IList<TodoModel> todos;
            _logger.LogInformation("Checking cache...");
            if (Cache.TryGet(Entities.TodoEntities, out todos))
            {
                _logger.LogInformation("Found {todocount} item(s) on cache['{cachekey}'].", todos.Count, Entities.TodoEntities);
                return todos;
            }

            try
            {
                _logger.LogWarning("Cache['{cachekey}'] not found.", Entities.TodoEntities);
                _logger.LogInformation("Querying from the db...");
                todos = Mapper.Map<IEnumerable<TodoModel>>(_repository.GetAll()).ToList();

                _logger.LogInformation("Query finished. There are {todocount} item(s)", todos.Count);
                Cache.Set(Entities.TodoEntities, todos, TimeSpan.FromMinutes(_cachingOptions.ExpiredInMinute));
                _logger.LogInformation("Saved to cache['{cachekey}'], expired in {1} minute(s)", Entities.TodoEntities, _cachingOptions.ExpiredInMinute);
                
                return todos;
            }
            catch(Exception ex)
            {
                _logger.LogError("{error} {stacktrace}", ex.Message, ex.StackTrace);
                Cache.Set(Entities.TodoEntities, new List<TodoModel>(), TimeSpan.FromSeconds(_cachingOptions.RetryInSecond));
                _logger.LogWarning("Saved empty model to cache['{cachekey}'], allow to retry in next {1} second(s).", Entities.TodoEntities, _cachingOptions.RetryInSecond);
                return null;
            }
        }

        public void Add(TodoModel todo)
        {
            _logger.LogInformation("Adding new todo item...");
            var todoEntity = Mapper.Map<TodoEntity>(todo);
            _repository.Add(todoEntity);
            this.UnitOfWork.Commit();
            _logger.LogInformation("Saved {todoid} to database.", todoEntity.Id);

            Cache.Flush(Entities.TodoEntities);
            _logger.LogInformation("Flushed cache['{cachekey}'].", Entities.TodoEntities);
        }

        public void Update(TodoModel todo)
        {
            _logger.LogInformation("Updating todo item {todoid}...", todo.Id);
            _repository.Update(Mapper.Map<TodoEntity>(todo));
            this.UnitOfWork.Commit();
            _logger.LogInformation("Saved {todoid} to database.", todo.Id);

            Cache.Flush(Entities.TodoEntities);
            _logger.LogInformation("Flushed cache['{cachekey}'].", Entities.TodoEntities);
        }

        public void Remove(Guid id)
        {
            _logger.LogInformation("Deleting todo item {todoid}...", id);
            _repository.Remove(id);
            this.UnitOfWork.Commit();
            _logger.LogInformation("Deleted {todoid} from database.", id);

            Cache.Flush(Entities.TodoEntities);
            _logger.LogInformation("Flush cache['{cachekey}'].", Entities.TodoEntities);
        }

        public void SetStatus(Guid id, bool isActive)
        {
            _logger.LogInformation("Updating status of todo item {todoid} to {1}...", id, isActive);
            _repository.SetStatus(id, isActive);
            this.UnitOfWork.Commit();
            _logger.LogInformation("Saved {todoid} to database.", id);

            Cache.Flush(Entities.TodoEntities);
            _logger.LogInformation("Flush cache['{cachekey}'].", Entities.TodoEntities);
        }
    }
}
