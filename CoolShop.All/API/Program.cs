using API;
using API.Interfaces;
using API.MiddleLayer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<CustomerDB>(opt => opt.UseInMemoryDatabase("CustomerList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region minimal APIs
//Get API: Home method
app.MapGet("/", () => "Hello World!");

//GET API: to get all customers
//app.MapGet("/GetAllCustomers", async (CustomerDB db) =>
//{
//    return await db.User.ToListAsync();
//});

//Post method
app.MapPost("/AddCustomer", async (CustomerBase customer) =>
{
    var user = Factory<ICustomer>.Create(customer.CustType.ToString());
    user.Address = customer.Address;
    user.PhoneNumber = customer.PhoneNumber;
    user.CustomerName = customer.CustomerName;
    user.BillDate = customer.BillDate;
    user.BillAmount = customer.BillAmount;
    user.CustType = customer.CustType;
    user.Validate();

    return user;
})
.WithName("AddCustomer")
.WithOpenApi();

#endregion

app.Run();

