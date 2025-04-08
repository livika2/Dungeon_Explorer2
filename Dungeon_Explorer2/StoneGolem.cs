using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// A heavy and slow monster that delivers a crushing blow.
    /// </summary>
    public class StoneGolem : Monster
    {
        public StoneGolem() : base("Stone Golem", 100, 20) { }

        /// <summary>
        /// Overrides the base fight behavior to include special text and sound effects.
        /// </summary>
        public override void Attack(Player player)
        {
            Console.WriteLine("The Stone Golem raises its fists and smashes the ground!");
            Console.WriteLine($"You are hit by shockwaves and lose {Damage} health.");
            player.TakeDamage(Damage);
            Console.WriteLine("You received half of a key.");
            player.PickUpItem(new KeyFragment());
            Console.WriteLine("");
        }
    }
}
