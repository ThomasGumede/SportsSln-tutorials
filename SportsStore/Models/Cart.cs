using System.Collections.Generic;
using System.Linq;
namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        /// <summary>
        /// Add item to Cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Lines
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// remove a previously added item from the cart
        /// </summary>
        /// <param name="product"></param>
        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductID == product.ProductID);

        /// <summary>
        /// calculate the total cost of the items in the cart
        /// </summary>
        /// <returns>Total price</returns>
        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        /// <summary>
        /// reset the cart by removing all the items
        /// </summary>
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}