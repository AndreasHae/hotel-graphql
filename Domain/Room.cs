namespace HotelGraphQL.Domain
{
    public class Room
    {
        public Room() : this(-1, RoomType.EconomySuite) {}

        public Room(int number, RoomType type)
        {
            Number = number;
            Type = type;
        }

        public int Number { get; set; }
        public RoomType Type { get; set; }
    }
}