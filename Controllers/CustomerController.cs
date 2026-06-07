using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basic_CURD_Operation.Models;
using Basic_CURD_Operation.Data;
using System.Collections.Generic;
using System.Linq;

namespace Basic_CURD_Operation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
       public async Task<IActionResult> GetAllCUstomer()
        {
            List<Customer> customers = new List<Customer>();
            customers = await _context.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.CustomerName)
                .Select(c => new Customer
                 {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    EmailID = c.EmailID,
                    PhoneNumber = c.PhoneNumber,
                    IsActive = c.IsActive
                 }).ToListAsync();
            //customers = await _context.Customers.ToListAsync();
            //customers = (from c in customers
            //             select new Customer
            //             {
            //                 CustomerId = c.CustomerId,
            //                 CustomerName = c.CustomerName,
            //                 EmailID = c.EmailID,
            //                 PhoneNumber = c.PhoneNumber,
            //                 IsActive = c.IsActive
            //             }).ToList();
            //customers = customers.Select(c => new Customer
            //{
            //    CustomerId = c.CustomerId,
            //    CustomerName = c.CustomerName,
            //    EmailID = c.EmailID,
            //    PhoneNumber = c.PhoneNumber,
            //    IsActive = c.IsActive
            //}).ToList();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.EmailID = customer.EmailID;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.IsActive = customer.IsActive;
            await _context.SaveChangesAsync();
            return Ok(existingCustomer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
