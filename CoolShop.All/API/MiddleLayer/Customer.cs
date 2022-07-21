using API.Enum;
using API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace API.MiddleLayer
{
    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> _validation = null;

        public CustomerBase(IValidation<ICustomer> validation)
        {
            _validation = validation;
        }

        public CustomerBase()
        {

        }

        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string? Address { get; set; }
        public CustomerType CustType { get; set; }
        //Design pattern: Strategy pattern - select algorithm on runtime/dynamically
        public virtual void Validate()
        {
            _validation.Validate(this);
        }
    }

    public class Customer : CustomerBase
    {
        public Customer(IValidation<ICustomer> validation) : base(validation)
        {
        }
    }

    public class Lead : CustomerBase
    {
        public Lead(IValidation<ICustomer> validation) : base(validation)
        {

        }
    }
}