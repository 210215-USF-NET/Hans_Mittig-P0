using System;
using StoreModels;
using Xunit;

namespace StoreTests
{
    public class UnitTest1
    {   private Inventory inv = new Inventory();
        [Theory]
        [InlineData (0, true)]
        [InlineData(-2, false)]
        public void CheckQuantity(int q, bool expected)
        {
            bool result = inv.CheckQuantity(q);
            Assert.Equal(result, expected);
        }
    }
}
