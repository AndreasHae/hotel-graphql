using GraphQL.Types;
using HotelGraphQL.Domain.Commands;

namespace HotelGraphQL.GraphQL.Types.Input
{
    public class CreateHotelCommandType : InputObjectGraphType<CreateHotelCommand>
    {
        public CreateHotelCommandType()
        {
            Name = nameof(CreateHotelCommand);

            Field(x => x.Name);
        }
    }
}