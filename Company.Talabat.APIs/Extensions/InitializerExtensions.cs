using Company.Talabat.Domain.Contracts;

namespace Company.Talabat.APIs.Extensions
{
    public static class InitializerExtensions
    {
        public static async Task<WebApplication> InitializeStoreContext(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var serviceProvider = scope.ServiceProvider;
            var storeContextInitializer = serviceProvider.GetRequiredService<IStoreContextInitializer>(); // ask the clr to create an instance of StoreContext and inject it here explicitly

            //var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            // create logger factory to create logger instances [abstract factory pattern]
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                await storeContextInitializer.InitializeAsync();
                await storeContextInitializer.SeedAsync();
            }
            catch (Exception ex)
            {
                //Log exception

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }

            return app;
        }
    }
}
