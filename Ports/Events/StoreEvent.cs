using System;

namespace Ports.Events
{
    public class StoreEvent<T> where T : class
    {
        public StoreEvent(T body, string type)
        {
            this.Type = type;
            TimeGenerated = DateTime.UtcNow;
            Body = body;
        }
        public string Type { get; }
        public DateTime TimeGenerated { get; }
        public T Body { get; }
    }
}
