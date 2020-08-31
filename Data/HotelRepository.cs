using System.Collections.Generic;
using System.Linq;
using HotelGraphQL.Domain;
using HotelGraphQL.Domain.Commands;

namespace HotelGraphQL.Data
{
    public class HotelRepository
    {
        private readonly IList<Hotel> _hotels = new List<Hotel>();

        public HotelRepository()
        {
            _hotels.Add(new Hotel(0, "Graph Hotel", new List<Room>
            {
                new Room(101, RoomType.EconomySuite),
                new Room(102, RoomType.EconomySuite),
                new Room(201, RoomType.LuxurySuite),
                new Room(301, RoomType.PresidentSuite)
            }));
            _hotels.Add(new Hotel(1, "Graphotel", new List<Room>
            {
                new Room(101, RoomType.EconomySuite),
                new Room(102, RoomType.EconomySuite),
                new Room(103, RoomType.EconomySuite),
                new Room(104, RoomType.EconomySuite),
                new Room(201, RoomType.LuxurySuite),
                new Room(202, RoomType.LuxurySuite),
                new Room(203, RoomType.LuxurySuite),
                new Room(301, RoomType.PresidentSuite)
            }));
            _hotels.Add(new Hotel(2, "Hotel QL", new List<Room>
            {
                new Room(101, RoomType.EconomySuite),
                new Room(102, RoomType.EconomySuite),
                new Room(201, RoomType.LuxurySuite)
            }));
        }

        public Hotel AddHotel(CreateHotelCommand command)
        {
            var newHotel = new Hotel(_hotels.Count, command.Name);
            _hotels.Add(newHotel);
            return newHotel;
        }

        public Hotel UpdateHotel(Hotel newHotel)
        {
            var existingHotel = _hotels.FirstOrDefault(hotel => hotel.Id == newHotel.Id);

            if (existingHotel == null) return null;

            var index = _hotels.IndexOf(existingHotel);
            _hotels.RemoveAt(index);
            _hotels.Insert(index, newHotel);

            return newHotel;
        }

        public Hotel GetById(int id)
        {
            return _hotels.FirstOrDefault(hotel => hotel.Id == id);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotels;
        }
    }
}