using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Application.Tests
{
    [SetUpFixture]
    public partial class Testing
    {
        private static IServiceScopeFactory _scopeFactory = null!;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var factory = new CustomWebApplicationFactory();
            _scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
        }
        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }
    }

}
