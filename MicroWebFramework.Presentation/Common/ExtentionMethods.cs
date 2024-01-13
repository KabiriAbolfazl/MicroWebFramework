using Microsoft.Extensions.DependencyInjection;
using MicroWebFramework.Presentation.Models;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MicroWebFramework.Presentation.Common;
public static class ExtentionMethods
{
    public static bool IsInstancable(this Type type)
    {
        if (
            (bool)(type is null |
            !type?.IsClass |
            type?.IsAbstract)
           ) return false;
        return true;
    }
    public static byte[] GetBytes(this HttpListenerResponse response, Result<object> value)
    {
        var jsonObject = JsonSerializer.Serialize(value);
        return Encoding.UTF8.GetBytes(jsonObject);
    }
}
