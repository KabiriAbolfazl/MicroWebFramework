namespace MicroWebFramework.Presentation.Pipeline;
public class PipelineBuilder
{
    List<Type> pipes;
    public PipelineBuilder()
    {
        pipes = new List<Type>();
    }
    public PipelineBuilder AddPipe(Type type)
    {
        pipes.Add(type);
        return this;
    }
    public PipelineBuilder AddPipe<T>()
    {
        pipes.Add(typeof(T));
        return this;
    }
    public Pipeline Build()
    {
        var endPointIndex = pipes.Count - 1;
        Pipeline pipeline = new();
        var pipeIndexer = Activator.CreateInstance(pipes[endPointIndex], null) as Pipe;
        pipeline.AddPipe(pipeIndexer);
        for (int index = endPointIndex - 1; index >= 0; index--)
        {
            pipeIndexer = Activator.CreateInstance(pipes[index], new[] { pipeIndexer.Invoke }) as Pipe;
            pipeline.AddPipe(pipeIndexer);
        }
        return pipeline;
    }
}
