using System;

namespace Bedrock.Data.Models.Abstract
{
    interface IAuditableEntity
    {
        Guid CreatedBy { get; }
        DateTime CreatedOn { get; }

        Guid ModifiedBy { get; }
        DateTime ModifiedOn { get; }
    }
}
