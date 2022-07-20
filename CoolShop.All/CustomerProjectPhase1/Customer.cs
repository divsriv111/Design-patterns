using MiddleLayer.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleLayer
{
    public class CustomerBase
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string? Address { get; set; }
        public virtual CustomerType CustType { get; set; }
        public virtual void Validate()
        {
            throw new Exception("Not implemented");
        }
    }

    public class Customer : CustomerBase
    {
        override public CustomerType CustType { get; set; } = CustomerType.Customer;
        public override void Validate()
        {
            if (string.IsNullOrEmpty(CustomerName))
            {
                throw new Exception("Customer name is required");
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                throw new Exception("Phone number is required");
            }
            if (BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            if (BillDate >= DateTime.Now)
            {
                throw new Exception("Bill Date is not proper");
            }
            if (string.IsNullOrEmpty(Address))
            {
                throw new Exception("Address is required");
            }
        }
    }

    public class Lead : CustomerBase
    {
        override public CustomerType CustType { get; set; } = CustomerType.Lead;
        public override void Validate()
        {
            if (string.IsNullOrEmpty(CustomerName))
            {
                throw new Exception("Customer name is required");
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                throw new Exception("Phone number is required");
            }
        }
    }
}