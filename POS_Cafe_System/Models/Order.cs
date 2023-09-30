using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Models
{
    public class Order
    {
        public static int staticID = 0;
        public int Id { get; set; }
        public double Price { get; set; }
        public List<(OrderItem item, int count)> OrderItems { get; set; } = new List<(OrderItem item, int count)>();
        public Order(List<(OrderItem item, int count)> items)
        {
            OrderItems = items;

            foreach(var item in items)
            {
                Price += item.item.Price * item.count; //цена заказываемого предмета * на его количество
            }
        }
    }
}
