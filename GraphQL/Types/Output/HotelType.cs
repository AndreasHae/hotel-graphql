using GraphQL.Types;
using HotelGraphQL.Domain;
using HotelGraphQL.GraphQL.Types.Shared;

namespace HotelGraphQL.GraphQL.Types.Output
{
    public class HotelType : ObjectGraphType<Hotel>
    {
        public HotelType()
        {
            Name = nameof(Hotel);

            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Unique ID of the Hotel");
            Field(x => x.Name).Description("Name of the Hotel");
            Field(x => x.Rooms, type: typeof(NonNullGraphType<ListGraphType<NonNullGraphType<RoomType>>>));
        }
    }
}