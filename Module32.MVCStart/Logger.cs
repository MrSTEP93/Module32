using System;

namespace Module32.MVCStart
{
    public class Logger
    {
        public void WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);
        }

        public void WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
