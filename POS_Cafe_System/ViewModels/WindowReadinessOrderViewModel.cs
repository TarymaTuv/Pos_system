using POS_Cafe_System.Commands;
using POS_Cafe_System.Models;
using ReactiveUI;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Cafe_System.ViewModels
{
    public class WindowReadinessOrderViewModel:ReactiveObject
    {
        public WindowReadinessOrderViewModel()
        {
            //таймер для обновления заказов в реалтайме

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Update;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        [Reactive]
        public ObservableCollection<Order> OrdersInProgress { get; set; } = new ObservableCollection<Order>();
        [Reactive]
        public ObservableCollection<Order> OrdersReady { get; set; } = new ObservableCollection<Order>();


        private void Update(object sender, EventArgs e)
        {
            List<Order> allOrders = new List<Order>(); //отредактировать методом чтения из БД
            allOrders.AddRange(WorkerDB.ReadAllOrder());

            OrdersInProgress.Clear();
            OrdersReady.Clear();

            foreach (var order in allOrders)
            {
                if(order.IsReady)
                {
                    OrdersReady.Add(order);
                }
                else
                {
                    OrdersInProgress.Add(order);
                }
            }
        }
    }
}
