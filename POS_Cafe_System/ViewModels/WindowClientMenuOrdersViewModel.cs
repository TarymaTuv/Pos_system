using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            //создание и отправление заказа в базу данных
            CreateOrder = new RelayCommand(o=>
            {
                List<ItemOrder> items = new List<ItemOrder>();
                items.AddRange(OrderItems);

                Order order = new Order(items);
                order.Price = double.Parse(PriceOrder);

                //тут сделать его отправление в бд

            });
            //у клиента есть корзина(заказ) куда он будет добавлять предметы, этот метод будет у всех предметов в списке
            AddInOrder = new RelayCommand(o=>
            {
                OrderItems.Add((Items[SelectedItem]));
                PriceOrder = (Items[SelectedItem].Price).ToString();
            });
            ReduceCount = new RelayCommand(o=>
            {
                OrderItems[SelectedOrderItems].Count -= 1; //уменьшение количества выбранного товара в корзине
                //если его кол-во = 0, то его надо убрать из корзины
                if (OrderItems[SelectedOrderItems].Count == 0)
                {
                    OrderItems.Remove(OrderItems[SelectedOrderItems]);
                    PriceOrder = (Items[SelectedItem].Price * Items[SelectedItem].Count).ToString();
                }
            });
            AddCount= new RelayCommand(o=>
            {
                OrderItems[SelectedOrderItems].Count += 1;//увеличение количества выбранного товара в корзине
            });
        }
        public ICommand CreateOrder { get; set; }
        public ICommand AddInOrder { get; set; }
        public ICommand AddCount { get; set; }
        public ICommand ReduceCount { get; set; }
        [Reactive]
        public ObservableCollection<ItemOrder> OrderItems { get; set; } = new ObservableCollection<ItemOrder>(); // то что будет в корзине
        [Reactive]
        public List<ItemOrder> Items { get; set; }// то что может заказать клиент

        [Reactive]
        public int SelectedItem { get; set; } = 0;  // то что может заказать клиент, выбранный предмет
        [Reactive]
        public int SelectedOrderItems { get; set; } = 0;// то что будет в корзине, выбранный предмет
        [Reactive]
        public string PriceOrder { get; set; } = "0"; //цена заказа
    }
}
