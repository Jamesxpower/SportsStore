using System;
using System.Collections.Generic;
using System.Linq;


namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CarLine> lineCollection = new List<CarLine>();

       public void AddItem(Product product, int quantity)
        {
            CarLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CarLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine( Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CarLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CarLine {
        public Product Product { get; set; }
        public int Quantity { get; set; }
}

}
