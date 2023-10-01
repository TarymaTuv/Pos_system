using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
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
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Update;
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();

            Orders.AddRange(WorkerDB.ReadAllOrder());


            Ready = new RelayCommand(param =>
            {
                //отправляем в бд, что заказ готов
                WorkerDB.ReadyOrder(Orders.Where(o => o.Id == param as string).First().Id);
            });
            Pay = new RelayCommand(param =>
            {
                Orders.Where(o => o.Id == param as string).First().IsPay = true;
                WorkerDB.DeleteOrder(Orders.Where(o => o.Id == param as string).First().Id);
            });
            DeleteOrder = new RelayCommand(param =>
            {
                WorkerDB.DeleteOrder(Orders.Where(o => o.Id == param as string).First().Id);
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
