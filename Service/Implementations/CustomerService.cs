using Common.HttpHelpers;
using Domain.Models;
using Service.Interfaces;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CustomerService : IServiceBase<Customer>
    {
        public EResponseBase<Customer> Get()
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Customers.ToList();
                }
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;
        }
        public EResponseBase<Customer> GetById(int ID)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Customers.Find(ID);
                }
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }
        public EResponseBase<Customer> Add(Customer customer)
        {
            customer.State = true;
            customer.CreatedAt = DateTime.Now;
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                response.Status = true;
                response.Message = "Success";
                response.Object = customer;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public EResponseBase<Customer> Update(Customer customer)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    var newCustomer = context.Customers.Find(customer.CustomerID);
                    newCustomer.Name = customer.Name;
                    newCustomer.LastName = customer.LastName;
                    newCustomer.Phone = customer.Phone;
                    newCustomer.Address = customer.Address;
                    context.SaveChanges();
                }
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }
        public EResponseBase<Customer> Delete(int ID)
        {
            EResponseBase<Customer> response = new EResponseBase<Customer>();
            try
            {
                using (var context = new DataContext())
                {
                    var customer = context.Customers.Find(ID);
                    customer.State = false;
                    context.SaveChanges();
                }
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
