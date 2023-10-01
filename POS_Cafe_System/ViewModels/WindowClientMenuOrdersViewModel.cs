using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using DynamicData;
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
            Items.Clear();
            Items.AddRange(WorkerDB.OrderItems());

            //создание и отправление заказа в базу данных
            CreateOrder = new RelayCommand(o=>
            {
                List<ItemOrder> items = new List<ItemOrder>();
                items.AddRange(OrderItems);

                Order order = new Order(items);
                order.Price = double.Parse(PriceOrder);

                WorkerDB.AddOrder(order);

                foreach (var item in OrderItems)
                {
                    item.Count = 0;
                }
                PriceOrder = "0";
                OrderItems.Clear();

            });
            //у клиента есть корзина(заказ) куда он будет добавлять предметы, этот метод будет у всех предметов в списке
            AddInOrder = new RelayCommand(o=>
            {
                Add();
            });
            ReduceCount = new RelayCommand(param =>
            {
                var order = OrderItems.Where(o => o.Name == param as string).First();
                order.Count--; //уменьшение количества выбранного товара в корзине
                                                                                  //если его кол-во = 0, то его надо убрать из корзины
                if (order.Count == 0)
                {
                    OrderItems.Remove(order);
                }
                CalculatePrice();
            });
            AddCount= new RelayCommand(param =>
            {
                OrderItems.Where(o => o.Name == param as string).First().Count++; //увеличение количества выбранного товара в корзине                                             
                CalculatePrice();
            });
        }

        public ICommand CreateOrder { get; set; }
        public ICommand AddInOrder { get; set; }
        public ICommand AddCount { get; set; }
        public ICommand ReduceCount { get; set; }

        public ObservableCollection<ItemOrder> OrderItems { get; set; } = new ObservableCollection<ItemOrder>(); // то что будет в корзине
        public ObservableCollection<ItemOrder> Items { get; set; } = new ObservableCollection<ItemOrder>(); // то что может заказать клиент

        // то что может заказать клиент, выбранный предмет
        int _selectedItem = 0;
        public int SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedItem, value);
                Add();
            }
        }


        [Reactive]
        public int SelectedOrderItems { get; set; } = 0;// то что будет в корзине, выбранный предмет
        [Reactive]
        public string PriceOrder { get; set; } = "0"; //цена заказа

        /// <summary>
        /// Высчитывание итоговой цены
        /// </summary>
        private void CalculatePrice()
        {
            double price = 0;
            foreach (var item in OrderItems)
            {
                price += item.Price * item.Count;
            }
            PriceOrder = price.ToString();
        }
        /// <summary>
        /// добавление товара в корзину, если же есть, то добавляет кол-во
        /// </summary>
        private void Add()
        {
            if (SelectedItem >= 0)
            {
                if (!OrderItems.Contains(Items[SelectedItem]))
                {
                    OrderItems.Add((Items[SelectedItem]));
                }
                OrderItems.Where(i => i.Id == Items[SelectedItem].Id).First().Count += 1;
                CalculatePrice();
            }
        }
    }
}
