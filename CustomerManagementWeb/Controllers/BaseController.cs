using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace CustomerManagementWeb.Controllers
{
    public class BaseController : Controller
    {
        private LoginClient _loginClient;

        public LoginClient LoginClient
        {
            get
            {
                if (_loginClient == null)
                    _loginClient = new LoginClient();
                return _loginClient;
            }
        }

        private CustomerClient _customerClient;
         
        public CustomerClient CustomerClient
        {
            get
            {
                if (_customerClient == null)
                    _customerClient = new CustomerClient();
                return _customerClient;
            }

        }

        private ProductClient _productClient;

        public ProductClient ProductClient
        {
            get
            {
                if (_productClient == null)
                    _productClient = new ProductClient();
                return _productClient;
            }
        }

        private CategoryClient _categoryClient;

        public CategoryClient CategoryClient
        {
            get
            {
                if (_categoryClient == null)
                    _categoryClient = new CategoryClient();
                return _categoryClient;
            }
        }

        private OrderClient _orderClient;

        public OrderClient OrderClient
        {
            get
            {
                if (_orderClient == null)
                    _orderClient = new OrderClient();
                return _orderClient;
            }
        }

        private PaymentClient _paymentClient;

        public PaymentClient PaymentClient
        {
            get
            {
                if (_paymentClient == null)
                    _paymentClient = new PaymentClient();
                return _paymentClient;
            }
        }


       
        


    }
}