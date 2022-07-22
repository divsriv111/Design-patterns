using API.Interfaces.DAL;

namespace API.CommonDAL
{
    public abstract class AbstractDal<AnyType> : IDal<AnyType>
    {
        protected string ConnectionString = "";
        protected List<AnyType> AnyTypes = new List<AnyType>();

        protected AbstractDal(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }
}
