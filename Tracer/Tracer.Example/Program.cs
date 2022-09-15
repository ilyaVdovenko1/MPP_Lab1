using Tracer.Example.Dll;
using Tracer.Example.Domain;

// init
var tracer = new Tracer.Core.Domain.Services.Tracer();
var testClassOne = new TestClassOne(tracer);
var testClassTwo = new TestClassTwo(tracer);

//act
Inner();
void Inner()
{
    tracer.StartTrace();
    testClassOne.TestMethodOne();
    testClassOne.TestMethodTwo();
    tracer.StopTrace();
    
}
const string testDirPath = @"../../../TestResults";
var traceResult = tracer.GetTraceResult();

const string jsonFileName = "result.json";
const string jsonSerializerDllPath = @"C:\Users\Lenovo\Documents\бгуир\предметы\3курс\5сем\СПП\лабы\1 лаба\MPP_Lab1\Tracer.Serialization\Tracer.Serialization.Json\obj\Debug\net6.0\Tracer.Serialization.Json.dll";

var jsonSerializer = SerializeLoader.GetSerializer(jsonSerializerDllPath);
var jsonStream = new FileStream(Path.Join(testDirPath, jsonFileName), FileMode.OpenOrCreate, FileAccess.Write);
await jsonSerializer.Serialize(traceResult, jsonStream);



