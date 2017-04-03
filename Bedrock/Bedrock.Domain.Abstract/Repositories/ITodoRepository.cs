using System;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Domain.Abstract.Repositories
{
    public interface ITodoRepository : IGenericRepository<TodoEntity, Guid> 
    {
        void SetStatus(Guid id, bool isActive);
    }
}
