using Dto;
using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ServiceBase, ILogin, IProduct, ICategory, ICustomer, IOrder, IPayment
    {
        public bool CheckLogin(string pass, string username)
        {
            var result = AdminFacade.CheckLogin(pass, username);
            return result;
        }

        public Category CreateCategory(CategoryDto ct)
        {
            var result = CategoryFacade.CreateCategory(ct);
            return result;
        }

        public KeyValuePair<bool, string> CreateProduct(ProductDto prodct)
        {
            var result = ProductFacade.CreateProduct(prodct);
            return result;
        }

        public Customer CreateCustomer(CustomerDto cstmr)
        {
            var result = CustomerFacade.CreateCustomer(cstmr);
            return result;
        }

        public KeyValuePair<bool, string> DeleteCategory(int id)
        {
            var result = CategoryFacade.DeleteCategory(id);
            return result;
        }

        public KeyValuePair<bool, string> DeleteCustomer(int id)
        {
            var result = CustomerFacade.DeleteCustomer(id);
            return result;
        }

        public KeyValuePair<bool, string> DeleteProduct(int id)
        {
            var result = ProductFacade.DeleteProduct(id);
            return result;
        }

        public CategoryDto GetCategoryById(int categoryid)
        {
            var result = CategoryFacade.GetCategoryById(categoryid);
            return result;
        }

        public IList<CategoryDto> GetCategroy()
        {
            var result = CategoryFacade.GetCategroy();
            return result;
        }

        public IList<CustomerDto> GetCustomer()
        {
            var result = CustomerFacade.GetCustomer();
            return result;
        }

        public CustomerDto GetCustomerById(int customerid)
        {
            var result = CustomerFacade.GetCustomerById(customerid);
            return result;
        }

        public IList<ProductDto> GetProduct()
        {
            var result = ProductFacade.GetProduct();
            return result;
        }

        public ProductDto GetProductById(int productid)
        {
            var result = ProductFacade.GetProductById(productid);
            return result;
        }


        public KeyValuePair<bool, string> UpdateCategory(CategoryDto categoryDto)
        {
            var result = CategoryFacade.UpdateCategory(categoryDto);
            return result;
        }

        public KeyValuePair<bool, string> UpdateCustomer(CustomerDto customerDto)
        {
            var result = CustomerFacade.UpdateCustomer(customerDto);
            return result;
        }

        public KeyValuePair<bool, string> UpdateProduct(ProductDto productDto)
        {
            var result = ProductFacade.UpdateProduct(productDto);
            return result;
        }

        public IList<OrderDto> GetOrder()
        {
            var result = OrderFacade.GetOrder();
            return result;
        }

        public OrderDto GetOrderById(int orderid)
        {
            var result = OrderFacade.GetOrderById(orderid);
            return result;
        }

        public KeyValuePair<bool, string> CreateOrder(OrderDto order)
        {
            var result = OrderFacade.CreateOrder(order);
            return result;
        }

        public KeyValuePair<bool, string> DeleteOrder(int id)
        {
            var result = OrderFacade.DeleteOrder(id);
            return result;
        }

        public IList<PaymentDto> GetPayment()
        {
            var result = PaymentFacade.GetPayment();
            return result;
        }

        public PaymentDto GetPaymentById(int paymentid)
        {
            var result = PaymentFacade.GetPaymentById(paymentid);
            return result;
        }

        public CustomerDto GetOrderHistoryById(int id)
        {
            var result = CustomerFacade.GetOrderHistoryById(id);
            return result;
        }
    }
}