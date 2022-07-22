using API.AdoDotnetDAL;
using API.Enum;
using API.Interfaces;
using API.Interfaces.DAL;
using API.MiddleLayer;
using API.ValidationAlgorithms;
using Microsoft.Practices.Unity;

namespace API
{
    //Design pattern: Simple factory Pattern 
    public static class Factory<AnyType>
    {
        private static IUnityContainer _objs = null;
        
        public static AnyType Create(string type)
        {
            //Design pattern: Lazy loading (load only when you have use of it)
            //Point 1: lazy loading from scratch
            //if (_objs.Count == 0)
            //{
            //    _objs.Add(CustomerType.Customer, new Customer());
            //    _objs.Add(CustomerType.Lead, new Lead());
            //}

            //Point 2: lazy loading with c# Lazy feature
            //Lazy<Dictionary<CustomerType, CustomerBase>> _objs =
            //              new Lazy<Dictionary<CustomerType, CustomerBase>>();

            //Point 3: using some framework like unity- recommended
            if (_objs == null)
            {
                _objs = new UnityContainer();

                _objs.RegisterType<ICustomer, Customer>
                    (CustomerType.Customer.ToString(), new InjectionConstructor(new CustomerValidationAll()));

                _objs.RegisterType<ICustomer, Lead>
                    (CustomerType.Lead.ToString(), new InjectionConstructor(new LeadValidation()));

                _objs.RegisterType<IDal<ICustomer>, CustomerDAL>("ADODal");
            }

            //Design pattern: RIP (Replace IF by polymorphism)
            var user = _objs.Resolve<AnyType>(type.ToString());
            return user;
        }
    }
}
