using GraphQL.Conversion;
using GraphQL.Introspection;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl.Mutations;
using TicketingSystem.API.GraphQl.Queries;

namespace TicketingSystem.API.GraphQl
{
    public class GraphSchema : Schema, ISchema
    {
        public GraphSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Query>();
            Mutation = provider.GetRequiredService<Mutation>();
        }
    }
}
