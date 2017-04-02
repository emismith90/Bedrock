using Bedrock.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bedrock.Services.Sample.Interfaces
{
    public interface ITodoService
    {
        TodoDto GetById(Guid id);
        IEnumerable<TodoDto> GetAll();
        void Add(TodoDto todo);
        void Update(TodoDto todo);
        void Remove(Guid id);
        void SetStatus(Guid id, bool isActive);
    }
}
