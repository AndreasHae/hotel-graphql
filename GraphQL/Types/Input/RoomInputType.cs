using GraphQL.Types;
using HotelGraphQL.Domain;
using HotelGraphQL.GraphQL.Types.Shared;

namespace HotelGraphQL.GraphQL.Types.Input
{
    public class RoomInputType : InputObjectGraphType<Room>
    {
        public RoomInputType()
        {
            Name = "RoomInput";

            Field(x => x.Number, type: typeof(NonNullGraphType<IntGraphType>));
            Field(x => x.Type, type: typeof(NonNullGraphType<RoomTypeType>));
        }
    }
}