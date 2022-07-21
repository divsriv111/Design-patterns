namespace API.Interfaces
{
    public interface IValidation<AnyType>
    {
        void Validate(AnyType user);
    }
}
