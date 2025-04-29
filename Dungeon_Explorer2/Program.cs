using System;
using Dungeon_Explorer2;


internal class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">The command line arguments, if any.</param>
    static void Main(string[] args)
    {
        var tester = new Testing();
        tester.RunAllTests();


        // Create an instance of the Game class
        Game game = new Game(); // Initialise a new Game object

        // Start the game by calling the Start method
        game.Start(); // This begins the game loop and handles user input
    }
}

