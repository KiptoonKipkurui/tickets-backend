using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GraphQL.Builders;
using GraphQL.Types;
using TicketingSystem.API.GraphQl.Types;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType()
        {
            Name = "Event";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Amount per ticket");
            Field(x => x.Amount).Description("Amount per ticket");
            Field(x => x.Capacity).Description("Number of people for the event.");
            Field(x => x.Date).Description("Date of the event");
            Field(x => x.Description).Description("Description of the event.");
            Field(x => x.From, type: typeof(DateTimeGraphType)).Description("Event start time");
            Field(x => x.To).Description("Event end time.");
            Field(x => x.UserId).Description("id of the user who owns this event.");
            Field(x => x.Venue).Description("Venue for this event.");
            Field(x => x.Images).Description("links to images for this event");
            Field(x => x.Name).Description("name of this event");
            Field(x => x.Restriction, type: typeof(AgeRestrictionEnumType)).Description("name of this event");
            Field(x => x.Latitude).Description("latitude location for this event");
            Field(x => x.Longitude).Description("longitude location for this event");
            Field(typeof(ListGraphType<TicketType>), name: "Tickets", Description = "Tickets for this event", resolve: context => context.Source.Tickets);
        }
    }
}
