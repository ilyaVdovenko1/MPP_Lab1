namespace Tracer.Core.Domain;

public class ThreadTrace
{
    private readonly Stack<MethodTrace> _stackOfMethods;

    private readonly List<MethodTrace> _allMethods;

    public ThreadTrace()
    {
        _stackOfMethods = new Stack<MethodTrace>();
        _allMethods = new List<MethodTrace>();
    }

    public long ElapsedTime => _allMethods.Select(item => item.Elapsed.Milliseconds).Sum();

    public void StartTrackMethod(MethodTrace methodTrace)
    {
        if (_stackOfMethods.Count == 0)
        {
            _allMethods.Add(methodTrace);
        }
        else
        {
            _stackOfMethods.Peek().AddNestedMethod(methodTrace);
        }
        _stackOfMethods.Push(methodTrace);
    }

    public void StopTrackMethod()
    {
        _stackOfMethods.Pop().StopTrackTime();
    }

}