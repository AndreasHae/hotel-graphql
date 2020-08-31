using GraphQL.Types;
using HotelGraphQL.Domain;
using HotelGraphQL.GraphQL.Types.Shared;

namespace HotelGraphQL.GraphQL.Types.Output
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Name = nameof(Room);

            Field(x => x.Number);
            Field(x => x.Type, type: typeof(RoomTypeType));
        }
    }
}