using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using POS_Cafe_System.Commands;
using POS_Cafe_System.Models;
using ReactiveUI;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;

namespace POS_Cafe_System.ViewModels
{
    public class WindowClientMenuOrdersViewModel:ReactiveObject
    {
        public WindowClientMenuOrdersViewModel()
        {
            Items = new List<ItemOrder>();
            Items.AddRange(WorkerDB.OrderItems());
            //тут сделать создание заказа и его отправление в другое окно
            CreateOrder = ReactiveCommand.Create(() =>
            {

            });
            //у клиента есть корзина(заказ) куда он будет добавлять предметы, этот метод будет у всех предметов в списке
            AddInOrder = ReactiveCommand.Create(() =>
            {

            });
            ReduceCount = ReactiveCommand.Create(() =>
            {

            });
            AddCount= ReactiveCommand.Create(() =>
            {

            });
        }
        public ReactiveCommand<Unit, Unit> CreateOrder { get; }
        public ReactiveCommand<Unit, Unit> AddInOrder { get; }
        public ReactiveCommand<Unit, Unit> AddCount { get; }
        public ReactiveCommand<Unit, Unit> ReduceCount { get; }
        [Reactive]
        public List<Order> OrderItems { get; set; } = new List<Order>();// то что будет в корзине
        [Reactive]
        public List<ItemOrder> Items { get; set; }// то что может заказать клиент
    }
}
