namespace Diplomat
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class WorkerMappingAttribute : Attribute
    {
        private Market _market;
        private Source _source;

        public WorkerMappingAttribute(Source source, Market market)
        {
            if (market == Market.Unknown) throw new ArgumentException("market must not be unknown.");
            if (source == Source.Unknown) throw new ArgumentException("source must not be unknown.");

            _market = market;
            _source = source;
        }

        public Market Market { get { return _market; } }
        public Source Source { get { return _source; } }
    }
}
