using System.Xml.Serialization;

namespace Diplomat.Core
{
    public class MessageConverter : IMessageConverter
    {
        public T Convert<T>(string message)
        {
            var index = message.IndexOf("<?xml");
            var messageFormat = index < 0 ? message : message.Substring(index);
            using (StringReader stream = new StringReader(messageFormat))
            {
                return (T)(new XmlSerializer(typeof(T)).Deserialize(stream) 
                    ?? throw new Exception($"Can't convert current message a instance of {typeof(T).FullName}"));
            }
        }
    }
}
