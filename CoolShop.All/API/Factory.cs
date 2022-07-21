using API.Enum;
using API.Interfaces;
using API.MiddleLayer;
using API.ValidationAlgorithms;
using Microsoft.Practices.Unity;

namespace API
{
    //Design pattern: Simple factory Pattern 
    public static class Factory
    {
        private static IUnityContainer _users = null;
        private static int _count;

        static Factory()
        {
            _count = 1;
        }
        public static ICustomer Create(CustomerType type)
        {
            //Design pattern: Lazy loading (load only when you have use of it)
            //Point 1: lazy loading from scratch
            //if (_users.Count == 0)
            //{
            //    _users.Add(CustomerType.Customer, new Customer());
            //    _users.Add(CustomerType.Lead, new Lead());
            //}

            //Point 2: lazy loading with c# Lazy feature
            //Lazy<Dictionary<CustomerType, CustomerBase>> _users =
            //              new Lazy<Dictionary<CustomerType, CustomerBase>>();

            //Point 3: using some framework like unity- recommended
            if (_users == null)
            {
                _users = new UnityContainer();

                _users.RegisterType<ICustomer, Customer>
                    (CustomerType.Customer.ToString(), new InjectionConstructor(new CustomerValidationAll()));

                _users.RegisterType<ICustomer, Lead>
                    (CustomerType.Lead.ToString(), new InjectionConstructor(new LeadValidation()));
            }

            //Design pattern: RIP (Replace IF by polymorphism)
            var user = _users.Resolve<ICustomer>(type.ToString());
            user.Id = _count;
            _count++;
            return user;
        }
    }
}
