using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace MiddleLayer
{
    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> validation = null;
        public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public CustomerBase()
        {
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }
        public virtual void  Validate()
        {
            validation.Validate(this);
        }
    }
    public class Customer : CustomerBase
    {
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {

        }
        
    }
    public class Lead : CustomerBase
    {
        public Lead(IValidation<ICustomer> obj): base(obj)
        {

        }
    }
}
