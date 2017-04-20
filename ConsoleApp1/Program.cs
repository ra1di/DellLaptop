using ConsoleApp1.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            User user = new User("rajmund_rajkowski@gmail.com", "dupadupa123");
            Order order = new Order(1, 100);

            //user1.Activate();
            //user1.PurchaseOrder(order1);
            //user1.SetAge(25);

            Race race = new Race();
            //zle 
            // user.Orders.Add(order);

          

            race.Begin();

            Console.ReadLine();



        }
    }
}

