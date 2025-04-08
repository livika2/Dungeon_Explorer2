using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents the game map containing a collection of rooms.
    /// </summary>
    public class GameMap
    {
        // List of rooms on the map
        private List<Room> _rooms = new List<Room>();

        /// <summary>
        /// Adds a new room to the map.
        /// </summary>
        /// <param name="room">The room to add.</param>
        public void AddRoom(Room room) => _rooms.Add(room);

        /// <summary>
        /// Retrieves a room by index.
        /// </summary>
        /// <param name="index">The index of the room to retrieve.</param>
        /// <returns>The room at the specified index.</returns>
        public Room GetRoom(int index) => _rooms[index];

        /// <summary>
        /// Gets the total number of rooms in the map.
        /// </summary>
        public int RoomCount => _rooms.Count;
    }
}
