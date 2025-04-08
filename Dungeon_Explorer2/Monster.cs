using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a monster in the dungeon with health and damage properties.
    /// </summary>
    public abstract class Monster : Creature
    {
        /// <summary>
        /// Gets the damage that the monster inflicts on the player.
        /// </summary>
        public int Damage { get; private set; }

        public Monster(string name, int health, int damage) : base(name, health)
        {
            // Assigning values to the monster's properties
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// Abstract method for attacking the player. Must be implemented by subclasses.
        /// </summary>
        /// <param name="player">The player being attacked.</param>
        public abstract void Attack(Player player);

    }
}
