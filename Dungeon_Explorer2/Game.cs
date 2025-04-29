using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Manages the main game logic, including player interactions and room navigation.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Represents the player in the game.
        /// </summary>
        private Player _player;

        /// <summary>
        /// The game map that makes up the dungeon.
        /// </summary>
        private List<Room> _rooms = new List<Room>();




        private GameMap _map = new GameMap();

        /// <summary>
        /// Tracks the index of the current room the player is in.
        /// </summary>
        private int _currentRoom = 0;

        /// <summary>
        /// Starts the game loop, handling player choices and interactions.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Initialise();

            bool playing = true;

            // Main game loop
            while (playing)
            {
                // Get the current room based on the room index
                var room = _map.GetRoom(_currentRoom);

                // Checks if there is still a monster in the room and prompts the player to fight
                if (room.IsMonsterVisible())
                {
                    Console.WriteLine($"You have encountered a {room.Monster.Name}.");
                    Console.WriteLine("Are you ready for the fight? (yes/no)");
                    while (true)
                    {
                        // Read the player's choice to fight or not
                        string choice = Console.ReadLine().ToLower();

                        if (choice == "yes")
                        {
                            // Proceed with the fight
                            room.Monster.Attack(_player);
                            room.RemoveMonster();
                            break;
                        }
                        else if (choice == "no")
                        {
                            // Player decides not to fight
                            room.HideMonster();
                            Console.WriteLine("You have decided not to fight.");
                            Console.WriteLine("");
                            break;
                        }
                        else
                        {
                            // In case of invalid input
                            Console.WriteLine("Unknown command, please try again. (yes/no)");
                        }
                    }
                }
                if (CheckHealth(_player) == 0)
                    break;
                // Ask the player for their next move
                Console.WriteLine("Please choose your next move. (stats, description, pickup, nextRoom, previousRoom, quit)");
                string nextMove = Console.ReadLine().ToLower();

                switch (nextMove)
                {
                    case "pickup":

                        if (room.Item != null)
                        {
                            // Pick up an item if available
                            Console.WriteLine($"You picked up: {room.GetItemName()}.");
                            _player.PickUpItem(room.Item);
                            Console.WriteLine("");
                            room.RemoveItem();
                        }
                        else Console.WriteLine("There are no items to pick up in this room.");
                        break;

                    case "stats":

                        // Show the player's stats
                        Console.WriteLine($"The player {_player.Name} has {_player.Health} HP.");
                        Console.WriteLine($"Inventory: {_player.GetInventoryContents()}");
                        Console.WriteLine("");
                        break;

                    case "description":

                        // Show the room's description and items
                        Console.WriteLine($"You are in {room.Description}");
                        Console.WriteLine($"This room has {room.GetItemName()} in it.");
                        Console.WriteLine("");
                        break;

                    case "nextroom":

                        // Move to the next room if it is not the last locked room
                        if (_currentRoom < _map.RoomCount - 2)
                        {
                            _currentRoom++;
                            room.ResetMonster();
                            Console.WriteLine("You entered the next room.");
                            Console.WriteLine("");
                        }
                        else if(_currentRoom == _map.RoomCount - 2)
                        {
                            // Check if the player has a key to unlock the final room
                            if (_player.GetItemsOfType<Key>().Any())
                            {
                                _currentRoom++;  // Unlock and move into the final room
                                Console.WriteLine("Your key gave you access to this room!");
                                Console.WriteLine("");
                            }
                            else
                            {
                                // Player doesn't have a key, cannot enter
                                Console.WriteLine("You are missing a key. You can not enter this room.");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have arrived at the dungeon's exit door.");
                            Console.WriteLine("You cannot go further.");
                            Console.WriteLine("");
                        }
                        break;

                    case "previousroom":

                        // Move the previous room if possible
                        if (_currentRoom > 0)
                        {
                            _currentRoom--;
                            room.ResetMonster();
                            Console.WriteLine("You entered the previous room.");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("You have arrived at the dungeon's entry door.");
                            Console.WriteLine("You cannot go further.");
                            Console.WriteLine("");
                        }
                        break;

                    case "quit":

                        // Quit the game
                        playing = false;
                        Console.WriteLine("You have decided to quit.");
                        break;

                    default:

                        // Handle invalid commands
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.WriteLine("");
                        break;
                }
                if (CheckHealth(_player) == 0)
                    break;
            }
        }

        /// <summary>
        /// Prompts the player to enter a valid name containing letters only.
        /// </summary>
        /// <returns>A valid player name.</returns>
        private string GetPlayerName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please input your name: ");
                    string playerName = Console.ReadLine();

                    // Check if the name is empty or null
                    if (string.IsNullOrEmpty(playerName))
                    {
                        throw new FormatException();
                    }

                    // Check if the name contains only letters
                    if (!(playerName.All(char.IsLetter)))
                    {
                        throw new FormatException();
                    }
                    return playerName;
                }
                catch (FormatException)
                {
                    // Inform the player that the name must contain letters only
                    Console.WriteLine("The name should only contain letters. Please try again.");
                }

                catch (Exception)
                {
                    // Catch any unexpected errors
                    Console.WriteLine("An unexpected error occured. Please try again. ");
                }
            }
        }

        /// <summary>
        /// Initialises the game world, including rooms and monsters.
        /// </summary>
        private void Initialise()
        {
            string playername = GetPlayerName();

            // Creates a player with a given name and maximum health
            _player = new Player(playername, 100);

            // Add rooms to the dungeon with descriptions and items or monsters
            _map.AddRoom(new Room("a very dark and cold room.", new Weapon("leather armour")));
            _map.AddRoom(new Room("a huge room filled with statues.", new Weapon("torch"), new StoneGolem()));
            _map.AddRoom(new Room("a well lit but eerie room.", new Weapon("iron sword")));
            _map.AddRoom(new Room("a small room with a mountain painting.", null, new ShadowWraith()));
            _map.AddRoom(new Room("a hidden cellar with barrels of strange liquid", new Potion("health potion", 30)));
            _map.AddRoom(new Room("a pitch-black room, only your footsteps can be heard.", new Weapon("rock")));
            _map.AddRoom(new Room("a ruined library with scattered, dust-covered books.", new Poison("poisonous flower", 20)));

        }

        public int CheckHealth(Player _player) 
        {
            if (_player.Health <= 0)
            {
                Console.WriteLine("You have received too much damage. Game over!");
                Console.WriteLine("Press any key to exit..");
                Console.ReadKey();
                return 0;
            }
            else return 1;
        }
    }
}
