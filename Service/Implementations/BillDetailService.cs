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
    public class BillDetailService : IServiceBase<BillDetail>
    {
        public EResponseBase<BillDetail> Get()
        {
            EResponseBase<BillDetail> response = new EResponseBase<BillDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.BillDetails.ToList();
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
        public EResponseBase<BillDetail> GetById(int ID)
        {
            EResponseBase<BillDetail> response = new EResponseBase<BillDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.BillDetails.Find(ID);
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

        public EResponseBase<BillDetail> Add(BillDetail orderDetail)
        {
            EResponseBase<BillDetail> response = new EResponseBase<BillDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    orderDetail.State = true;
                    context.BillDetails.Add(orderDetail);
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
        public EResponseBase<BillDetail> Delete(int ID)
        {
            EResponseBase<BillDetail> response = new EResponseBase<BillDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    var orderDetail = context.BillDetails.Find(ID);
                    orderDetail.State = false;
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

        public EResponseBase<BillDetail> Update(BillDetail billDetail)
        {
            EResponseBase<BillDetail> response = new EResponseBase<BillDetail>();
            try
            {
                using (var context = new DataContext())
                {
                    var newBillDetail = context.BillDetails.Find(billDetail.BillDetailID);
                    newBillDetail.Price = billDetail.Price;
                    newBillDetail.ProductID = billDetail.ProductID;
                    newBillDetail.Quantity = billDetail.Quantity;
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
    }
}
