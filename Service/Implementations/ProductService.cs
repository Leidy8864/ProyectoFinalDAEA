using Common.HttpHelpers;
using Domain.Models;
using Infraestructure.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProductService : IServiceBase<Product>
    {

        public EResponseBase<Product> Get()
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Products.ToList();
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

        public EResponseBase<Product> GetById(int ID)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Products.Find(ID);
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
        public EResponseBase<Product> Add(Product product)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    product.CreatedAt = DateTime.Now;
                    product.State = true;
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                response.Status = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public EResponseBase<Product> Update(Product product)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    var newProduct = context.Products.Find(product.ProductID);
                    newProduct.Name = product.Name;
                    newProduct.Stock = product.Stock;
                    newProduct.UnitPrice = product.UnitPrice;
                    newProduct.Description = product.Description;
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

        public EResponseBase<Product> Delete(int ID)
        {
            EResponseBase<Product> response = new EResponseBase<Product>();
            try
            {
                using (var context = new DataContext())
                {
                    var customer = context.Products.Find(ID);
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

        public EResponseBase<Product> Create(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
