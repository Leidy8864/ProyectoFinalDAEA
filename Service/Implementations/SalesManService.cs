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
    public class SalesManService : IServiceBase<SalesMan>
    {
        public EResponseBase<SalesMan> Get()
        {
            EResponseBase<SalesMan> response = new EResponseBase<SalesMan>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.SalesMans.ToList();
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
        public EResponseBase<SalesMan> GetById(int ID)
        {
            EResponseBase<SalesMan> response = new EResponseBase<SalesMan>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.SalesMans.Find(ID);
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
        public EResponseBase<SalesMan> Add(SalesMan employee)
        {
            employee.State = true;
            employee.CreatedAt = DateTime.Now;
            EResponseBase<SalesMan> response = new EResponseBase<SalesMan>();
            try
            {
                using (var context = new DataContext())
                {
                    context.SalesMans.Add(employee);
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
        public EResponseBase<SalesMan> Update(SalesMan employee)
        {
            EResponseBase<SalesMan> response = new EResponseBase<SalesMan>();
            try
            {
                using (var context = new DataContext())
                {
                    var newSalesMan = context.SalesMans.Find(employee.SalesManID);
                    newSalesMan.Name = employee.Name;
                    newSalesMan.LastName = employee.LastName;
                    newSalesMan.Email = employee.Email;
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
        public EResponseBase<SalesMan> Delete(int ID)
        {
            EResponseBase<SalesMan> response = new EResponseBase<SalesMan>();
            try
            {
                using (var context = new DataContext())
                {
                    var employee = context.SalesMans.Find(ID);
                    employee.State = false;
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
