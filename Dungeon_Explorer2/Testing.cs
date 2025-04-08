﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer2
{
    /// <summary>
    /// Provides utility methods for testing player health.
    /// </summary>
    internal class Testing
    {
        /// <summary>
        /// Validates the player's current health.
        /// </summary>
        /// <param name="currentHealth">The current health value to check.</param>
        public void TestHealth(int currentHealth)
        {
            //Ensure health does not go below zero
            Debug.Assert(currentHealth > 0, "Health has dropped below zero. There is an issue in damage calculations");
        }

    }
}
