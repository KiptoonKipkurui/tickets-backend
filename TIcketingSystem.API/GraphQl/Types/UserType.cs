using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl.Types;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("unique identifier for a user");
            Field(x => x.Email, type: typeof(StringGraphType)).Description("email for a user");
            Field(typeof(ListGraphType<EventType>), name: "Events", Description = "events belonging to this user", resolve: context => context.Source.Events);
            Field(x => x.Kind, type: typeof(UserKindEnumType)).Description("kind of user");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("name of the user");
            Field(x => x.PhotoUrl, type: typeof(StringGraphType)).Description("profile photo url of the user.");
        }
    }
}
