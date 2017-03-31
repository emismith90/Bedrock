using Bedrock.Data.Models;
using System;

namespace Bedrock.Domain.Repositories
{
    public interface ITodoRepository : IGenericRepository<Todo, Guid> 
    {
        void SetStatus(Guid id, Status status);
    }
}
