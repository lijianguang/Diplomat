namespace Diplomat
{
    public class WorkerDescriptor
    {
        public Market Market { get; set; }
        public required Type OperateModelType { get; set; }
        public required Type Type { get; set; }
    }
}
