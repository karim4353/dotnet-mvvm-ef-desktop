using System.Threading.Tasks;
using Xunit;
using Moq;
using ENSIT.MVVMApp.ViewModels;
using ENSIT.MVVMApp.Services;
using ENSIT.MVVMApp.Models;
using System.Collections.Generic;
using System.Threading;

namespace ENSIT.MVVMApp.Tests
{
    public class ViewModelTests
    {
        [Fact]
        public async Task MainViewModel_Search_PopulatesCustomers()
        {
            var mock = new Mock<IDataService>();
            mock.Setup(m => m.SearchCustomersAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Customer> { new Customer{ Id = 1, Name = "A"} });
            var vm = new MainViewModel(mock.Object);
            await vm.SearchAsync();
            Assert.Single(vm.Customers);
        }
    }
}
