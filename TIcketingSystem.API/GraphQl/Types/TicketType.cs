using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl
{
    public class TicketType : ObjectGraphType<Ticket>
    {
        public TicketType()
        {
            Name = "Ticket";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("unique identifier for a ticket");
            Field(x => x.Amount, type: typeof(IntGraphType)).Description("Total amount for the ticket.");
            Field(x => x.Count, type: typeof(IntGraphType)).Description("total number of tickets bought");
            Field(x => x.EventId, type: typeof(StringGraphType)).Description("id of the event this ticket belongs to");
            Field(x => x.UserId, type: typeof(StringGraphType)).Description("id of the user this ticket belongs to");
        }
    }
}
