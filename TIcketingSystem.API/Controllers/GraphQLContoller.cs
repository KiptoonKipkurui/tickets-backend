using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl;
using TicketingSystem.Models;
using GraphQL;
using TicketingSystem.API.GraphQl.Queries;

namespace TicketingSystem.API.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLContoller : ControllerBase
    {
        private readonly IDocumentExecuter documentExecutor;
        private readonly ISchema schema;
        public GraphQLContoller(MainDbContext dbContext, IDocumentExecuter documentExecutor, ISchema schema)
        {
            this.documentExecutor = documentExecutor ?? throw new ArgumentNullException(nameof(documentExecutor));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();


            var result = await documentExecutor.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
