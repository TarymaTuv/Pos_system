using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;
using POS_Cafe_System.Commands;
using POS_Cafe_System.Models;
using ReactiveUI;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace POS_Cafe_System.ViewModels
{
    public class WindowEmployeeMenuOrdersViewModel:ReactiveObject
    {
        public WindowEmployeeMenuOrdersViewModel()
        {
            //таймер для обновления заказов в реалтайме

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += Update;
            timer.AutoReset = true;
            timer.Enabled = true;

            //при необходимости разделить на 2 метода, т.к. сейчас это и сообщение о готовности заказа и его удаление
            Ready = new RelayCommand(o =>
            {
                if (SelectedItem < 0)
                {
                    return;
                }
                if (Orders[SelectedItem].IsReady)               //отправляем в бд, что заказ готов
                {
                    WorkerDB.ReadyOrder(Orders[SelectedItem].Id);
                }
            });
            Pay = new RelayCommand(o =>
            {
                WorkerDB.DeleteOrder(Orders[SelectedItem].Id);
            });
        }
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        [Reactive]
        public int SelectedItem { get; set; } = 0;
        public ICommand Ready { get; set; }
        public ICommand Pay { get; set; }

        private void Update(object sender, EventArgs e)
        {
            Console.WriteLine("event time");
        }
    }
}
