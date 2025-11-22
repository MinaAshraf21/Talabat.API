using Company.Talabat.APIs.Extensions;
using Company.Talabat.Application;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Infrastructure.Persistence;
using Company.Talabat.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Talabat.APIs
{
    public class Program
    {
        ////CLR will create an instance of StoreContext and inject it here at first usage for this class (Program)
        //[FromServices]
        //public static StoreContext StoreContext { get; set; } = null!;
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services

            // Add services to the container.

            builder.Services
                   .AddControllers()
                   .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            #endregion

            var app = builder.Build();

            #region Database Initialization


            //after building the app we can get the StoreContext instance from the DI container
            // this means we will inject the StoreContext here explicitly
            // we will use a scope to create a request and dispose it after usage
            // note : any request has a scope created for it implicitly by the framework

            await app.InitializeStoreContext();


            #endregion         

            #region Configure Kestral Middlewares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
