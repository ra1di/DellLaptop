using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Order
    {
        public int Id { get; private set; }

        public decimal  Price {

            get;

            private set;

        }

        public decimal TaxRate { get; } = 0.23M;

        //wlasnosc wyrazeniowa wprowadzona w c#6.0
        public decimal TotalPrice => (1 + TaxRate) * Price;
        //{
        //    get { return (1 + TaxRate) * Price; }
        //}
        public bool IsPurchased { get; private set; }
     

        public Order(int id, decimal price)
        {
            
            if (price <= 0)
            {
                throw new Exception("Price must be greater than zero.)");
            }

            this.Id = id;
            this.Price = Price;
        }

        public void Purchase()
        {
            if (IsPurchased)
            {
                throw new Exception("Order was already launched");

            }

            IsPurchased = true;
        }
    }
}
