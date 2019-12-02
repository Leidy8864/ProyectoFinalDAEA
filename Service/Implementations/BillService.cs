using Common.HttpHelpers;
using Domain.CustomModels;
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
    public class BillService : IServiceBase<Bill>
    {
        public EResponseBase<CustomBill> Get()
        {
            EResponseBase<CustomBill> response = new EResponseBase<CustomBill>();
            try
            {

                using (var context = new DataContext())
                {
                    response.List = context.Bills.Join(context.BillDetails, o => o.BillID, od => od.BillID,
                                                        (o, od) => new CustomBill
                                                        {
                                                            BillID = o.BillID,
                                                            Customer = o.Customer.Name,
                                                            SalesMan = o.SalesMan.Name,
                                                            Code = o.Code,
                                                            Quantity = od.Quantity,
                                                            Price = od.Price,
                                                            IGV = o.IGV,
                                                            Subtotal = (od.Quantity * od.Price),
                                                            SalesTax = o.IGV / 100 * od.Quantity * od.Price,
                                                            Total = (od.Quantity * od.Price) + (o.IGV / 100 * od.Quantity * od.Price
                                                            )}).ToList();
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

        //Filtro por Empleado
        public EResponseBase<CustomBill> GetBySalesMan(String filter)
        {
            EResponseBase<CustomBill> response = new EResponseBase<CustomBill>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Bills.Join(context.BillDetails, o => o.CustomerID, od => od.BillID,
                                                          (o, od) => new
                                                          {
                                                              o,
                                                              od
                                                          }).Join(context.SalesMans, c => c.o.SalesManID, e => e.SalesManID,
                                                          (c, e) => new
                                                          {
                                                              c,
                                                              e
                                                          }).Where(x => x.e.Name.Equals(filter) )
                                                          .Select(q => new CustomBill
                                                          {
                                                              BillID = q.c.o.BillID,
                                                              Code = q.c.o.Code,
                                                              Quantity = q.c.od.Quantity,
                                                              Price = q.c.od.Price,
                                                              IGV = q.c.o.IGV,
                                                              Subtotal = (q.c.od.Quantity * q.c.od.Price),
                                                              SalesTax = q.c.o.IGV / 100 * q.c.od.Quantity * q.c.od.Price,
                                                              Total = (q.c.od.Quantity * q.c.od.Price) + (q.c.o.IGV / 100 * q.c.od.Quantity * q.c.od.Price),
                                                          }).ToList();
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

        //Filtro por N_Factura
        public EResponseBase<CustomBill> GetByBillID(string filter)
        {
            EResponseBase<CustomBill> response = new EResponseBase<CustomBill>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Bills.Join(context.BillDetails, o => o.BillID, od => od.BillID,
                                                          (o, od) => new
                                                          {
                                                              o,
                                                              od
                                                          }).Where(x => x.o.Code.Equals(filter))
                                                          .Select(q => new CustomBill
                                                          {
                                                              BillID = q.o.BillID,
                                                              Code = q.o.Code,
                                                              Quantity = q.od.Quantity,
                                                              Price = q.od.Price,
                                                              IGV = q.o.IGV,
                                                              Subtotal = (q.od.Quantity * q.od.Price),
                                                              SalesTax = q.o.IGV / 100 * q.od.Quantity * q.od.Price,
                                                              Total = (q.od.Quantity * q.od.Price) + (q.o.IGV / 100 * q.od.Quantity * q.od.Price),
                                                          }).ToList();
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



        //Filtro por Cliente
        public EResponseBase<CustomBill> GetByCustomer(String filter)
        {
            EResponseBase<CustomBill> response = new EResponseBase<CustomBill>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Bills.Join(context.BillDetails, o => o.BillID, od => od.BillID,
                                                          (o, od) => new
                                                          {
                                                              o, od
                                                          }).Join(context.Customers, c => c.o.CustomerID, cu => cu.CustomerID,
                                                          (c, cu) => new
                                                          {
                                                              c, cu
                                                          }).Where(x => x.cu.Name.Equals(filter))
                                                          .Select(q => new CustomBill {
                                                              BillID = q.c.o.BillID,
                                                              Code = q.c.o.Code,
                                                              Quantity = q.c.od.Quantity,
                                                              Price = q.c.od.Price,
                                                              IGV = q.c.o.IGV,
                                                              Subtotal = (q.c.od.Quantity * q.c.od.Price),
                                                              SalesTax = q.c.o.IGV / 100 * q.c.od.Quantity * q.c.od.Price,
                                                              Total = (q.c.od.Quantity * q.c.od.Price) + (q.c.o.IGV / 100 * q.c.od.Quantity * q.c.od.Price),
                                                          }).ToList();                         
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

        public EResponseBase<Bill> GetById(int ID)
        {
            EResponseBase<Bill> response = new EResponseBase<Bill>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Bills.Find(ID);
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
        public EResponseBase<DataBill> Add(DataBill dataBill)
        {
            EResponseBase<DataBill> response = new EResponseBase<DataBill>();
            try
            {
                dataBill.Customer.State = true;
                dataBill.Customer.CreatedAt = DateTime.Now;
                dataBill.Bill.CreatedAt = DateTime.Now;
                dataBill.Bill.State = true;
                dataBill.Bill.BillDetails = dataBill.BillDetails;
                dataBill.Bill.Customer = dataBill.Customer;
                using (var context = new DataContext())
                {
                    context.Bills.Add(dataBill.Bill);
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

        public EResponseBase<Bill> Update(Bill order)
        {
            EResponseBase<Bill> response = new EResponseBase<Bill>();
            try
            {
                using (var context = new DataContext())
                {
                    var newBill = context.Bills.Find(order.BillID);
                    newBill.State = false;
                    newBill.Comments = order.Comments;
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

        //public EResponseBase<Bill> Delete(int ID)
        //{
        //    EResponseBase<Bill> response = new EResponseBase<Bill>();
        //    try
        //    {
        //        using (var context = new DataContext())
        //        {
        //            var order = context.Bills.Find(ID);
        //            order.State = false;
        //            context.SaveChanges();
        //        }
        //        response.Status = true;
        //        response.Message = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //        response.Status = false;
        //    }
        //    return response;
        //}

        EResponseBase<Bill> IServiceBase<Bill>.Get()
        {
            throw new NotImplementedException();
        }

        public EResponseBase<Bill> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public EResponseBase<Bill> Add(Bill model)
        {
            throw new NotImplementedException();
        }
    }
}
