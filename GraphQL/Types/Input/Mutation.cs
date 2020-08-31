using System.Collections.Generic;
using GraphQL.Types;
using HotelGraphQL.Data;
using HotelGraphQL.Domain;
using HotelGraphQL.Domain.Commands;
using HotelGraphQL.GraphQL.Types.Output;

namespace HotelGraphQL.GraphQL.Types.Input
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(HotelRepository hotelRepository)
        {
            Field<HotelType>("createHotel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateHotelCommandType>>
                {
                    Name = "command"
                }),
                resolve: context =>
                {
                    var command = context.GetArgument<CreateHotelCommand>("command");
                    return hotelRepository.AddHotel(command);
                });

            Field<HotelType>("addRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AddRoomCommandType>> {Name = "command"}),
                resolve: context =>
                {
                    var command = context.GetArgument<AddRoomCommand>("command");

                    var hotel = hotelRepository.GetById(command.HotelId);
                    var newHotel = new Hotel(hotel.Id, hotel.Name, new List<Room>(hotel.Rooms) {command.Room});
                    return hotelRepository.UpdateHotel(newHotel);
                });
        }
    }
}