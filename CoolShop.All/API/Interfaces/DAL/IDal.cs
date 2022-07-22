namespace API.Interfaces.DAL
{
    //Design pattern: Generic Repository pattern
    public interface IDal<AnyType>
    {
        void Add(AnyType obj);  //Inmemory addition
        void Update(AnyType obj); //Inmemory update
        List<AnyType> Search();
        void Save(); //Physical commit
    }
}
