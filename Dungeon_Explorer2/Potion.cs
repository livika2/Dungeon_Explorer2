using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a potion that heals the player.
    /// </summary>
    public class Potion : Item
    {
        private int _healAmount;

        /// <summary>
        /// Initializes a new healing potion with a name and healing amount.
        /// </summary>
        /// <param name="name">The potion's name.</param>
        /// <param name="healAmount">The amount of health it restores.</param>
        public Potion(string name, int healAmount)
        {
            Name = name;
            _healAmount = healAmount;
        }

        /// <summary>
        /// Heals the player and prints the new health value.
        /// </summary>
        /// <param name="player">The player using the potion.</param>
        public override void Use(Player player)
        {
            player.Health += _healAmount;

            // Inform the player of the healing
            Console.WriteLine($"Your health increased by 30 HP. You now have {player.Health} HP.");
        }
    }
}
