using Dumpify;
using MicroWebFramework.Presentation.Pipeline;

namespace MicroWebFramework.Presentation.Framework;
public class AuthenticationPipe : Pipe
{
    public AuthenticationPipe(Action<PipelineContext> next) : base(next)
    {
    }
    public override void Invoke(PipelineContext context)
    {
        "Starting auth".Dump();
        Next(context);
        "End auth".Dump();
    }
}
