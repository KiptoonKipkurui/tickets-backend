using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Types
{
    public class UserKindEnumType:EnumerationGraphType<UserKind>
    {
        public UserKindEnumType()
        {
            Name = "userKind";
            Description = "kind of user";
        }
    }
}
