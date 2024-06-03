namespace Diplomat
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ModelMappingAttribute : Attribute
    {
        private Source _source;

        public ModelMappingAttribute(Source source)
        {
            if (source == Source.Unknown) throw new ArgumentException("source must not be unknown.");

            _source = source;
        }

        public Source Source { get { return _source; } }
    }
}
