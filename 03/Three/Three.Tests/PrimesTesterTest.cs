using System;
using Xunit;
using Three.Core;

namespace Three.Tests
{
    public class PrimesTesterTest
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(7, true)]
        [InlineData(57, false)]
        [InlineData(3467, true)]
        public void Is_Number_A_Prime(int number, bool isPrime)
        {
            var primeTester = new PrimesTester();
            var result = primeTester.IsPrime(number);

            Assert.True(result == isPrime);

        }


    }
}
