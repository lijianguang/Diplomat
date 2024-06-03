namespace Diplomat
{
    public class WorkerDescriptor
    {
        public Source Source { get; set; }
        public Market Market { get; set; }
        public required Type Type { get; set; }
    }
}
