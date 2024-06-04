namespace Diplomat
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class WorkerMappingAttribute : Attribute
    {
        private Market _market;

        public WorkerMappingAttribute(Market market)
        {
            if (market == Market.Unknown) throw new ArgumentException("market must not be unknown.");

            _market = market;
        }

        public Market Market { get { return _market; } }
    }
}
