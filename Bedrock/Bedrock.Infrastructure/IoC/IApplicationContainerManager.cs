using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Infrastructure.IoC
{
    public interface IApplicationContainerManager : IDisposable
    {
        IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors);
    }
}
