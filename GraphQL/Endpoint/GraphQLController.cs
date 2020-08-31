using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using HotelGraphQL.Data;
using HotelGraphQL.GraphQL.Types.Input;
using HotelGraphQL.GraphQL.Types.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelGraphQL.GraphQL.Endpoint
{
    [Route("/graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly HotelRepository _hotelRepository;
        private readonly ILogger<GraphQLController> _logger;

        public GraphQLController(ILogger<GraphQLController> logger, HotelRepository hotelRepository)
        {
            _logger = logger;
            _hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new Query(_hotelRepository),
                Mutation = new Mutation(_hotelRepository)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                foreach (var error in result.Errors) _logger.LogInformation(error.ToString());
                return BadRequest();
            }

            return Ok(result);
        }
    }
}