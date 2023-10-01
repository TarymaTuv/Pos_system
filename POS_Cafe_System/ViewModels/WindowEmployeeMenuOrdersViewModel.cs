using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

            //таймер для обновления заказов в реалтайме
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Update;
            timer.Interval = new TimeSpan(0,0,2);
            timer.Start();

            Orders.AddRange(WorkerDB.ReadAllOrder());


            Ready = new RelayCommand(o =>
            {
                if (SelectedItem < 0)
                {
                    return;
                }
                //отправляем в бд, что заказ готов
                if (Orders[SelectedItem].IsReady)               
                {
                    WorkerDB.ReadyOrder(Orders[SelectedItem].Id);
                }
            });
            Pay = new RelayCommand(o =>
            {
                WorkerDB.DeleteOrder(Orders[SelectedItem].Id);
            });
            DeleteOrder = new RelayCommand(o =>
            {
                Orders[SelectedItem].IsPay = true;
                Orders.Remove(Orders[SelectedItem]);
            });
        }
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        [Reactive]
        public int SelectedItem { get; set; } = 0;
        public ICommand Ready { get; set; }
        public ICommand Pay { get; set; }
        public ICommand DeleteOrder { get; set; }

        private void Update(object sender, EventArgs e)
        {
            Orders.Clear();
            Orders.AddRange(WorkerDB.ReadAllOrder());
        }
    }
}
