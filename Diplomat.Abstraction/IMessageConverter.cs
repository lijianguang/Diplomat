namespace Diplomat
{
    public interface IMessageConverter
    {
        T Convert<T>(string message);
    }
}
