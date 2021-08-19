using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WcfService
{
    public class ServiceBase
    {
        private AdminFacade _adminFacade;

        public AdminFacade AdminFacade
        {
            get
            {
                if (_adminFacade==null)
                   _adminFacade = new AdminFacade();
                return _adminFacade;
            }
        }

        private CustomerFacade _customerFacade;

        public CustomerFacade CustomerFacade
        {
            get
            {
                if (_customerFacade==null)
                    _customerFacade = new CustomerFacade();
                return _customerFacade;
            }
        }

        private ProductFacade _productFacade;

        public ProductFacade ProductFacade
        {
            get
            {
                if (_productFacade == null)
                    _productFacade = new ProductFacade();
                return _productFacade;
            }
        }

        private CategoryFacade _categoryFacade;

        public CategoryFacade CategoryFacade
        {
            get
            {
                if (_categoryFacade == null)
                    _categoryFacade = new CategoryFacade();
                return _categoryFacade;
            }
        }

        private OrderFacade _orderFacade;
        public OrderFacade OrderFacade
        {
            get
            {
                if (_orderFacade == null)
                    _orderFacade = new OrderFacade();
                return _orderFacade;
            }
        }

        private PaymentFacade _paymentFacade;

        public PaymentFacade PaymentFacade
        {
            get
            {
                if (_paymentFacade == null)
                    _paymentFacade = new PaymentFacade();
                return _paymentFacade;
            }
        }

      
    }
}