using ContineroExercise.Logic.Sources.FileSystem;
using ContineroExercise.Logic.Sources.Memory;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class MemoryDataSourceTests
    {
        [Test]
        public async Task MemoryStreamConstructor()
        {
            using var stream = new MemoryStream(Encoding.ASCII.GetBytes("Toto je test"));
            stream.Flush();
            var source = new MemoryDataSource(stream);
            Assert.That(await source.GetStreamAsStringAsync(), Is.EqualTo("Toto je test"));
        }

        [Test]
        public async Task ByteConstructor()
        {
            var source = new MemoryDataSource(Encoding.ASCII.GetBytes("Toto je test"));
            Assert.That(await source.GetStreamAsStringAsync(), Is.EqualTo("Toto je test"));
        }

        [Test]
        public async Task StringConstructor()
        {
            var source = new MemoryDataSource("Toto je test");
            Assert.That(await source.GetStreamAsStringAsync(), Is.EqualTo("Toto je test"));
        }


    }
}