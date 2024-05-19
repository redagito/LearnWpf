using LearnWpf.CustomerDemo.DataAccess.DataContexts;
using LearnWpf.CustomerDemo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnWpf.CustomerDemo.Domain.Services
{
    class CustomerRepository : ICustomerRepository
    {
        private CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            return _context.Customers.ToListAsync(cancellationToken);
        }

        public Task<Customer?> GetCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task DeleteCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            return _context.Customers.Where(c => c.Id == id).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var value = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return value.Entity;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            // Track if untracked
            if (!_context.Customers.Local.Any(c => c.Id == customer.Id))
            {
                _context.Customers.Attach(customer);
            }
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
