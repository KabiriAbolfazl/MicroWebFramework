using MicroWebFramework.Presentation.CustomExceptions;
using System.Text.RegularExpressions;

namespace MicroWebFramework.Presentation.Common;
public static class Url
{
    public static (string Controller, string Action, string Parameter) GetUrlPath(string url)
    {
        if (url is null) throw new InvalidRequestException(url);
        var sections = Regex.Split(url, @"(?<=[^/])/(?=[^/])", RegexOptions.None);
        string controller = sections.Length > 1 ? sections[1] : null;
        string action = sections.Length > 2 ? sections[2] : null;
        string parameter = sections.Length > 3 ? sections[3] : null;
        return (controller, action, parameter);
    }
}
