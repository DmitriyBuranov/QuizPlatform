using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using QuizPlatformAPI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class FixtureForControllers
    {
        public IServiceProvider ServiceProvider { get; set; }

        public FixtureForControllers()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            new Startup(configuration).ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider = serviceProvider;
        }
    }
}
