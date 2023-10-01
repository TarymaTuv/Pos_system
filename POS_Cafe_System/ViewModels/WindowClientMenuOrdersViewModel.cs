﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            Items.Clear(); ;
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
                if (SelectedItem >= 0)
                {
                    if (Items[SelectedItem].Count == 0)
                    {
                        OrderItems.Add((Items[SelectedItem]));
                    }
                    Items[SelectedItem].Count++;
                    OrderItems.Where(i => i.Id == Items[SelectedItem].Id).First().Count = Items[SelectedItem].Count;
                    Console.WriteLine(OrderItems.Where(i => i.Id == Items[SelectedItem].Id).First().Count);
                    CalculatePrice();
                }
            });
            ReduceCount = new RelayCommand(o=>
            {
                if (SelectedOrderItems >= 0)
                {
                    OrderItems[SelectedOrderItems].Count -= 1; //уменьшение количества выбранного товара в корзине
                                                               //если его кол-во = 0, то его надо убрать из корзины
                    if (OrderItems[SelectedOrderItems].Count == 0)
                    {
                        OrderItems.Remove(OrderItems[SelectedOrderItems]);
                        Items[SelectedItem].Count--;
                        CalculatePrice();
                    }
                }
            });
            AddCount= new RelayCommand(o=>
            {
                if (SelectedOrderItems >= 0)
                {
                    OrderItems[SelectedOrderItems].Count += 1;//увеличение количества выбранного товара в корзине
                }
            });
        }
        private void CalculatePrice()
        {
            double price = 0;
            foreach(var item in OrderItems)
            {
                price += item.Price * item.Count;
            }
            PriceOrder = price.ToString();
        }
        public ICommand CreateOrder { get; set; }
        public ICommand AddInOrder { get; set; }
        public ICommand AddCount { get; set; }
        public ICommand ReduceCount { get; set; }

        public ObservableCollection<ItemOrder> OrderItems { get; set; } = new ObservableCollection<ItemOrder>(); // то что будет в корзине
        public ObservableCollection<ItemOrder> Items { get; set; } = new ObservableCollection<ItemOrder>(); // то что может заказать клиент


        [Reactive]
        public int SelectedItem { get; set; } = 0;  // то что может заказать клиент, выбранный предмет
        [Reactive]
        public int SelectedOrderItems { get; set; } = 0;// то что будет в корзине, выбранный предмет
        [Reactive]
        public string PriceOrder { get; set; } = "0"; //цена заказа
    }
}
