using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.API.GraphQl.Types
{
    public class AgeRestrictionEnumType : EnumerationGraphType<AgeRestriction>
    {
        public AgeRestrictionEnumType()
        {
            Name = "AgeRestriction";
            Description = "Age restriction for this event.";
        }
    }
}
