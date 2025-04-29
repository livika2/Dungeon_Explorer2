using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Provides tests for verifying the core features of the game.
    /// </summary>
    internal class Testing
    {
        private string _logPath = "test_log.txt";

        /// <summary>
        /// Runs all available game tests and logs the results.
        /// </summary>
        public void RunAllTests()
        {
            if (File.Exists(_logPath)) File.Delete(_logPath);
            Log("===== Game Testing Started =====");

            TestPlayerCreation();
            TestInventory();
            TestTakeDamage();
            TestRoomNavigation();

            Log("===== Game Testing Complete =====");
        }

        private void TestPlayerCreation()
        {
            Player p = new Player("Tester", 100);
            Debug.Assert(p.Name == "Tester", "Player name mismatch.");
            Debug.Assert(p.Health == 100, "Player health mismatch.");
            Log("TestPlayerCreation: Passed");
        }

        private void TestInventory()
        {
            Player p = new Player("Tester", 100);
            Weapon testSword = new Weapon("Test Sword");
            p.PickUpItem(testSword);
            bool hasSword = p.GetItemsOfType<Weapon>().Any(w => w.Name == "Test Sword");

            Debug.Assert(hasSword, "Sword not found in inventory after pickup.");
            Log("TestInventory: Passed");
        }

        private void TestTakeDamage()
        {
            Player p = new Player("Tester", 100);
            p.TakeDamage(40);
            Debug.Assert(p.Health == 60, "Health should be 60 after taking 40 damage.");
            Log("TestTakeDamage: Passed");
        }

        private void TestRoomNavigation()
        {
            GameMap map = new GameMap();
            map.AddRoom(new Room("Room 1"));
            map.AddRoom(new Room("Room 2"));

            Debug.Assert(map.RoomCount == 2, "Expected 2 rooms in the map.");
            Debug.Assert(map.GetRoom(1).Description == "Room 2", "Room 2 not found at expected index.");
            Log("TestRoomNavigation: Passed");
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
            File.AppendAllText(_logPath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
