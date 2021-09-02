using System;

namespace Three.Core
{
    public class PrimesTester
    {
        public PrimesTester()
        {
        }

        public bool IsPrime(int candiate)
        {
            if (candiate < 3)
            {
                return true;
            }
            if (candiate % 2 == 0) return false;

            for (int divisor = 3; divisor <= Math.Sqrt(candiate); divisor += 2)
            {
                if (candiate % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}