using CinemaApp.Customer.Contract;
using CinemaAppInfra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Models.Customer> CreateCustomer(Models.Models.Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<int> DeleteCustomer(Models.Models.Customer customer)
        {
            _context.Customer.Remove(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<Models.Models.Customer> GetCustomerById(int id)
        {
            if (id == 0)
            {
                throw new Exception();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                throw new Exception();
            }
            else
            {
                return customer;
            }

        }

        public async Task<IEnumerable<Models.Models.Customer>> GetCustomerList()
        {
            return await _context.Customer
             .ToListAsync();
        }

        public async Task<int> UpdateCustomer(Models.Models.Customer customer)
        {
            _context.Customer.Update(customer);
            return await _context.SaveChangesAsync();
        }
    }
}
