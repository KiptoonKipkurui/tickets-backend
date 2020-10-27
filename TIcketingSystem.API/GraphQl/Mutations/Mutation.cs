using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.Helpers;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Mutations
{
    public class Mutation : ObjectGraphType<object>
    {
        public Mutation(MainDbContext dbContext)
        {
            Name = "Mutation";
            FieldAsync<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInput>> { Name = "userInput" }
                ),
                resolve: async context =>
                 {
                     var input = context.GetArgument<User>("userInput");

                     await dbContext.Users.AddAsync(input);
                     await dbContext.SaveChangesAsync();
                     //PropertyCopier<UserInput, User>.Copy(input, user);
                     return input;
                 });

            FieldAsync<EventType>(
              "createEvent",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<EventInput>> { Name = "eventInput" }
              ),
              resolve: async context =>
              {
                  var input = context.GetArgument<Event>("eventInput");

                  await dbContext.Events.AddAsync(input);
                  await dbContext.SaveChangesAsync();
                  return input;
              });

            FieldAsync<TicketType>(
             "createTicket",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<TicketInput>> { Name = "ticketInput" }
             ),
             resolve: async context =>
             {
                 var input = context.GetArgument<Ticket>("ticketInput");

                 await dbContext.Tickets.AddAsync(input);
                 await dbContext.SaveChangesAsync();
                 return input;
             });
        }
    }
}
