using MiddleLayer;
using MiddleLayer.Enum;

namespace API
{
    //Design pattern: Simple factory Pattern 
    public static class Factory
    {
        private static readonly Lazy<Dictionary<CustomerType, CustomerBase>> _users;
        private static int _count;

        static Factory()
        {
            _count = 0;
            _users = new Lazy<Dictionary<CustomerType, CustomerBase>>();
            _users.Value.Add(CustomerType.Customer, new Customer());
            _users.Value.Add(CustomerType.Lead, new Lead());
        }
        public static CustomerBase Create(CustomerType type)
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


            //Design pattern: RIP (Replace IF by polymorphism)
            var user = _users.Value[type];
            user.Id = _count;
            _count++;
            return user;
        }
    }
}
