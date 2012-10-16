using System;

namespace MyAI
{
    class RandomGenerator : IRandom
    {
        private static readonly Random random = new Random();

        public int Get(int upperbound)
        {
            return random.Next(upperbound);
        }
    }
}