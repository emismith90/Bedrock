using Bedrock.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Bedrock.Data.Contexts;
using Bedrock.Domain.Repositories;

namespace Bedrock.Domain.EF.Repositories
{
    public class TodoRepository : GenericRepository<Todo, Guid>, ITodoRepository
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
