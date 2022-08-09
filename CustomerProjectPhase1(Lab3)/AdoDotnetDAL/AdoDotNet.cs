using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDAL;
using InterfaceDal;
using System.Data;
using System.Data.SqlClient;
using InterfaceCustomer;
using FactoryCustomer;
namespace AdoDotnetDAL
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
        public TemplateADO(string _ConnectionString) 
            : base(_ConnectionString)
        {


        }
        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        protected abstract void ExecuteCommand(AnyType obj); // Child classes 
        protected abstract List<AnyType> ExecuteCommand(); // Child classes 
        private void Close()
        {
            objConn.Close();
        }
        // Design pattern :- Template pattern
        public void Execute(AnyType obj) // Fixed Sequence Insert
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }
        public List<AnyType> Execute() // Fixed Sequence select
        {
            List<AnyType> objTypes = null;
            Open();
            objTypes =  ExecuteCommand();
            Close();
            return objTypes;
        }
        public override void Save()
        {
            foreach (AnyType o in AnyTypes)
            {
                Execute(o);
            }
        }
        public override List<AnyType> Search()
        {
            return Execute();
        }
    }
    public class CustomerDAL : TemplateADO<ICustomer> , IDal<ICustomer>
    {
        public CustomerDAL(string _ConnectionString) 
            : base(_ConnectionString)
        {

        }
        protected override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<ICustomer> custs = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer icust = Factory<ICustomer>.Create("Customer");
                icust.CustomerName = dr["CustomerName"].ToString();
                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                icust.PhoneNumber = dr["PhoneNumber"].ToString();
                icust.Address = dr["Address"].ToString();
                custs.Add(icust);
            }
            return custs;
        }
        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "insert into tblCustomer(" +
                                            "CustomerName," + 
                                            "BillAmount,BillDate,"+ 
                                            "PhoneNumber,Address)" +
                                            "values('" + obj.CustomerName + "'," +
                                            obj.BillAmount + ",'" +
                                            obj.BillDate + "','" +
                                            obj.PhoneNumber + "','" +
                                            obj.Address +"')";
            objCommand.ExecuteNonQuery();
        }
    }

}
