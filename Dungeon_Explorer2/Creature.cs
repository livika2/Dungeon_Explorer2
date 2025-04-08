using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Abstract base class for all creatures that can take damage and have a name and health.
    /// </summary>
    public abstract class Creature : IDamageable
    {
        /// <summary>
        /// An instance of the <see cref="Testing"/> class used for validating player's health.
        /// </summary>
        private Testing _tester = new Testing();

        /// <summary>
        /// The creature's name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The creature's health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Reduces the creature's health by a specified damage amount.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>

        // Constructor to initialize common properties
        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;

            //_tester.TestHealth(Health); // Validate health state
        }
    }
}
