using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class PaymentFacade : FacadeBase
    {
        public IList<PaymentDto> GetPayment()
        {
            var data = (from p in EntityModel.Payments
                        select new PaymentDto()
                        {
                            Id = p.Id,
                            PaymentType = p.PaymentType,

                        }).ToList();

            return data;
        }

        public PaymentDto GetPaymentById(int paymentid)
        {
            var data = (from p in EntityModel.Payments
                        where p.Id==paymentid
                        select new PaymentDto()
                        {
                            Id = p.Id,
                            PaymentType = p.PaymentType,

                        }).FirstOrDefault();

            return data;
        }

      

    }
}
