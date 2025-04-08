using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a weapon item (future damage dealing functionality possible).
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// Initializes a weapon with a name.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        public Weapon(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Currently no use effect, may be used to deal damage later.
        /// </summary>
        /// <param name="player">The player using the weapon.</param>
        public override void Use(Player player) { /* could affect damage later */ }
    }
}
