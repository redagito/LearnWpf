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
        [NotifyCanExecuteChangedFor(nameof(SaveCustomerCommand))]
        private Customer? _selectedCustomer = null;

        [RelayCommand(CanExecute = nameof(UpdateDeleteCustomerCanExecute))]
        private async Task SaveCustomerAsync(CancellationToken cancellationToken)
        {
            if (SelectedCustomer == null) return;
            await _customerRepository.UpdateCustomerAsync(SelectedCustomer, cancellationToken);
            await ReloadCustomersAsync(cancellationToken);
        }

        /// <summary>
        /// Creates new customer, reloads customer list and sets currently selected customer to newly created customer
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task NewCustomerAsync(CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.CreateCustomerAsync(new Customer(), cancellationToken);
            await ReloadCustomersAsync(cancellationToken);
            SelectedCustomer = customer;
        }

        private bool UpdateDeleteCustomerCanExecute() => SelectedCustomer != null;

        [RelayCommand(CanExecute = nameof(UpdateDeleteCustomerCanExecute))]
        private async Task DeleteCustomerAsync(CancellationToken cancellationToken) 
        {
            if (SelectedCustomer == null) return;

            await _customerRepository.DeleteCustomerAsync(SelectedCustomer.Id, cancellationToken);
            await ReloadCustomersAsync(cancellationToken);
        }

        private async Task ReloadCustomersAsync(CancellationToken cancellationToken)
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
