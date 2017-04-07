using System;
using Bedrock.Domain.Data.Contexts;
using Bedrock.Domain.Abstract.Repositories;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Domain.EF.Repositories
{
    public class TodoRepository : GenericRepository<TodoEntity, Guid>, ITodoRepository
    {
        public TodoRepository(BedrockContext context) : base(context)
        {
        }

        public void SetStatus(Guid id, bool isActive)
        {
            var todoItem = this.GetById(id);
            todoItem.IsActive = isActive;

            this.Update(todoItem);
        }
    }
}
