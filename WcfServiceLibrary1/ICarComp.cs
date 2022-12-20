using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICarCompCallback))]
    public interface ICarComp
    {
        [OperationContract]
        bool addCar(Car n1);

        [OperationContract]
        bool removeCar(string name);

        [OperationContract]
        Car getCar(string name);

        [OperationContract]
        string getBrand(string name);

        [OperationContract]
        int getPrice(string name);

        [OperationContract]
        int getProductionYear(string name);

        [OperationContract]
        List<Car> getCars();

        [OperationContract(IsOneWay = true)]
        void getCarsByBrand(string brand);

        [OperationContract(IsOneWay = true)]
        void getCarsByYear(int year);
    }

    public interface ICarCompCallback
    {
        [OperationContract(IsOneWay = true)]
        void BrandResult(int result);

        [OperationContract(IsOneWay = true)]
        void YearResult(int result);
    }

    [DataContract]
    public class Car
    {
        string description = "Car";

        [DataMember]
        private string name;

        [DataMember]
        private string brand;

        [DataMember]
        private int price;

        [DataMember]
        private int production_year;

        [DataMember]
        private bool is_electric;

        [DataMember]
        public string Desc
        {
            get { return description; }
            set { description = value; }
        }

        public bool Is_electric { get => is_electric; set => is_electric = value; }
        public int Production_year { get => production_year; set => production_year = value; }
        public int Price { get => price; set => price = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Name { get => name; set => name = value; }

        public Car(string name, string brand, int price, int production_year, bool is_electric)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Production_year = production_year;
            this.Is_electric = is_electric;
        }
    }
}
