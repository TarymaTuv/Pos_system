using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POS_Cafe_System.Commands;
using POS_Cafe_System.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace POS_Cafe_System.ViewModels
{
    public class WindowClientMenuOrdersViewModel:ReactiveObject
    {
        public WindowClientMenuOrdersViewModel()
        {
            Items = new List<ItemOrder>();
            Items.AddRange(WorkerDB.OrderItems());
            Console.WriteLine("ItemCount: " + Items.Count);
            //тут сделать создание заказа и его отправление в другое окно
            CreateOrder = new RelayCommand(o=>
            {

            });
            //у клиента есть корзина(заказ) куда он будет добавлять предметы, этот метод будет у всех предметов в списке
            AddInOrder = new RelayCommand(o=>
            {
                OrderItems.OrderItems.Add((Items[SelectedItem], 1));
                Console.WriteLine("ADD");
            });
            ReduceCount = new RelayCommand(o=>
            {
                OrderItems.OrderItems[SelectedOrderItems] = (OrderItems.OrderItems[SelectedOrderItems].item, OrderItems.OrderItems[SelectedOrderItems].count - 1); //уменьшение количества выбранного товара в корзине
                //если его кол-во = 0, то его надо убрать из корзины
                if (OrderItems.OrderItems[SelectedOrderItems].count == 0)
                {
                    OrderItems.OrderItems.Remove(OrderItems.OrderItems[SelectedOrderItems]);
                }
            });
            AddCount= new RelayCommand(o=>
            {
                OrderItems.OrderItems[SelectedOrderItems] = (OrderItems.OrderItems[SelectedOrderItems].item, OrderItems.OrderItems[SelectedOrderItems].count + 1);//увеличение количества выбранного товара в корзине
            });
        }
        public ICommand CreateOrder { get; set; }
        public ICommand AddInOrder { get; set; }
        public ICommand AddCount { get; set; }
        public ICommand ReduceCount { get; set; }
        [Reactive]
        public Order OrderItems { get; set; } = new Order(new List<(ItemOrder item, int count)>()); // то что будет в корзине
        [Reactive]
        public List<ItemOrder> Items { get; set; }// то что может заказать клиент

        [Reactive]
        public int SelectedItem { get; set; }// то что может заказать клиент, выбранный предмет
        [Reactive]
        public int SelectedOrderItems { get; set; }// то что будет в корзине, выбранный предмет
    }
}
