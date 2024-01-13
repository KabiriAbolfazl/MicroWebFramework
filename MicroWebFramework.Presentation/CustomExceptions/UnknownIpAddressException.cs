namespace MicroWebFramework.Presentation.CustomExceptions;
public class UnknownIpAddressException : Exception
{
    public UnknownIpAddressException(string ipAddress) : base(ipAddress)
    {
    }
}
