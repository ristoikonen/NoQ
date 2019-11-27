using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorApp2
{
    static class ServiceProviderExtensions
    {
        public static T ResolveWith<T>(this IServiceProvider provider, params object[] parameters) where T : class =>
            ActivatorUtilities.CreateInstance<T>(provider, parameters);
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var singleservber = GetDemoService();
            services.AddSingleton<DemoService>(singleservber);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            
            
        }

        public DemoService GetDemoService() 
        {

            //var singleserve  = new ServiceDescriptor

            var services = new ServiceCollection();
            services.AddTransient<HelloWorldService>();
            services.AddTransient(p => p.ResolveWith<DemoService>("Tseng", "Stackoverflow"));

            var provider = services.BuildServiceProvider();

            var demoService = provider.GetRequiredService<DemoService>();
            return demoService;
            //Console.WriteLine($"Output: {demoService.HelloWorld()}");
            //Console.ReadKey();
        }

    }

    public class DemoService
    {
        private readonly HelloWorldService helloWorldService;
        private readonly string firstname;
        private readonly string lastname;

        public DemoService(HelloWorldService helloWorldService, string firstname, string lastname)
        {
            this.helloWorldService = helloWorldService ?? throw new ArgumentNullException(nameof(helloWorldService));
            this.firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            this.lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        }
    }
    
    public class HelloWorldService
    {
        public string Hello(string name) => $"Hello {name}";
        public string Hello(string firstname, string lastname) => $"Hello {firstname} {lastname}";
    }


}

