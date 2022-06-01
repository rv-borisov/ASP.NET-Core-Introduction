namespace ASP.NET_Core_Example.Example1DI.Abstractions
{
    public interface ISender
    {
        void Send(string message, string recipient);
    }
}
