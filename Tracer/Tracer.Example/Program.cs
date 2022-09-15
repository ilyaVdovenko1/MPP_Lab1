using Tracer.Example.Dll;
using Tracer.Example.Domain;

// init
var tracer = new Tracer.Core.Domain.Services.Tracer();
var testClassOne = new TestClassOne(tracer);
var testClassTwo = new TestClassTwo(tracer);

//act
Inner();
await NextThread();
void Inner()
{
    tracer.StartTrace();
    testClassOne.TestMethodOne();
    testClassOne.TestMethodTwo();
    
    tracer.StopTrace();
}

Task NextThread()
{
    return Task.Run(() =>
    {
        tracer.StartTrace();
        testClassTwo.TestMethodOne();
        testClassTwo.TestMethodTwo();
        tracer.StopTrace();
    });
}
const string testDirPath = @"../../../TestResults";
var traceResult = tracer.GetTraceResult();

//json
const string jsonFileName = "result.json";
const string jsonSerializerDllPath = @"C:\Users\Lenovo\Documents\бгуир\предметы\3курс\5сем\СПП\лабы\1 лаба\MPP_Lab1\Tracer.Serialization\Tracer.Serialization.Json\obj\Debug\net6.0\Tracer.Serialization.Json.dll";

var jsonSerializer = SerializeLoader.GetSerializer(jsonSerializerDllPath);
var jsonStream = new FileStream(Path.Join(testDirPath, jsonFileName), FileMode.OpenOrCreate, FileAccess.Write);
await jsonSerializer.Serialize(traceResult, jsonStream);

//xml
const string xmlFileName = "result.xml";
const string xmlSerializerDllPath = @"C:\Users\Lenovo\Documents\бгуир\предметы\3курс\5сем\СПП\лабы\1 лаба\MPP_Lab1\Tracer.Serialization\Tracer.Serialization.Xml\obj\Debug\net6.0\Tracer.Serialization.Xml.dll";

var xmlSerializer = SerializeLoader.GetSerializer(xmlSerializerDllPath);
var xmlStream = new FileStream(Path.Join(testDirPath, xmlFileName), FileMode.OpenOrCreate, FileAccess.Write);
await xmlSerializer.Serialize(traceResult, xmlStream);

//yaml
const string yamlFileName = "result.yaml";
const string yamlSerializerDllPath = @"C:\Users\Lenovo\Documents\бгуир\предметы\3курс\5сем\СПП\лабы\1 лаба\MPP_Lab1\Tracer.Serialization\Tracer.Serialization.Yaml\obj\Debug\net6.0\Tracer.Serialization.Yaml.dll";

var yamlSerializer = SerializeLoader.GetSerializer(yamlSerializerDllPath);
var yamlStream = new FileStream(Path.Join(testDirPath, yamlFileName), FileMode.OpenOrCreate, FileAccess.Write);
await yamlSerializer.Serialize(traceResult, yamlStream);

