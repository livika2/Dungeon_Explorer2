using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// A ghost-like monster that drains more health with a shadowy strike.
    /// </summary>
    public class ShadowWraith : Monster
    {
        public ShadowWraith() : base("Shadow Wraith", 100, 60) { }

        /// <summary>
        /// Overrides the base fight behavior to deal more damage and have a unique feel.
        /// </summary>
        public override void Attack(Player player)
        {
            Console.WriteLine("The Shadow Wraith fades in and out of visibility...");
            Console.WriteLine("You suddenly feel very weak.");
            player.TakeDamage(Damage);
            Console.WriteLine($"You lost {Damage} health.");
            Console.WriteLine("You received half of a key.");
            player.PickUpItem(new KeyFragment());
            Console.WriteLine("");
        }
    }
}
