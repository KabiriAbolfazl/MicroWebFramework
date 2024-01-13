using Dumpify;
using MicroWebFramework.Presentation.Pipeline;

namespace MicroWebFramework.Presentation.Framework;
public class RoutePipe : Pipe
{
    public RoutePipe(Action<PipelineContext> next) : base(next)
    {
    }
    public override void Invoke(PipelineContext context)
    {
        "Starting route".Dump();
        Next(context);
        "End route".Dump();
    }
}
