namespace Diplomat.Core
{
    public class Handler : IHandler
    {
        private readonly IWorkshopFactory _workshopFactory;

        public Handler(IWorkshopFactory workshopFactory)
        {
            _workshopFactory = workshopFactory;
        }

        public void Handle(Source source, string message)
        {
            _workshopFactory.Create(source)
                .Process(message);
        }
    }
}
