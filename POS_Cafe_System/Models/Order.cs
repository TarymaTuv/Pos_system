using POS_Cafe_System.Commands;
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
        public static int staticID = WorkerDB.MaxOrderID()+1;
        public bool IsReady { get; set; } = false;
        public bool IsPay { get; set; } = false;
        public string Id { get; set; }
        public double Price { get; set; } = 0;
        public List<ItemOrder> OrderItems { get; set; } = new List<ItemOrder>();
        public Order(List<ItemOrder> items)
        {
            Id = staticID + "";
            OrderItems = items;
            staticID++;
        }
        public Order(List<ItemOrder> items, string id)
        {
            Id = id;
            OrderItems = items;
        }
    }
}
