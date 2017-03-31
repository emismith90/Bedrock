using System;

namespace Bedrock.Data.Models.Abstract
{
    public abstract class AuditableEntityBase<T> : EntityBase<T>, IAuditableEntity
    {
        public AuditableEntityBase()
        {
            CreatedOn = DateTime.Now.ToUniversalTime();
        }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
