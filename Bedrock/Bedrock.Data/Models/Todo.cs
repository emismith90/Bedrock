using System;
using Bedrock.Data.Models.Abstract;

namespace Bedrock.Data.Models
{
    public class Todo : AuditableEntityBase<Guid>
    {
        // Empty constructor for EF
        protected Todo() { }

        public string Title { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Active,
        Done
    }
}
