using ContineroExercise.Logic.Readers.StringBasedReaders;
using ContineroExercise.Logic.Sources.FileSystem;
using ContineroExercise.Logic.Sources.Memory;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class StringBasedReadersTests
    {
        class TestStringBasedReader : StringBasedReader<bool>
        {
            protected override bool CreateModel(string data)
            {
                if (string.IsNullOrWhiteSpace(data))
                    return false;
                return true;
            }
        }

        [Test]
        public async Task StringBasedReaderTrue()
        {
            var reader = new TestStringBasedReader();
            Assert.That(await reader.ReadAsync(new MemoryDataSource("ahoj")), Is.EqualTo(true));
        }

        [Test]
        public async Task StringBasedReaderFalse()
        {
            var reader = new TestStringBasedReader();
            Assert.That(await reader.ReadAsync(new MemoryDataSource("")), Is.EqualTo(false));
        }
    }
}