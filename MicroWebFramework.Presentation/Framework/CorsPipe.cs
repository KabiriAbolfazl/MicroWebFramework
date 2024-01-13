using Dumpify;
using MicroWebFramework.Presentation.Pipeline;

namespace MicroWebFramework.Presentation.Framework;
public class CorsPipe : Pipe
{
    public CorsPipe(Action<PipelineContext> next) : base(next)
    {
    }
    public override void Invoke(PipelineContext context)
    {
        "Starting cors".Dump();
        Next(context);
        "End cors".Dump();
    }
}
