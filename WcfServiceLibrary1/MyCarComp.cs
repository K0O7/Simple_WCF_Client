using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyCarComp : ICarComp
    {
        ICarCompCallback callback = null;
        Car car1 = new Car("Corsa", "Opel", 1000, 2000, false);

        static List<Car> cars = new List<Car> {
            new Car("Corsa", "Opel", 1000, 2000, false),
            new Car("Astra", "Opel", 3000, 2000, false),
            new Car("T", "Ford", 30000, 1908, false)
        };

        public MyCarComp()
        {
            callback = OperationContext.Current.GetCallbackChannel<ICarCompCallback>();
        }
        public bool addCar(Car n1)
        {
            Console.WriteLine("...called addCar");
            bool result = true;
            foreach (var car in cars)
            {
                if (car.Name == n1.Name)
                {
                    return false;
                }

            }
            cars.Add(n1);
            return result;
        }

        public bool removeCar(string name)
        {
            Console.WriteLine("...called removeCar");
            Car found_car = null;
            foreach (var car in cars)
            {
                if (car.Name == name)
                {
                    found_car = car;
                }

            }
            if (found_car != null)
            {
                cars.Remove(found_car);
                return true;
            }
            return false;
        }

        public Car getCar(string name)
        {
            Console.WriteLine("...called getCar");
            foreach (var car in cars)
            {
                if (car.Name == name)
                {
                    return car;
                }

            }
            return null;
        }

        public List<Car> getCars()
        {
            Console.WriteLine("...called getCars");
            return cars;
        }

        public string getBrand(string name)
        {
            Console.WriteLine("...called getBrand");
            foreach (var car in cars)
            {
                if (car.Name == name)
                {
                    return car.Brand;
                }

            }
            return null;
        }

        public int getPrice(string name)
        {
            Console.WriteLine("...called getPrice");
            foreach (var car in cars)
            {
                if (car.Name == name)
                {
                    return car.Price;
                }
            }
            return -1;
        }

        public int getProductionYear(string name)
        {
            Console.WriteLine("...called getProductionYear");
            foreach (var car in cars)
            {
                if (car.Name == name)
                {
                    return car.Production_year;
                }
            }
            return -1;
        }

        public void getCarsByBrand(string brand)
        {
            Console.WriteLine("...called getCarsByBrand");
            Thread.Sleep(5000);
            int result = 0;
            foreach (var car in cars)
            {
                if (car.Brand == brand)
                {
                    result += 1;
                }
            }
            callback.BrandResult(result);
        }

        public void getCarsByYear(int year)
        {
            Console.WriteLine("...called getCarsByYear");
            Thread.Sleep(5000);
            int result = 0;
            foreach (var car in cars)
            {
                if (car.Production_year == year)
                {
                    result += 1;
                }
            }
            callback.YearResult(result);
        }
    }
}
