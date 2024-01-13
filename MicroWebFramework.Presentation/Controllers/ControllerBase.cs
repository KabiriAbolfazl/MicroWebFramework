using MicroWebFramework.Presentation.Common;
using MicroWebFramework.Presentation.Models;
using System.Net;

namespace MicroWebFramework.Presentation.Controllers;
public abstract class ControllerBase
{
    public HttpListenerContext HttpContext { get; }
    protected ControllerBase(HttpListenerContext httpContext)
    {
        HttpContext = httpContext;
    }
    public void Ok(object value)
    {
        HttpContext.Response.ContentType = "application/json";
        HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        var buffer = HttpContext.Response.GetBytes(new Result<object>()
        {
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Success",
            Data = value
        });
        HttpContext.Response.OutputStream.Write(buffer, 0, buffer.Length);
        HttpContext.Response.Close();
    }
}
