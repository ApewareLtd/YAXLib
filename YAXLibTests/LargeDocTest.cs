using System.Diagnostics;
using NUnit.Framework;
using YAXLib;
using YAXLibTests.SampleClasses;

namespace YAXLibTests
{
    [TestFixture]
    public class LargeDocTest
    {
        [Test]
        public void SerializeAndDeserializeLargeDoc()
        {
            var largeDoc = new LargeDoc();
            largeDoc.InitialiseDummyData();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var serializer = new YAXSerializer(typeof(LargeDoc));
            var xml = serializer.Serialize(largeDoc);
            var newLargeDoc = serializer.Deserialize(xml);

            sw.Stop();

            
        }
    }
}