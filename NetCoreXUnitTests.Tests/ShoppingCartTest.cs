using System;
using Xunit;

namespace NetCoreXUnitTests.Tests
{
    public class ShoppingCartTest
    {
        [Fact]
        public void TestMethodAddItem()
        {
            var shoppingCart = new ShoppingCart();
            var total = shoppingCart.AddItem(
                id: new Random().Next(),
                quantity: 1,
                amount: 5.99m
            );

            Assert.True(total == 5.99m);
        }

        [Theory]
        [InlineData(2, 4, 8)]
        [InlineData(2, 4, 9)]
        public void TestMethodAddItems(
            int quantity,
            decimal amount,
            decimal totalExpected
        )
        {
            var shoppingCart = new ShoppingCart();
            var total = shoppingCart.AddItem(
                id: new Random().Next(),
                quantity: quantity,
                amount: amount
            );

            Assert.True(total == totalExpected);
        }
    }
}
