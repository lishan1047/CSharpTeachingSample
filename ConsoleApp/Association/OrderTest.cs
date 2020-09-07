using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Association
{
    public static class OrderTest
    {
        public static void Test()
        {
            //  创建产品。
            Product p1 = new Product(){
                Name = "p1",
                UnitPrice = 25.5,
                UnitsInStock = 10
            };
            Product p2 = new Product(){
                Name = "p2",
                UnitPrice = 45.2,
                UnitsInStock = 30
            };
            Product p3 = new Product(){
                Name = "p3",
                UnitPrice = 55.3,
                UnitsInStock = 15
            };
            //  创建客户。
            Customer c1 = new Customer(){
                Name = "c1",
                Address = "Nanchang"
            };
            Customer c2 = new Customer(){
                Name = "c2",
                Address = "Shanghai"
            };
            Customer c3 = new Customer(){
                Name = "c3",
                Address = "Shanghai"
            };
            //  创建订单，并输出订单信息。
            Order o1 = new Order(c1);
            o1.AddProduct(p1, 10);
            o1.AddProduct(p2, 5);
            Console.WriteLine(o1);
            Order o2 = new Order(c2);
            o2.AddProduct(p2, 5);
            o2.AddProduct(p3, 4);
            Console.WriteLine(o2);
            Order o3 = new Order(c2);
            o3.AddProduct(p1, 30);
            o3.AddProduct(p3, 5, 50.5);
            Console.WriteLine(o3);
            //  输出客户信息。
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            //  输出产品信息。
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
    }
}