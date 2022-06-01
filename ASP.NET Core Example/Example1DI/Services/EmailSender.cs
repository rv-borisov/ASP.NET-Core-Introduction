using ASP.NET_Core_Example.Example1DI.Abstractions;

namespace ASP.NET_Core_Example.Example1DI.Services
{
    public class EmailSender : ISender
    {
        public void Send(string message, string recipient)
        {
            // send
        }
    }
}
