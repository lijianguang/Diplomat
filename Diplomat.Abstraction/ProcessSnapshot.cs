namespace Diplomat
{
    public class ProcessSnapshot
    {
        public ProcessSnapshot(IProcess process, object data, Exception? exception)
        {
            Process = process;
            Data = data;
            Exception = exception;
        }
        public IProcess Process { get; set; }

        public object Data { get; set; }

        public Exception? Exception { get; set; }
    }
}
