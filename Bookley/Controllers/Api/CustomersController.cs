using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookley.Models;
using Bookley.Dtos;
using AutoMapper;

namespace Bookley.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {                                                              //delegate!
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //Get /api/customers
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return Mapper.Map<Customer, CustomerDto>(customer);
        }


        //Post /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customeDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customeDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customeDto.Id = customer.Id;

            return customeDto;
        }

        // Put /api/customers/1
        [HttpPut]
        public void UppdateCustomer(int id, CustomerDto customerDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        // Delete /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}
