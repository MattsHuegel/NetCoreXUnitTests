using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreXUnitTests
{
    public interface IShoppingCart
    {
        decimal AddItem(
            int id,
            int quantity,
            decimal amount
        );

        decimal GetAmountTotal();

        IList<Items> GetItems();
    }

    public class ShoppingCart : IShoppingCart
    {
        private IList<Items> Items;

        public ShoppingCart()
        {
            Items = new List<Items>();
        }

        public decimal AddItem(
            int id,
            int quantity,
            decimal amount
        )
        {
            var item = new Items
            {
                Id = id,
                Quantity = quantity,
                Amount = amount
            };

            Items.Add(item);

            return item.Total;
        }

        public decimal GetAmountTotal()
        {
            return Items.Sum(s => s.Total);
        }

        public IList<Items> GetItems()
        {
            return Items;
        }
    }

    public class Items
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get { return Quantity * Amount; } }
    }
}
