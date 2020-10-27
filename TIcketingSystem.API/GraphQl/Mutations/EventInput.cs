using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl.Types;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Mutations
{
    public class EventInput : InputObjectGraphType
    {
        public EventInput()
        {
            Name = "EventInput";
            Field<NonNullGraphType<FloatGraphType>>("amount");
            Field<NonNullGraphType<IntGraphType>>("capacity");
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("date");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("from");
            //Field<NonNullGraphType<ListGraphType<StringGraphType>>>("images");
            Field<NonNullGraphType<FloatGraphType>> ("latitude");
            Field<NonNullGraphType<FloatGraphType>> ("longitude");
            Field<NonNullGraphType<StringGraphType>> ("name");
            Field<NonNullGraphType<AgeRestrictionEnumType>> ("restriction");
            Field<NonNullGraphType<StringGraphType>> ("venue");
        }
    }
}
