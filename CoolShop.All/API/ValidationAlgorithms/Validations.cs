using API.Interfaces;
using API.MiddleLayer;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace API.ValidationAlgorithms
{
    public class CustomerValidationAll : IValidation<ICustomer>
    {
        public void Validate(ICustomer user)
        {
            if (string.IsNullOrEmpty(user.CustomerName))
            {
                throw new Exception("Customer name is required");
            }
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                throw new Exception("Phone number is required");
            }
            if (user.BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            if (user.BillDate >= DateTime.Now)
            {
                throw new Exception("Bill Date is not proper");
            }
            if (string.IsNullOrEmpty(user.Address))
            {
                throw new Exception("Address is required");
            }
        }
    }

    public class LeadValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer user)
        {
            if (string.IsNullOrEmpty(user.CustomerName))
            {
                throw new Exception("Customer name is required");
            }
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                throw new Exception("Phone number is required");
            }
        }
    }
}
