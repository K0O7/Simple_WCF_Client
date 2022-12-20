using ClientService1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService1
{
    class CarCompCallback : ICarCompCallback
    {
        public void BrandResult(int result)
        {
            Console.WriteLine($"Found {result} cars of this brand");
        }

        public void YearResult(int result)
        {
            Console.WriteLine($"Found {result} cars of this production year");
        }
    }
}
