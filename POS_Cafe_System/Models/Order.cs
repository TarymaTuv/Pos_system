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
        public List<(ItemOrder item, int count)> OrderItems { get; set; } = new List<(ItemOrder item, int count)>();
        public Order(List<(ItemOrder item, int count)> items)
        {
            this.WhenAnyValue(x => x.OrderItems).Subscribe(x =>
            {
                Price = 0;
                foreach (var item in OrderItems)
                {
                    Price += item.item.Price * item.count;
                }
            });

            OrderItems = items;
            staticID++;
        }
    }
}
