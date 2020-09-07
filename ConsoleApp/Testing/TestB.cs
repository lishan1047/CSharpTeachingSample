using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Testing.TestB
{
    public enum Gender{
        Male,
        Female,
    }
    public class Platform{
        private static Platform _platform;
        public static Platform GetPlatform(){
            if(_platform == null){
                _platform = new Platform();
            }
            return _platform;
        }
        private Platform(){
            _cars = new List<Car>();
            _drivers = new List<Driver>();
            _customers = new List<Customer>();
        }
        private List<Car> _cars;
        public IEnumerable<Car> Cars{
            get{
                if(_cars == null){
                    _cars = new List<Car>();
                }
                return _cars;
            }
        }
        private List<Driver> _drivers;
        public IEnumerable<Driver> Drivers{
            get{
                if(_drivers == null){
                    _drivers = new List<Driver>();
                }
                return _drivers;
            }
        }
        private List<Customer> _customers;
        public IEnumerable<Customer> Customers{
            get{
                if(_customers == null){
                    _customers = new List<Customer>();
                }
                return _customers;
            }
        }
        public Customer RegisterCustomer(Customer customer){
            _customers.Add(customer);
            return customer;
        }
        public Car FindCar(string from){
            //  简单地模拟出寻找 from 附近的车辆。
            //  实际上是检测平台在线且没有载客的第一辆车。
            foreach(Car c in this.Cars){
                if(c.IsDriving && !c.IsCarrying){
                    return c;
                }
            }
            return null;
        }
        public Driver RegisterDriver(Driver driver, Car car){
            _drivers.Add(driver);
            _cars.Add(car);
            driver.Car = car;
            car.Driver = driver;
            return driver;
        }
    }
    public class Contact{
        private static int _count = 0;
        public int ID{
            get;
            private set;
        }
        public Contact(string name, Gender gender){
            this.ID = (++_count);
            this.Name = name;
            this.Gender = gender;
        }
        public string Name{
            get;
            private set;
        }
        public Gender Gender{
            get;
            private set;
        }
        public string MobilePhone{
            get;
            set;
        }
        public string GenderPronoun{
            get{
                return (this.Gender == Gender.Male ? "男" : "女");
            }
        }
    }
    public class Customer : Contact{
        public Customer(string name, Gender gender) : base(name, gender){

        }
        public Order OrderRoutine(string from, string to){
            Order order = new Order(this, from, to);
            Platform p = Platform.GetPlatform();
            Car c = p.FindCar(from);
            if(c != null){
                c.Driver.Confirm(order);
            }
            return order;
        }
    }
    public class Driver : Contact{
        public Driver(string name, Gender gender, string license) : base(name, gender){
            this.License = license;
            this.IsDriving = false;
            this.IsCarrying = false;
        }
        public string License{
            get;
            private set;
        }
        public Car Car{
            get;
            set;
        }
        public bool IsCarrying{
            get;
            private set;
        }
        public bool IsDriving{
            get;
            private set;
        }
        public void Drive(){
            this.IsDriving = true;
        }
        public void Confirm(Order order){
            this.IsCarrying = true;
            order.Confirm(this);
        }
    }
    public class Car{
        public string License{
            get;
            set;
        }
        public string Color{
            get;
            set;
        }
        public string Brand{
            get;
            set;
        }
        public Driver Driver{
            get;
            set;
        }
        public bool IsCarrying{
            get{
                return this.Driver.IsCarrying;
            }
        }
        public bool IsDriving{
            get{
                return this.Driver.IsDriving;
            }
        }
    }
    public enum OrderStatus{
        Pending,
        Confirmed,
    }
    public class Order{
        public Order(Customer customer, string from, string to){
            this.Customer = customer;
            this.From = from;
            this.To = to;
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Pending;
        }
        public Customer Customer{
            get;
            private set;
        }
        public void Confirm(Driver driver){
            this.Driver = driver;
            this.Car = driver.Car;
            this.Status = OrderStatus.Confirmed;
        }
        public Car Car{
            get;
            private set;
        }
        public Driver Driver{
            get;
            private set;
        }
        public DateTime OrderDate{
            get;
            private set;
        }
        public string From{
            get;
            private set;
        }
        public string To{
            get;
            private set;
        }
        public OrderStatus Status{
            get;
            private set;
        }
        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
====================================================
OrderDate : {0}     Status : {1}
From: {2} To: {3}
----------------------------------------------------
Customer: {4} {5} {6}
----------------------------------------------------
Driver  : {7} {8} {9} {10}
Car:    : {11} {12} {13}
====================================================",
                this.OrderDate, this.Status,
                this.From, this.To,
                this.Customer.Name, this.Customer.GenderPronoun, this.Customer.MobilePhone,
                this.Driver.Name, this.Driver.GenderPronoun, this.Driver.License, this.Driver.MobilePhone,
                this.Car.License, this.Car.Color, this.Car.Brand);
            return sb.ToString();
        }
    }
    public class Test{
        public static void Testing(){
            Platform p = Platform.GetPlatform();
            Customer c1 = new Customer("C1", Gender.Male){
                MobilePhone = "13805367928"
            };
            p.RegisterCustomer(c1);
            Customer c2 = new Customer("C2", Gender.Female){
                MobilePhone = "13974837465"
            };
            p.RegisterCustomer(c2);
            Driver d1 = new Driver("D1", Gender.Male, "360401"){
                MobilePhone = "13189588837"
            };
            Driver d2 = new Driver("D2", Gender.Male, "360305"){
                MobilePhone = "13709483378"
            };
            Driver d3 = new Driver("D3", Gender.Female, "360678"){
                MobilePhone = "13829223762"
            };
            p.RegisterDriver(d1, 
                new Car(){
                    License = "赣A65376",
                    Color = "白色",
                    Brand = "大众"
                });
            p.RegisterDriver(d2,
                new Car(){
                    License = "赣A79813",
                    Color = "黑色",
                    Brand = "宝马"
                });
            p.RegisterDriver(d3,
                new Car(){
                    License = "赣A99803",
                    Color = "红色",
                    Brand = "奔驰"
                });
            d1.Drive();
            d3.Drive();
            Order o1 = c1.OrderRoutine("华东交大北区南门", "八一广场");
            Order o2 = c2.OrderRoutine("江西财大蛟桥校区北区", "万达广场");
            System.Console.WriteLine(o1);
            System.Console.WriteLine(o2);
        }
    }
}