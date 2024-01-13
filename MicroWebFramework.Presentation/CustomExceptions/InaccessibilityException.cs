namespace MicroWebFramework.Presentation.CustomExceptions;
public class InaccessibilityException : Exception
{
    public InaccessibilityException(string country) : base(country)
    {
    }
}
