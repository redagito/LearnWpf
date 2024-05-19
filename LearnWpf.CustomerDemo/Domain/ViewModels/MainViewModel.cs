using CommunityToolkit.Mvvm.ComponentModel;
using LearnWpf.CustomerDemo.DataAccess.Models;
using LearnWpf.CustomerDemo.Domain.Services;
using System.Collections.ObjectModel;

namespace LearnWpf.CustomerDemo.Domain.ViewModels
{
    partial class MainViewModel : ObservableObject
    {
        private ICustomerRepository _customerRepository;

        [ObservableProperty]
        private ObservableCollection<Customer> _customers = new();

        [ObservableProperty]
        private Customer _selectedCustomer = new();

        public MainViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            // TODO Forces sync execution, blocks UI thread, very bad idea!
            _customers = new ObservableCollection<Customer>(_customerRepository.GetCustomersAsync().Result);
        }
    }
}
