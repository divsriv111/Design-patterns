using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceCustomer
{
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        void Validate();
    }
    // Design pattern :- Stratergy pattern helps to choose 
    // algorithms dynamically
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }
}
