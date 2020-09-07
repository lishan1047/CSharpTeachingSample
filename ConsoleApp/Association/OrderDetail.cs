using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Association
{
    public class OrderDetail
    {
        public OrderDetail(Order order, Product product)
        {
            this.Order = order;
            this.Product = product;
        }
        public Order Order
        {
            get;
            private set;
        }
        public Product Product
        {
            get;
            private set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public double UnitPrice
        {
            get;
            set;
        }
        public double Amount
        {
            get{
                return this.Quantity * this.UnitPrice;
            }
        }
    }
}