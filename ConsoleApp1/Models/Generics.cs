using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Result<T>
    {
        public T Item { get; set; }
    }

    public class GenericOrderProcessor
    {

        public Result<Order> ProcessOrder(string email, int orderId)
        {
            Order order =  new Order(1, 100);
            return new Result<Order>
            {
                Item = order
            };
        }
    }


    public class Generics
    {
        public void Test()
        {
            GenericOrderProcessor orderProcessor = new GenericOrderProcessor();

           Result<Order> result =  orderProcessor.ProcessOrder("email@email.com", 1);


          

        }

    }
}
