using Dumpify;
using MicroWebFramework.Presentation.Common;
using MicroWebFramework.Presentation.Contracts;
using MicroWebFramework.Presentation.Framework;
using MicroWebFramework.Presentation.Implementations;
using MicroWebFramework.Presentation.Pipeline;
using System.Diagnostics;
using System.Net;
using System.Text;

//setup our DI
IocContainer.AddScoped(typeof(INotification), typeof(SmsService));
IocContainer.AddServiceProvider();

HttpListener listener = new HttpListener();
var prefix = "http://localhost:8000/";
listener.Prefixes.Add(prefix);
$"Now listening on {prefix}".Dump();
listener.Start();

//open browser
ProcessStartInfo processStart = new ProcessStartInfo
{
    FileName = prefix,
    UseShellExecute = true
};
Process.Start(processStart);


while (true)
{
    var httpContext = listener.GetContext();

    if (Url.GetUrlPath(httpContext.Request.Url.AbsoluteUri).Action is null)
    {
        var message = "Welcome dear friend";
        var buffer = Encoding.UTF8.GetBytes(message);
        httpContext.Response.OutputStream.Write(buffer, 0, buffer.Length);
        httpContext.Response.Close();
    }
    else
    {
        var app = new PipelineBuilder()
            .AddPipe<CorsPipe>()
            .AddPipe<ExceptionHandlingPipe>()
            .AddPipe<RoutePipe>()
            .AddPipe<AuthenticationPipe>()
            .AddPipe<EndPointPipe>()
            .Build();
        app.Run(httpContext);
    }
}


