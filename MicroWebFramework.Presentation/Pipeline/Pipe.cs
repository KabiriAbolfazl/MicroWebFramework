namespace MicroWebFramework.Presentation.Pipeline;
public abstract class Pipe
{
    public Pipe()
    {
        Next = null;
    }
    public Pipe(Action<PipelineContext> next)
    {
        Next = next;
    }
    public Action<PipelineContext> Next { get; set; }
    public virtual void Invoke(PipelineContext context) { }
}

