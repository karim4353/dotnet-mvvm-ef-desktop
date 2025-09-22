using ENSIT.MVVMApp.Models;
using System;
namespace ENSIT.MVVMApp.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Order Model { get; }
        public OrderViewModel(Order o) { Model = o; }
    }
}
