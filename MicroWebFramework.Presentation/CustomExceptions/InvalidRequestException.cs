namespace MicroWebFramework.Presentation.CustomExceptions;
public class InvalidRequestException : Exception
{
    public InvalidRequestException(string ipAddress) : base(ipAddress)
    {
    }
}
