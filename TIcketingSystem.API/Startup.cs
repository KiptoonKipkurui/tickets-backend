using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TicketingSystem.API.GraphQl;
using TicketingSystem.Models;

namespace TIcketingSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Sql"]));
            services.AddGraph();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter()); // we need to return the enum values needed in apis
            }); 
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<ISchema>();

            app.UseGraphiQl("/graphql");
            app.UseGraphQLAltair();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

#if DEBUG
            //Task.WaitAll(InitializeDatabaseAsync(app.ApplicationServices, CancellationToken.None));
#endif


        }

        private async Task InitializeDatabaseAsync(IServiceProvider services, CancellationToken cancellationToken)
        {

            // Create a new service scope to ensure the services are correctly disposed when this methods returns.
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var dbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();

                var user = new User
                {
                    Email = "test@email.com",
                    Kind = UserKind.Consumer,
                    Name = "Daniel Kiptoon",
                };

                await dbContext.Users.AddAsync(user);

                var @event = new Event
                {
                    Name = "Test event",
                    Amount = 1000,
                    Capacity = 10,
                    Date = DateTimeOffset.UtcNow,
                    Description = "Fun night come one come all",
                    From = DateTimeOffset.UtcNow,
                    UserId = user.Id,
                    Venue = "Mombasa",
                    To = DateTimeOffset.UtcNow,
                };

                await dbContext.Events.AddAsync(@event);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
