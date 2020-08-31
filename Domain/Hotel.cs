using System.Collections.Generic;

namespace HotelGraphQL.Domain
{
    public class Hotel
    {
        public Hotel(int id, string name) : this(id, name, new List<Room>())
        {
        }

        public Hotel(int id, string name, IReadOnlyList<Room> rooms)
        {
            Id = id;
            Name = name;
            Rooms = rooms;
        }

        public int Id { get; }
        public string Name { get; }
        public IReadOnlyList<Room> Rooms { get; }
    }
}