using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody;

namespace POS_Cafe_System.ViewModels
{
    public class WindowClientMenuOrdersViewModel:ReactiveObject
    {
        public WindowClientMenuOrdersViewModel()
        {
            CreateOrder = ReactiveCommand.Create(() =>
            {

            });
        }
        public ReactiveCommand<Unit, Unit> CreateOrder { get; }
    }
}
