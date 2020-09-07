using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Association
{
    public class Customer
    {
        private static int _count = 0;
        public Customer()
        {
            _count++;
            _orders = new List<Order>();
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
        public string Address
        {
            get;
            set;
        }
        private List<Order> _orders;
        public IEnumerable<Order> Orders{
            get{
                if(_orders == null){
                    _orders = new List<Order>();
                }
                return _orders;
            }
        }
        public bool Contains(Order order)
        {
            foreach(Order o in this.Orders)
            {
                if(o.ID == order.ID){
                    return true;
                }
            }
            return false;
        }
        public void AddOrder(Order order)
        {
            if(!this.Contains(order)){
                _orders.Add(order);
            }
        }
        public int OrderCount
        {
            get{
                return this.Orders.Count();
            }
        }
        public double OrderAmount
        {
            get{
                return this.Orders.Sum(p=>p.TotalAmount);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"Customer: {0}({1})
            Address: {2}, 
            Order Count: {3}, Order Amount: {4:C}", 
                this.Name, this.ID, this.Address, this.OrderCount, this.OrderAmount);

            return sb.ToString();
        }
    }
}