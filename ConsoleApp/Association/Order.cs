using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Association
{
    public class Order
    {
        private static int _count = 0;
        public Order(Customer cusotmer)
        {
            _count++;
            this.ID = _count;
            _details = new List<OrderDetail>();
            this.Customer = cusotmer;
            this.Customer.AddOrder(this);
            this.OrderDate = DateTime.Now;
        }
        public int ID
        {
            get;
            private set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public Customer Customer
        {
            get;
            private set;
        }
        public double TotalAmount
        {
            get{
                double s = 0;
                foreach(OrderDetail od in this.Details)
                {
                    s += od.Amount;
                }
                return s;
            }
        }
        private List<OrderDetail> _details;
        public IEnumerable<OrderDetail> Details{
            get{
                if(_details == null){
                    _details = new List<OrderDetail>();
                }
                return _details;
            }
        }

        public bool Contains(Product product)
        {
            foreach(OrderDetail od in this.Details)
            {
                if(od.Product.ID == product.ID) {
                    return true;
                }
            }
            return false;
        }
        public OrderDetail GetDetail(Product product)
        {
            foreach(OrderDetail od in this.Details)
            {
                if(od.Product.ID == product.ID){
                    return od;
                }
            }
            return null;
        }
        public OrderDetail AddProduct(
            Product product, int quantity)
        {
            return this.AddProduct(
                product, quantity, product.UnitPrice);
        }
        public OrderDetail AddProduct(
            Product product, int quantity, double unitPrice)
        {
            OrderDetail od = this.GetDetail(product);
            if(od == null){
                od = new OrderDetail(this, product);
            }

            od.Quantity += quantity;
            od.UnitPrice = unitPrice;

            try{
                product.UnitsInStock -= quantity;
                _details.Add(od);
                product.AddOrderDetail(od);
                return od;
            }
            catch(System.Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"=================================================
ID: {0}, Date: {1:yyyy-MM-dd}, Total Amount : {2:C}
-------------------------------------------------
Product Name    Unit Price  Quantity    Amount
-------------------------------------------------",
                this.ID, this.OrderDate, this.TotalAmount);

            foreach(OrderDetail od in this.Details)
            {
                sb.AppendFormat(@"
{0,-16}{1,-12:C}{2,-12}{3:C}",
                    od.Product.Name, od.UnitPrice, 
                    od.Quantity, od.Amount);
            }

            sb.AppendFormat(@"
=================================================");

            return sb.ToString();
        } 
    }
}