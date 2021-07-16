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
        [InlineData(2, 4, 8, true)]
        [InlineData(2, 4, 9, false)]
        public void TestMethodAddItems(
            int quantity,
            decimal amount,
            decimal totalExpected,
            bool valid
        )
        {
            var shoppingCart = new ShoppingCart();
            var total = shoppingCart.AddItem(
                id: new Random().Next(),
                quantity: quantity,
                amount: amount
            );

            Assert.True(valid == (total == totalExpected));
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("123", true)]
        [InlineData("   asdasd", false)]
        [InlineData("asdasd   ", false)]
        [InlineData("asd   asd", false)]
        public void TestCode(string code, bool valid)
        {
            Assert.True(valid == !string.IsNullOrWhiteSpace(code));
        }
    }
}
