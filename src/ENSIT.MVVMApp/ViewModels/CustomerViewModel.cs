using ENSIT.MVVMApp.Models;
using System.Threading.Tasks;
namespace ENSIT.MVVMApp.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public Customer Model { get; }
        public CustomerViewModel(Customer c) { Model = c; }
        public async Task SaveAsync() { /* placeholder for save logic */ await Task.CompletedTask; }
    }
}
