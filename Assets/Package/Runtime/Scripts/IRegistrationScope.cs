namespace TahaCore.ServiceLocator
{
    public interface IRegistrationScope
    {
        T Get<T>();
    }
}