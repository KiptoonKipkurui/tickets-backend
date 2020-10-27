using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl.Types;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Mutations
{
    public class UserInput : InputObjectGraphType
    {
        public UserInput()
        {

            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<UserKindEnumType>>("kind");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("PhotoUrl");
        }
    }
}
