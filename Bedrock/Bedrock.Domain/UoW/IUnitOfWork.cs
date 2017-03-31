using System;

namespace Bedrock.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
