using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Xunit;

namespace NetCoreXUnitTests.Tests
{
    public class ShoppingCartTestMock
    {
        [Theory]
        [InlineData(2, 4, 8)]
        public void TestMethodAddItems(
            int quantity,
            decimal amount,
            decimal totalExpected
        )
        {
            var mock = new Mock<IShoppingCart>();
            mock.Setup(x => x.GetItems()).Returns(new List<Items> {
                new Items { Id = 1, Quantity = 1, Amount = 1 },
                new Items { Id = 2, Quantity = 2, Amount = 2 }
            });

            var total = mock.Object.AddItem(
                id: new Random().Next(),
                quantity: quantity,
                amount: amount
            );

            var items = mock.Object.GetItems();

            Assert.True(total == totalExpected);
            Assert.True(items.Sum(s => s.Quantity) == 3);
            Assert.True(items.Sum(s => s.Amount) == 3);
            Assert.True(items.Count() == 2);
        }
    }
}
