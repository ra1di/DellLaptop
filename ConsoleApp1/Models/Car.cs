using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{


    public abstract class Car
    {
        public double Speed { get; protected set; } = 100; //domyslna wartosc to 100

        public double Acceleration { get; protected set; } = 10;
        public void Start()
        {
            Console.WriteLine("Turning on engine");
            Console.WriteLine($"Running at: {Speed} km/h"); //interpolacja znaków
        }


        public void Stop()
        {
            Console.WriteLine("Stopping the car");

        }
        //musi byc virtualna, gdyz tylko wtedy mozemy ją przesłonić w klasie dziedziczącej
        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating....");
            Speed += Acceleration;
            Console.WriteLine($"Runnging at: {Speed} km/h");

        }

        public abstract void Boost(); //brak definicji metody, metoda abstrakcyjna
        //implementacja pozostaje w klasie dziedziczącej


    }

    public class Truck : Car //dziedziczy po
    {
        //method ovveride poniewaz metoda z klasy bazowej jest virtualna
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck..");
            base.Accelerate(); //wywolanie metody z klasy bazowej base.xxx


        }

        public override void Boost() //metoda abstrakcyjna z klasy bazowej
        {
            Console.WriteLine("Boosting a truck");
            Speed += 50;
            Console.WriteLine($"Runnging truck at: {Speed} km/h");
        }
    }

    public class SportCar : Car
    {
        //method ovveride poniewaz metoda jest virtualna
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a sport car....");
            base.Accelerate();

        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a sports car");
            Speed += 100;
            Console.WriteLine($"Runnging sport car at: {Speed} km/h");
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Sportcar");
        }
    }

    public class Race
    {

        public void Begin()
        {


            //inicjalizacjka obiektow
            Car sportCar = new SportCar();
            // lub SportCar sportCar = new SportCar();
            Car truck = new Truck();
            // lub Truck truck = new Truck();
            
            List<Car> cars = new List<Car>
            {
                sportCar, truck

            };


            foreach (Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();

                Console.WriteLine();
            }


        }

        public void Casting() //rzutowanie
        {
            Car sportCar = new SportCar();
            // lub SportCar sportCar = new SportCar();
            Car truck = new Truck();
            // lub Truck truck = new Truck();

            SportCar castedSportCar = sportCar as SportCar;

            if (castedSportCar != null) //wiemy że rzutowanie odbyło się poprawnie
            {
                castedSportCar.DisplayInfo();
            }



        }
    }
}
