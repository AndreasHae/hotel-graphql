using GraphQL.Types;
using HotelGraphQL.Data;

namespace HotelGraphQL.GraphQL.Types.Output
{
    public class Query : ObjectGraphType
    {
        public Query(HotelRepository hotelRepository)
        {
            Field<HotelType>("Hotel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                    {Name = "id", Description = "The ID of the Hotel"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return hotelRepository.GetById(id);
                });

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<HotelType>>>>("Hotels",
                resolve: context => hotelRepository.GetAllHotels());
        }
    }
}