using LearnWpf.CustomerDemo.DataAccess.Models;

namespace LearnWpf.CustomerDemo.Domain.Services
{
    internal interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
        Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default);
        Task<Customer?> GetCustomerAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default);
        Task<Customer> UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}