using System.Text.Json;
using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Interfaces;

namespace Tracer.Serialization.Json;

public class JsonProcessor : ITraceResultSerializer
{
    public async Task Serialize(TraceResult traceResult, Stream to)
    {
        await JsonSerializer.SerializeAsync<TraceResult>(to,traceResult);
    }
}