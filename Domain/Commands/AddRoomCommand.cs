namespace HotelGraphQL.Domain.Commands
{
    public class AddRoomCommand
    {
        public int HotelId { get; set; }
        public Room Room { get; set; }
    }
}