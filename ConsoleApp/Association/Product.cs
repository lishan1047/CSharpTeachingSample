using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Association
{
    public class Product
    {
        private static int _count = 0;
        public Product()
        {
            _count++;
            _orderDetails = new List<OrderDetail>();
            this.ID = _count;
        }
        public int ID
        {
            get;
            private set;
        }
        public string Name
        {
            get;
            set;
        }
        public double UnitPrice
        {
            get;
            set;
        }
        public double SalesQuantity
        {
            get{
                return this.OrderDetails.Sum(p=>p.Quantity);
            }
        }
        public double SalesAmount
        {
            get{
                return this.OrderDetails.Sum(p=>p.Amount);
            }
        }
        private List<OrderDetail> _orderDetails;
        public IEnumerable<OrderDetail> OrderDetails
        {
            get{
                if(_orderDetails == null){
                    _orderDetails = new List<OrderDetail>();
                }
                return _orderDetails;
            }
        }
        public void AddOrderDetail(OrderDetail orderDetail){
            if(orderDetail.Product == this){
                _orderDetails.Add(orderDetail);
            }
        }
        private int _unitsInStock = 0;
        public int UnitsInStock
        {
            get{
                return _unitsInStock;
            }
            set{
                if(value < 0){
                    throw new System.Exception(
                        string.Format("Product {0} (units in stock {1}) is insufficient.", 
                            this.Name, _unitsInStock)
                    );
                }
                _unitsInStock = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"Product: {0}({1})
            Unit Price: {2:C}, Units In Stock: {3}, 
            Sales Quantity: {4}, Sales Amount: {5:C}",
                this.Name, this.ID, this.UnitPrice, this.UnitsInStock, this.SalesQuantity, this.SalesAmount);

            return sb.ToString();
        }
    }
}