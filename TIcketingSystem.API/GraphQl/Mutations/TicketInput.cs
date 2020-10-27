using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Mutations
{
    public class TicketInput : InputObjectGraphType
    {
        public TicketInput()
        {
            Name = "ticketInput";
            Field<NonNullGraphType<FloatGraphType>>("amount");
            Field<NonNullGraphType<IntGraphType>>("count");
            Field<NonNullGraphType<StringGraphType>>("eventid");
            Field<NonNullGraphType<StringGraphType>>("UserId");
        }
    }
}
