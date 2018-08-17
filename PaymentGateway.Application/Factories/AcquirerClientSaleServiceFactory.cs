using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.AcquirerClient.Stone;
using PaymentGateway.Domain.Interfaces.AntiCorruption;
using PaymentGateway.Domain.Entities;
using System.Reflection;
using System.Linq;

namespace PaymentGateway.Application.Factories
{
    public static class AcquirerClientSaleServiceFactory
    {

        public static IAcquirerClientSaleService CreateInstance(string assembly)
        {
            var Force = typeof(PaymentGateway.AcquirerClient.Null.AcquirerClientSaleService).Assembly;
            var Type = Assembly
                   .GetExecutingAssembly()
                   .GetReferencedAssemblies()
                   .Select(x => Assembly.Load(x))
                   .SelectMany(x => x.GetTypes()).Where(s => s.FullName.Contains(assembly)).First();
            IAcquirerClientSaleService Instance = (IAcquirerClientSaleService)Activator.CreateInstance(Type);
            return Instance;
        }

    }
}
