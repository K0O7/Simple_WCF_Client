using ClientService1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientService1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyData.info();
            Console.WriteLine("\nCLIENT - START (CarComp):");
            /*CarCompClient client1 = new CarCompClient("WSDualHttpBinding_ICarComp");*/
            CarCompCallback myCbHandler = new CarCompCallback();
            InstanceContext instanceContext = new InstanceContext(myCbHandler);
            CarCompClient client1 = new CarCompClient(instanceContext);

            bool work = true;

            while (work)
            {
                int input = -1;
                Console.WriteLine("0 - exit\n1 - addCar\n2 - removeCar\n3 - getCar\n4 - getBrand\n5 - getPrice\n6 - getProductionYear\n7 - getCars\n8 - getCarsByBrand\n9 - getCarsByYear\n");
                try
                {
                    string temp = Console.ReadLine();
                    input = Int32.Parse(temp);
                }
                catch(Exception e)
                {
                    Console.WriteLine("invalid input");
                }

                if (input == 0)
                {
                    work = false;
                }

                if (input == 1)
                {
                    Car car = new Car();
                    
                    try
                    {
                        Console.WriteLine("podaj nazwę samochodu");
                        string name = Console.ReadLine();

                        car.name = name;

                        Console.WriteLine("podaj nazwę marki samochodu");
                        string brand = Console.ReadLine();
                        
                        car.brand = brand;
                        
                        Console.WriteLine("podaj cene samochodu");
                        string p = Console.ReadLine();

                        int price = Int32.Parse(p);
                        car.price = price;

                        Console.WriteLine("podaj rok produkcji samochodu");
                        string y = Console.ReadLine();

                        int year = Int32.Parse(y);
                        car.production_year = year;
                        
                        Console.WriteLine("0 - spalinowy, 1 - elektryczny");
                        string t = Console.ReadLine();

                        int type = Int32.Parse(t);

                        if (type == 0)
                        {
                            car.is_electric = false;
                        }
                        if (type == 1)
                        {
                            car.is_electric = true;
                        }
                        else
                        {
                            throw new Exception("invalid type");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"invalid input {e.Message}");
                    }

                    Console.WriteLine($"...call of addCar");
                    client1.addCar(car);
                }

                if (input == 2) //usuwa po podanej nazwie car
                {
                    Console.WriteLine("podaj nazwę samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...call of removeCar");
                    if (client1.removeCar(name))
                    {
                        Console.WriteLine("usuwanie powiodło się");
                    }
                    else
                    {
                        Console.WriteLine("usuwanie nie powiodło się");
                    }
                }

                if (input == 3) // zwraca po podanej nazwie samochodu
                {
                    Console.WriteLine("podaj nazwę samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...call of getCar");
                    Car result = client1.getCar(name);
                    if (result == null)
                    {
                        Console.WriteLine("nie ma takiego samochodu");
                    }
                    else
                    {
                        Console.WriteLine($"samochód o nazwie {result.name}, marce {result.brand}, roku produkcji {result.production_year} i cenie {result.price}");
                    }
                }

                if (input == 4)// zwraca marke samochodu ktorego nazwe podamy
                {
                    Console.WriteLine("podaj nazwę samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...call of getBrand");
                    string result = client1.getBrand("T");

                    if (result == null)
                    {
                        Console.WriteLine("nie ma takiego samochodu");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has brand {result}");
                    }
                }

                if (input == 5)// podajemy nazwe samochodu dostajemy cene
                {
                    Console.WriteLine("podaj nazwę samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...call of getPrice");
                    int result = client1.getPrice(name);

                    if (result == -1)
                    {
                        Console.WriteLine("nie ma takiego samochodu");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has price {result}");
                    }
                }

                if (input == 6)// podajemy nazwe samochodu dostajemy rok produkcji
                {
                    Console.WriteLine("podaj nazwę samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...getProductionYear");
                    int result = client1.getProductionYear(name);

                    if(result == -1)
                    {
                        Console.WriteLine("Nie ma takigo samochodu");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has year of production {result}");
                    }
                }

                if (input == 7)
                {
                    Console.WriteLine($"...call of getCars");
                    var cars = client1.getCars();
                    Console.WriteLine("\nCars: ");
                    foreach (Car elem in cars)
                    {
                        Console.WriteLine($"samochód o nazwie {elem.name}, marce {elem.brand}, roku produkcji {elem.production_year} i cenie {elem.price}");
                    }
                }

                if (input == 8)
                {
                    Console.WriteLine("podaj nazwę marki samochodu");
                    string name = Console.ReadLine();

                    Console.WriteLine($"...call of getCarsByBrand");
                    client1.getCarsByBrand(name);
                }

                if (input == 9)
                {
                    Console.WriteLine("podaj rok produkcji");
                    string temp = Console.ReadLine();
                    try
                    {
                        int year = Int32.Parse(temp);
                        Console.WriteLine($"...call of getCarsByYear");
                        client1.getCarsByYear(year);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("invalid input");
                    }
                }

                if (work)
                {
                    Console.WriteLine("\n--> Client must wait for the results");
                    Console.WriteLine("--> press <ENTER> after receiving ALL results\n");
                    Console.ReadLine();
                }
            }

            client1.Close();
            Console.WriteLine("CLIENT - STOP");
        }
    }
}
