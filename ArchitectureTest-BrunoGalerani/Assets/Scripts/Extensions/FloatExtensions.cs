using UnityEngine;

namespace Extensions
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Randomly apply the negation to the number;
        /// </summary>
        /// <param name="value">The given float.</param>
        /// <returns>The given float with 50% of chance to be is negation version.</returns>
        public static void RandomlyApplyNegation(this ref float value)
        {
            value *= (Random.Range(0, 2) * 2 - 1);
        }
    }
}