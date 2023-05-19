using System;

namespace Enemies
{
    /// <summary>
    /// Second namespace in C# named Enemies which includes
    /// a class of Zombie and its definition
    /// </summary>
    public class Zombie
    {
        /// <summary>
        /// First class Zombie with int health 
        /// </summary>
        private int health;
            /// <summary>
            /// Constructor that sets health to 0, changed to private
            /// </summary>

        public Zombie()
        {
            health = 0;
        }
            /// <summary>
            /// Health must be greater than 0 or dead
            /// @value - a new variable for health...i think, not really sure 
            /// </summary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }
            health = value;
        }

        /// <summary>
        /// Returns the current value of the Zombies health
        /// </summary>
        /// <returns>health</returns>

        public int GetHealth()
        {
            return health;
        }

    }
}