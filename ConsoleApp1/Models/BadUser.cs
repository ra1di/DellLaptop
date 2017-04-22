using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string Adress { get; set; }

    }

    public class User
    {

        // private Person _person;

        private ISet<Order> _orders = new HashSet<Order>();

        public string Email { get; private set; }

        public string Password { get; private set; }

        public int Age { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; private set; }

        public DateTime UpdatedAt { get; set; }

        public decimal Funds { get; set; }

        public IEnumerable<Order> Orders { get { return _orders; } }


        public User(string email, string password)
        {
            SetEmail(email);
            //  SetAge(age);
            SetPassword(password);

        }

        public User(Person person)
        {
            FirstName = person.FirstName;

        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("EMail is incorrect");
            }

            if (Email == email)
            {
                return;
            }

            Email = email;
            Update();

        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect");
            }

            if (Password == password)
            {
                return;
            }

            Password = password;
            Update();

        }
        public void SetAge(int age)
        {
            if (age < 13)
            {
                throw new Exception("Age must be greater or equal than 13");
            }
            if (Age == age)
            {
                return;

            }
            Age = age;
            Update();
        }

        public void Activate()
        {
            if (IsActive)
            {
                return;
            }

            IsActive = true;
            Update();
        }

        public void Deactivate()
        {
            if (IsActive == false)
            {
                return;
            }

            IsActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds)
        {
            if (funds <= 0)
            {
                throw new Exception("Funds must be greater than zero.");
            }
            Funds += funds;
            Update();

        }

        public void PurchaseOrder(Order order)
        {
            if (!IsActive)
            {
                throw new Exception("Only active users can purchase an order");

            }
            decimal orderPrice = order.TotalPrice;

            //sprawdzamy czy nasze fundusze sa wystarczajace na zamowienie
            if (Funds - orderPrice < 0)
            {
                throw new Exception("You dont have enought funds");
            }

            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
