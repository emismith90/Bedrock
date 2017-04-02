using Bedrock.Data.Contexts;
using Bedrock.Domain.UoW;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bedrock.Domain.EF.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BedrockContext _context;

        public UnitOfWork(BedrockContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
