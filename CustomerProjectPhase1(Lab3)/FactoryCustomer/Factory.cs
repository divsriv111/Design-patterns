using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using InterfaceCustomer;
using ValidationAlgorithms;
using InterfaceDal;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace FactoryCustomer
{
    public static class Factory<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;
            
        
        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();
                ObjectsofOurProjects.RegisterType<ICustomer, Customer>
                                ("Customer", 
                                new InjectionConstructor(
                                    new CustomerValidationAll()));
                ObjectsofOurProjects.RegisterType<ICustomer, Lead>
                                    ("Lead"
                                    , new InjectionConstructor(
                                        new LeadValidation()));

            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type);

        }
    }
}
