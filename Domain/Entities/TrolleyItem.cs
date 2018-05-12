namespace Domain.Entities
{
    public class TrolleyItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }
        public decimal TotalCost => Product.Price * Quantity;

        public TrolleyItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void UpdateQuantityBy(int numberOfItems)
        {
            Quantity += numberOfItems;
        }
    }
}
