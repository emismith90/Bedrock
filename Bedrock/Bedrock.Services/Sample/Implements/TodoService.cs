using Bedrock.Services.Sample.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Bedrock.Dto;
using System.Linq.Expressions;
using Bedrock.Domain.Repositories;
using AutoMapper;
using Bedrock.Services.Abstract;
using Bedrock.Data.Models;
using Bedrock.Domain.UoW;

namespace Bedrock.Services.Sample.Implements
{
    public class TodoService : DataServiceBase, ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           ITodoRepository repository) 
            : base(mapper, unitOfWork)
        {
            this._repository = repository;
        }

        public TodoDto GetById(Guid id)
        {
            return Mapper.Map<TodoDto>(this._repository.GetById(id));
        }

        public IEnumerable<TodoDto> GetAll()
        {
            return Mapper.Map<IEnumerable<TodoDto>>(_repository.GetAll());
        }

        public void Add(TodoDto todo)
        {
            _repository.Add(Mapper.Map<Todo>(todo));
            this.UnitOfWork.Commit();
        }

        public void Update(TodoDto todo)
        {
            _repository.Update(Mapper.Map<Todo>(todo));
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
