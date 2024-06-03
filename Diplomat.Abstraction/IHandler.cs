namespace Diplomat
{
    public interface IHandler
    {
        void Handle(Source source, string message);
    }
}
