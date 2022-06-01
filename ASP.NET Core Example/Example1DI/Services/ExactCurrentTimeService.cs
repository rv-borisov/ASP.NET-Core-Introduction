using System;

namespace ASP.NET_Core_Example.Example1DI.Services
{
    public class ExactCurrentTimeService
    {
        private readonly DateTime dateTime;

        public ExactCurrentTimeService()
        {
            dateTime = DateTime.Now;
        }

        public string GetExactCurrentTime()
        {
            return dateTime.ToString("T");
        }
    }
}
