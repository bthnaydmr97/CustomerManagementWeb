using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class CustomerFacade : FacadeBase
    {
        public IList<CustomerDto> GetCustomer()
        {
            var data = (from c in EntityModel.Customer
                       select new CustomerDto()
                       { 
                           Id=c.Id,
                           Name = c.Name,
                           Surname = c.Surname,
                           Phone = c.Phone,
                           Address = c.Address,
                           Email = c.Email,
                           City = c.City

                       }).ToList();
            return data;
        }

        public CustomerDto GetCustomerById(int customerid)
        {
            var data = (from c in EntityModel.Customer
                        where c.Id == customerid
                        select new CustomerDto()
                        {
                            Id=c.Id,
                            Name = c.Name,
                            Surname = c.Surname,
                            Phone = c.Phone,
                            Address = c.Address,
                            Email = c.Email,
                            City = c.City
                        }).FirstOrDefault();

            return data;
        }

        public Customer CreateCustomer(CustomerDto cstmr)
        {
                var customer = new Customer
                {
                    Id=cstmr.Id,
                    Name = cstmr.Name,
                    Surname = cstmr.Surname,
                    Phone = cstmr.Phone,
                    Address = cstmr.Address,
                    Email = cstmr.Email,
                    City = cstmr.City,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                EntityModel.Customer.Add(customer);
                EntityModel.SaveChanges();
               
            return customer;
        }

        public KeyValuePair<bool,string> UpdateCustomer(CustomerDto customerDto)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var modifiedEntity = EntityModel.Customer.FirstOrDefault(x => x.Id == customerDto.Id);
                ConvertCustomerDtoToModelUpdate(customerDto, modifiedEntity);
                EntityModel.SaveChanges();
            }
            catch (System.Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }

        public Customer ConvertCustomerDtoToModelUpdate(CustomerDto customerDto,Customer customer)
        {
            customer.Id = customerDto.Id;
            customer.Name = customerDto.Name;
            customer.Surname = customerDto.Surname;
            customer.Phone = customerDto.Phone;
            customer.Address = customerDto.Address;
            customer.Email = customerDto.Email;
            customer.City = customerDto.City;
            customer.ModifiedOn = DateTime.Now;

            return customer;
        }
        public KeyValuePair<bool,string> DeleteCustomer(int id)
        {
            var result = new KeyValuePair<bool, string>(true, "Başarılı");
            try
            {
                var customer = EntityModel.Customer.FirstOrDefault(x => x.Id == id);
                if (customer == null)
                    result = new KeyValuePair<bool, string>(false, "İlgili Kayıt Bulunamadı");
                else
                {
                    var customerDto = EntityModel.Customer.Remove(customer);
                    EntityModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }
            return result;
        }


        public CustomerDto GetOrderHistoryById(int id)
        {
            var data = (from c in EntityModel.Customer
                        join o in EntityModel.Orders on c.Id equals o.CustomerId
                        join p in EntityModel.Products on o.ProductId equals p.Id
                        where c.Id == id
                        select new CustomerDto()
                        {
                            Id=c.Id,
                            Name=c.Name,
                            Surname=c.Surname,
                            OrderPrice=o.Price,
                            ProductName=p.ProductName,
                            
                        }).FirstOrDefault();

            return data;
        }

    }
}
