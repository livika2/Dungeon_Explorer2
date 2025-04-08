using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Interface for objects that can receive damage.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Applies damage to the object.
        /// </summary>
        /// <param name="amount">The amount of damage.</param>
        void TakeDamage(int amount);
    }
}
