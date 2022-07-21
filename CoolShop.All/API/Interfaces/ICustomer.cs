using API.Enum;

namespace API.Interfaces
{
    public interface ICustomer
    {
        int Id { get; set; }
        string? CustomerName { get; set; }
        string? PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string? Address { get; set; }
        CustomerType CustType { get; set; }

        void Validate();
    }
}
