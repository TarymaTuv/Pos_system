using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.Models
{
    public class Order
    {
        public static int staticID = 0;
        public int Id { get; set; }
        public double Price { get; set; } = 0;
        public List<ItemOrder> OrderItems { get; set; } = new List<ItemOrder>();
        public Order(List<ItemOrder> items)
        {
            OrderItems = items;
            staticID++;
        }
    }
}
