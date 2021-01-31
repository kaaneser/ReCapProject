using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            CarManager carManager = new CarManager(new InMemoryCarDal());

            while (loop)
            {
                System.Console.WriteLine("1. List the Cars \t 2. List by Brand Id \t 3. Add a Car \t 4. Delete a Car \t 5. Update a Car \t 6. Exit");
                System.Console.WriteLine("\nChoice: ");
                int choice = Convert.ToInt32(System.Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        foreach (var car in carManager.GetAll())
                        {
                            System.Console.WriteLine("---- CAR ----");
                            System.Console.WriteLine("Car ID: " + car.Id);
                            System.Console.WriteLine("Brand ID: " + car.BrandId);
                            System.Console.WriteLine("Year: " + car.ModelYear);
                            System.Console.WriteLine("Daily Price: " + car.DailyPrice);
                            System.Console.WriteLine("Description: " + car.Description);
                            System.Console.WriteLine("------------\n");
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("Insert the brand ID");
                        int Id = Convert.ToInt32(System.Console.ReadLine());
                        foreach (var car in carManager.GetById(Id))
                        {
                            System.Console.WriteLine("---- CAR ----");
                            System.Console.WriteLine("Car ID: " + car.Id);
                            System.Console.WriteLine("Brand ID: " + car.BrandId);
                            System.Console.WriteLine("Year: " + car.ModelYear);
                            System.Console.WriteLine("Daily Price: " + car.DailyPrice);
                            System.Console.WriteLine("Description: " + car.Description);
                            System.Console.WriteLine("------------\n");
                        }
                        break;
                    case 3:
                        System.Console.WriteLine("Insert the car ID: ");
                        int id = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the brand ID: ");
                        int brandId = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the year: ");
                        int year = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the daily price: ");
                        decimal price = Convert.ToDecimal(System.Console.ReadLine());
                        System.Console.WriteLine("Insert a description for car: ");
                        string desc = System.Console.ReadLine();
                        
                        Car addedCar = new Car {Id = id, BrandId = brandId, ModelYear = year, DailyPrice = price, Description = desc};
                        carManager.Add(addedCar);
                        System.Console.WriteLine("Car added successfully.\n");
                        break;
                    case 4:
                        System.Console.WriteLine("Insert the car ID for deletion process: ");
                        id = Convert.ToInt32(System.Console.ReadLine());
                        Car deletedCar = new Car();
                        foreach (var car in carManager.GetAll())
                        {
                            if (car.Id == id)
                            {
                                deletedCar = car;
                            }
                        }
                        carManager.Delete(deletedCar);
                        System.Console.WriteLine("Car deleted successfully.");
                        break;
                    case 5:
                        System.Console.WriteLine("Insert the existing car ID: ");
                        id = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the brand ID: ");
                        brandId = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the year: ");
                        year = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.WriteLine("Insert the daily price: ");
                        price = Convert.ToDecimal(System.Console.ReadLine());
                        System.Console.WriteLine("Insert a description for car: ");
                        desc = System.Console.ReadLine();
                        
                        Car updatedCar = new Car { Id = id, BrandId = brandId, ModelYear = year, DailyPrice = price, Description = desc };
                        carManager.Update(updatedCar);
                        System.Console.WriteLine("Car updated successfully.");
                        break;
                    case 6:
                        loop = false;
                        break;
                    default:
                        System.Console.WriteLine("You inserted wrong choice number.");
                        break;
                }
            }
        }
    }
}
