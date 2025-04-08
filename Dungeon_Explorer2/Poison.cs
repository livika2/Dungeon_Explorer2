using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a poisonous item that damages the player.
    /// </summary>
    public class Poison : Item
    {
        private int _damage;

        /// <summary>
        /// Initializes a new poison item with a name and damage value.
        /// </summary>
        /// <param name="name">The poison's name.</param>
        /// <param name="damage">Amount of health it removes from the player.</param>
        public Poison(string name, int damage)
        {
            Name = name;
            _damage = damage;
        }

        /// <summary>
        /// Applies damage to the player and outputs a warning.
        /// </summary>
        /// <param name="player">The player using the item.</param>
        public override void Use(Player player)
        {
            player.TakeDamage(_damage);

            // Notify the player of the damage
            Console.WriteLine($"Oh no! The poisonous flower damaged you for {_damage} HP. You now have {player.Health} HP.");
        }
    }
}
