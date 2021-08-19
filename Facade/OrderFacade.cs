using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class OrderFacade:FacadeBase
    {
        public IList<OrderDto> GetOrder()
        {
            var data = (from o in EntityModel.Orders
                        join p in EntityModel.Products on o.ProductId equals p.Id
                        join c in EntityModel.Customer on o.CustomerId equals c.Id
                        join pt in EntityModel.Payments on o.PaymentId equals pt.Id
                        select new OrderDto()
                        {
                            Id=o.Id,
                            CustomerName=c.Name + c.Surname,
                            ProductName=p.ProductName,
                            PaymentType=pt.PaymentType,
                            OrderPrice=o.Price,

                        }).ToList();

            return data;
        }

        public OrderDto GetOrderById(int orderid)
        {
            var data = (from o in EntityModel.Orders
                        join p in EntityModel.Products on o.ProductId equals p.Id
                        join c in EntityModel.Customer on o.CustomerId equals c.Id
                        join pt in EntityModel.Payments on o.PaymentId equals pt.Id
                        where o.Id==orderid
                        select new OrderDto()
                        {
                            Id = o.Id,
                            CustomerName = c.Name + c.Surname,
                            ProductName = p.ProductName,
                            PaymentType = pt.PaymentType,
                            OrderPrice = o.Price,

                        }).FirstOrDefault();

            return data;
        }

        public KeyValuePair<bool, string> CreateOrder(OrderDto order)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var orderCreate = new Orders
                {
                    Id = order.Id,
                    Price = order.OrderPrice,
                    CustomerId=order.CustomerId,
                    PaymentId=order.PaymentId,
                    ProductId=order.ProductId,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                EntityModel.Orders.Add(orderCreate);
                EntityModel.SaveChanges();
            }
            catch(Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }

        public KeyValuePair<bool, string> DeleteOrder(int id)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");

            try
            {
                var order = EntityModel.Orders.FirstOrDefault(x => x.Id == id);
                if (order==null)
                    result = new KeyValuePair<bool, string>(false, "İlgili Kayıt Bulunamadı");
                else
                {
                    var orderDto = EntityModel.Orders.Remove(order);
                    EntityModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }



    }
}
