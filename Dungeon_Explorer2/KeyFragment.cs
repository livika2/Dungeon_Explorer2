using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Represents a key fragment used in the game.
    /// </summary>
    public class KeyFragment : Item
    {
        /// <summary>
        /// Constructs a KeyFragment with a default name.
        /// </summary>
        public KeyFragment() { Name = "half of a key"; }

        /// <summary>
        /// Defines the behavior when the key fragment is used by a player.
        /// </summary>
        /// <param name="player">The player using the item.</param>
        public override void Use(Player player) { }
    }
}
