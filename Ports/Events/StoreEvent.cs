using System;

namespace Ports.Events
{
    public class StoreEvent<T> where T : class
    {
        public StoreEvent(T body)
        {
            TimeGenerated = DateTime.UtcNow;
            Body = body;
        }
        public string Type => typeof(T).Name;
        public DateTime TimeGenerated { get; set; }
        public T Body { get; set; }
    }
}
