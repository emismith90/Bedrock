using System;

namespace Bedrock.Domain.Data.Models
{
    public class TodoEntity : AuditableEntityBase<Guid>
    {
        // Empty constructor for EF
        protected TodoEntity() { }

        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
