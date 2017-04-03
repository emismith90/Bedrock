using System;

namespace Bedrock.Domain.Abstract.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
