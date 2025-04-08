using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Interface for items that can be collected and used by a player.
    /// </summary>
    public interface ICollectible
    {
        /// <summary>
        /// Defines how the item interacts with a player when used.
        /// </summary>
        /// <param name="player">The player using the item.</param>
        void Use(Player player);
    }
}
