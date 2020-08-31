using GraphQL.Types;
using HotelGraphQL.Domain.Commands;
using HotelGraphQL.GraphQL.Types.Shared;

namespace HotelGraphQL.GraphQL.Types.Input
{
    public class AddRoomCommandType : InputObjectGraphType<AddRoomCommand>
    {
        public AddRoomCommandType()
        {
            Name = "AddRoomCommand";

            Field(x => x.HotelId, type: typeof(IdGraphType));
            Field(x => x.Room, type: typeof(RoomInputType));
        }
    }
}