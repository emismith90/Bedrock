using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Bedrock.Infrastructure.IoC
{
    public interface IApplicationContainerManager : IDisposable
    {
        IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors);
    }
}
