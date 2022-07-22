using API.CommonDAL;
using API.Interfaces;
using Microsoft.OpenApi.Any;
using System.Data.SqlClient;

namespace API.AdoDotnetDAL
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        public TemplateADO(string connectionString) : base(connectionString)
        {

        }

        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = objConn.CreateCommand();
            objCommand.Connection = objConn;
        }

        protected abstract void ExecuteCommand(AnyType obj);

        private void Close()
        {
            objConn.Close();
        }

        public void Execute(AnyType obj)
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        public override void Save()
        {
            foreach (var item in AnyTypes)
            {
                Execute(item);
            }
        }

    }

    public class CustomerDAL : TemplateADO<ICustomer>
    {
        public CustomerDAL(string connectionString) : base(connectionString)
        {

        }

        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "INSERT INTO User(" +
                "CustomerName," +
                "BillAmount," +
                "BillDate," +
                "PhoneNumber," +
                "CustType," +
                "Address) " +
                $"VALUES('{obj.CustomerName}', '{obj.BillAmount}', '{obj.BillDate}', '{obj.PhoneNumber}', '{obj.CustType}', '{obj.Address}')";
        }
    }
}
