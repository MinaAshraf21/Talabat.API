using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Talabat.APIs.Controllers.Erros;
using Talabat.APIs.Extensions;
using Talabat.APIs.Middlewares;
using Talabat.Application;
using Talabat.Infrastructure;
using Talabat.Infrastructure.Persistence;

namespace Talabat.APIs
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
                   .AddNewtonsoftJson(options =>
                   {
                       options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                   })
                   .AddJsonOptions(op =>
                   {
                       op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                       op.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                   })
                   .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly)
                   .ConfigureApiBehaviorOptions(options =>
                   {
                       options.SuppressModelStateInvalidFilter = false; // will not execute any endpoint if the model state is invalid
                       options.InvalidModelStateResponseFactory = context =>
                       {
                           return new BadRequestObjectResult(new ApiValidationErrorResponse()
                           {
                               Errors = context.ModelState
                                    .Where(e => e.Value!.Errors.Count > 0)
                                    .Select(e => new ApiValidationErrorResponse.ValidationError()
                                    {
                                        Field = e.Key,
                                        Errors = e.Value!.Errors.Select(e => e.ErrorMessage)
                                    })
                           });
                       };
                   });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);
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
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseStaticFiles();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
