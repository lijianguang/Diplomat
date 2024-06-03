namespace Diplomat
{
    public interface IWorkshopFactory
    {
        IWorkshop Create(Source source);
    }
}
