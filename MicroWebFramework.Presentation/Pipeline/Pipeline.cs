using MicroWebFramework.Presentation.CustomExceptions;
using System.Net;

namespace MicroWebFramework.Presentation.Pipeline;
public class Pipeline
{
    private PipelineContext _context;
    readonly List<Pipe> pipes;
    public Pipeline()
    {
        pipes = new List<Pipe>();
    }
    public void AddPipe(Pipe pipe)
    {
        pipes.Add(pipe);
    }
    public void Run(HttpListenerContext listenerContext)
    {
        if (!pipes.Any()) throw new NotImplementedPipelineException();
        _context = new PipelineContext { HttpContext = listenerContext };
        pipes[pipes.Count - 1].Invoke(_context);
    }

}
