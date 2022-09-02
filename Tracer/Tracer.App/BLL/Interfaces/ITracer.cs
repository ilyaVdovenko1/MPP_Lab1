namespace Tracer.App.BLL.Interfaces;

public interface ITracer
{
    
        void StartTrace();
    
        // вызывается в конце замеряемого метода
        void StopTrace();
    
        // получить результаты измерений
        TraceResult GetTraceResult();
}