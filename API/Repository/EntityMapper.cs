using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<ProductModel, Product>();
            Mapper.CreateMap<Product, ProductModel>();

            Mapper.CreateMap<SalesManModel, SalesMan>();
            Mapper.CreateMap<SalesMan, SalesManModel>();

            Mapper.CreateMap<CustomerModel, Customer>();
            Mapper.CreateMap<Customer, CustomerModel>();

            Mapper.CreateMap<BillModel, Bill>();
            Mapper.CreateMap<Bill, BillModel>();

            Mapper.CreateMap<BillDetailModel, BillDetail>();
            Mapper.CreateMap<BillDetail, BillDetailModel>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}