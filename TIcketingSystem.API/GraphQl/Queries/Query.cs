using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Queries
{
    public class Query : ObjectGraphType
    {
        private readonly MainDbContext dbContext;
        public Query(MainDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Field<EventType>("Event",
                 arguments: new QueryArguments(
                 new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Event." }),
                       resolve: context =>
                       {
                           var id = context.GetArgument<string>("id");
                           var @event = dbContext.Events
                                 .Include(a => a.Tickets)
                                 .FirstOrDefault(i => i.Id == id);
                           return @event;
                       });

            Field<ListGraphType<EventType>>(
                "Events",
                resolve: context =>
                {
                    var events = dbContext.Events.Include(a => a.Tickets).ToList();
                    return events;
                });

            Field<UserType>("User",
               arguments: new QueryArguments(
               new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the User." }),
                     resolve: context =>
                     {
                         var id = context.GetArgument<string>("id");
                         var user = dbContext.Users
                               .Include(a => a.Tickets)
                               .Include(a => a.Events)
                               .FirstOrDefault(i => i.Id == id);
                         return user;
                     });

            Field<ListGraphType<UserType>>(
                "Users",
                resolve: context =>
                {
                    var users = dbContext.Users.Include(a => a.Tickets)
                                                .Include(a => a.Events)
                                                .ToList();
                    return users;
                });

            Field<TicketType>("Ticket", arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "id of the ticket" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   var ticket = dbContext.Tickets
                                       .FirstOrDefault(x => x.Id == id);

                   return ticket;
               });

            Field<ListGraphType<TicketType>>("Tickets",
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   var tickets = dbContext.Tickets
                                       .ToList();

                   return tickets;
               });
        }
    }
}
