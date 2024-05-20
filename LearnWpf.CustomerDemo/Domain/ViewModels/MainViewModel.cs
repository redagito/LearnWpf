using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [NotifyCanExecuteChangedFor(nameof(DeleteCustomerCommand))]
        private Customer? _selectedCustomer = null;

        /// <summary>
        /// Creates new customer, reloads customer list and sets currently selected customer to newly created customer
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task NewCustomerAsync(CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.CreateCustomerAsync(new Customer(), cancellationToken);
            await ReloadCustomers(cancellationToken);
            SelectedCustomer = customer;
        }

        private bool DeleteCustomerCanExecute() => SelectedCustomer != null;

        [RelayCommand(CanExecute = nameof(DeleteCustomerCanExecute))]
        private async Task DeleteCustomerAsync(CancellationToken cancellationToken) 
        {
            if (SelectedCustomer == null) return;

            await _customerRepository.DeleteCustomerAsync(SelectedCustomer.Id, cancellationToken);
            await ReloadCustomers(cancellationToken);
        }

        private async Task ReloadCustomers(CancellationToken cancellationToken)
        {
            Customers = new ObservableCollection<Customer>(await _customerRepository.GetCustomersAsync(cancellationToken));
        }

        public MainViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            // TODO Forces sync execution, blocks UI thread, very bad idea!
            _customers = new ObservableCollection<Customer>(_customerRepository.GetCustomersAsync().Result);
        }
    }
}
